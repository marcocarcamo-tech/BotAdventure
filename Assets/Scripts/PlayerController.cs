using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] Vector3 movement;
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 rotationVector;
    [SerializeField] float rotationAngle = 10f;

    Rigidbody rigidbidy;


    void Start()
    {
        rigidbidy = GetComponent<Rigidbody>();
        
    }

   
    void Update()

    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rotationVector = new Vector3 (0.0f , horizontal * rotationAngle, 0.0f);
       

        
        movement = (vertical * transform.forward);
        movement = movement.normalized * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
        rigidbidy.MovePosition(rigidbidy.position + movement);
        rigidbidy.MoveRotation(rigidbidy.rotation * deltaRotation);
    }
}
