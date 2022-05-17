using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    float x;
    float z;
    Vector3 movement;
    [SerializeField] int speed = 1;
    Rigidbody rb;
    Vector3 rotationVector;
    float rotationAngle = 90f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        movement = z * transform.forward;
        rotationVector = new Vector3(0.0f, x * rotationAngle, 0.0f);

    }

    private void FixedUpdate()
    {
        

        float verticalVelocity = movement.normalized.z * speed;
        float horizontalVelocity = movement.normalized.x * speed;
        rb.AddForce(horizontalVelocity, rb.velocity.y, verticalVelocity);

        if (x >= 0.1 || x <= -0.1)
        {
            Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
            //rb.rotation = deltaRotation;
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else
        {
            rb.freezeRotation = true;
        }

    }

   
}
