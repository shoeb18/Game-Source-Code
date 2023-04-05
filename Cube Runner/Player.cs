using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float forwardForce = 1000f;
    public float minX;
    public float maxX;
    public Rigidbody playerRigidBody;

    void Update()
    {
        // clamping playing between minX and maxX
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        transform.position = playerPosition;


        // getting user input using Input class for player movement 

        // player movement for right direction 
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);
        }

        // player movement for left direction
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position - new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);
        }

    }

    private void FixedUpdate()
    {
        // player run forward on ground
        playerRigidBody.AddForce(0f, 0f, forwardForce * Time.deltaTime);
    }
}
