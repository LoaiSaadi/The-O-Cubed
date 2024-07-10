using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5;
    public Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isGrounded = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Vector3.up means (0,1,0): means jump up 1 unit (towards y)
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        isGrounded = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}