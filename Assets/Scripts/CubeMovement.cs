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
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
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
 
}