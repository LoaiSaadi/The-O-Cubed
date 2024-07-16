/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctahedronMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5;
    public Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();///
        // Create a new mesh and mesh filter
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        Mesh mesh = new Mesh();

        // Define vertices with scale of 1x1x1
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0.5f, 0, 0),  // 0
            new Vector3(-0.5f, 0, 0), // 1
            new Vector3(0, 0.5f, 0),  // 2
            new Vector3(0, -0.5f, 0), // 3
            new Vector3(0, 0, 0.5f),  // 4
            new Vector3(0, 0, -0.5f)  // 5
        };

        // Define triangles
        int[] triangles = new int[]
        {
            0, 2, 4,
            2, 1, 4,
            1, 3, 4,
            3, 0, 4,
            2, 0, 5,
            1, 2, 5,
            3, 1, 5,
            0, 3, 5
        };

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;

        // Add and assign the MeshCollider
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        // get players input
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
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctahedronMovement : MonoBehaviour
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

        // Define vertices with adjusted scale
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0.5f, 0, 0),  // 0
            new Vector3(-0.5f, 0, 0), // 1
            new Vector3(0, 0.5f, 0),  // 2
            new Vector3(0, -0.5f, 0), // 3
            new Vector3(0, 0, 0.5f),  // 4
            new Vector3(0, 0, -0.5f)  // 5
        };

        // Define triangles
        int[] triangles = new int[]
        {
            0, 2, 4,
            2, 1, 4,
            1, 3, 4,
            3, 0, 4,
            2, 0, 5,
            1, 2, 5,
            3, 1, 5,
            0, 3, 5
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
