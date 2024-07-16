using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosahedronMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    public bool isOnGround = true;

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
        float a = 1;
        float b = 1 / phi;

        // Define vertices for a regular icosahedron
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-a, b, 0), new Vector3(a, b, 0), new Vector3(-a, -b, 0), new Vector3(a, -b, 0),
            new Vector3(0, -a, b), new Vector3(0, a, b), new Vector3(0, -a, -b), new Vector3(0, a, -b),
            new Vector3(b, 0, -a), new Vector3(b, 0, a), new Vector3(-b, 0, -a), new Vector3(-b, 0, a)
        };

        // Define triangles
        int[] triangles = new int[]
        {
            0, 11, 5,
            0, 5, 1,
            0, 1, 7,
            0, 7, 10,
            0, 10, 11,

            1, 5, 9,
            5, 11, 4,
            11, 10, 2,
            10, 7, 6,
            7, 1, 8,

            3, 9, 4,
            3, 4, 2,
            3, 2, 6,
            3, 6, 8,
            3, 8, 9,

            4, 9, 5,
            2, 4, 11,
            6, 2, 10,
            8, 6, 7,
            9, 8, 1
        };

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        // Add and assign a BoxCollider for stability
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = Vector3.zero;
        boxCollider.size = new Vector3(1, 1, 1);
    }

    void Update()
    {
        // Get player's input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the player, horizontal and forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Jump the player
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
