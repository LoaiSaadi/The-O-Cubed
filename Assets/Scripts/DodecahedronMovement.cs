using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodecahedronMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        if (playerRb == null)
        {
            playerRb = gameObject.AddComponent<Rigidbody>();
        }

        // Create a new mesh and mesh filter
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        Mesh mesh = new Mesh();

        // Golden ratio φ
        float phi = (1 + Mathf.Sqrt(5)) / 2;

        // Define vertices for a regular dodecahedron
        Vector3[] vertices = new Vector3[20];

        float a = 1.0f;
        float b = 1.0f / phi;

        vertices[0] = new Vector3(a, a, a);
        vertices[1] = new Vector3(a, a, -a);
        vertices[2] = new Vector3(a, -a, a);
        vertices[3] = new Vector3(a, -a, -a);
        vertices[4] = new Vector3(-a, a, a);
        vertices[5] = new Vector3(-a, a, -a);
        vertices[6] = new Vector3(-a, -a, a);
        vertices[7] = new Vector3(-a, -a, -a);

        vertices[8] = new Vector3(b, b * phi, 0);
        vertices[9] = new Vector3(b, -b * phi, 0);
        vertices[10] = new Vector3(-b, b * phi, 0);
        vertices[11] = new Vector3(-b, -b * phi, 0);

        vertices[12] = new Vector3(0, b, b * phi);
        vertices[13] = new Vector3(0, b, -b * phi);
        vertices[14] = new Vector3(0, -b, b * phi);
        vertices[15] = new Vector3(0, -b, -b * phi);

        vertices[16] = new Vector3(b * phi, 0, b);
        vertices[17] = new Vector3(b * phi, 0, -b);
        vertices[18] = new Vector3(-b * phi, 0, b);
        vertices[19] = new Vector3(-b * phi, 0, -b);

        // Define triangles for dodecahedron (12 faces)
        int[] triangles = new int[]
        {
            0, 8, 12,
            0, 12, 16,
            0, 16, 4,
            0, 4, 14,
            0, 14, 8,

            1, 10, 15,
            1, 15, 17,
            1, 17, 5,
            1, 5, 18,
            1, 18, 10,

            2, 11, 19,
            2, 19, 18,
            2, 18, 5,
            2, 5, 14,
            2, 14, 11,

            3, 9, 16,
            3, 16, 12,
            3, 12, 6,
            3, 6, 19,
            3, 19, 9,

            4, 16, 9,
            4, 9, 19,
            4, 19, 6,
            4, 6, 13,
            4, 13, 14,

            5, 17, 7,
            5, 7, 18,
            5, 18, 19,
            5, 19, 6,
            5, 6, 14,

            6, 12, 8,
            6, 8, 10,
            6, 10, 18,
            6, 18, 7,
            6, 7, 13,

            7, 17, 15,
            7, 15, 11,
            7, 11, 13,
            7, 13, 6,
            7, 6, 8,

            8, 14, 13,
            8, 13, 11,
            8, 11, 15,
            8, 15, 10,
            8, 10, 12,

            9, 16, 3,
            9, 3, 15,
            9, 15, 11,
            9, 11, 13,
            9, 13, 19,

            10, 18, 7,
            10, 7, 17,
            10, 17, 3,
            10, 3, 15,
            10, 15, 12,

            11, 13, 7,
            11, 7, 17,
            11, 17, 3,
            11, 3, 9,
            11, 9, 19
        };

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        // Add and assign a BoxCollider for stability
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = Vector3.zero;
        boxCollider.size = new Vector3(1, 1, 1); // Adjust size based on scale
    }

    // Update is called once per frame
    void Update()
    {
        // get player's input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the player, horizontal and forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // jump the player
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // Vector3.up means (0,1,0): means jump up 1 unit (towards y)
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
