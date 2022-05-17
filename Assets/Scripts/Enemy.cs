using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] int speed =6;
    bool isRotatingRight;
    bool isNotRotating;
    bool isPlayerDetected = false;
    Quaternion deltaRotation;
    Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(delayChangeRotation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        if (isPlayerDetected == false)
        {
            Rotate();
        } else
        {
            MoveTowardsPlayer();
        }
            
    } 

    void Rotate()
    {
        if (isRotatingRight == true && isNotRotating == false)
        {

            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rotationVector = new Vector3(0, 45, 0);
            deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        } else if (isRotatingRight == false && isNotRotating == false)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            
            rotationVector = new Vector3(0, -45, 0);
            deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        } else if (isNotRotating == true)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        }
        
    }

    IEnumerator delayChangeRotation()
    {
        isRotatingRight = true;
        isNotRotating = false;

        yield return new WaitForSeconds(5);
        isRotatingRight = true;
        isNotRotating = true;

        yield return new WaitForSeconds(2);

        isRotatingRight = false;
        isNotRotating = false;

        yield return new WaitForSeconds(5);
        isRotatingRight = false;
        isNotRotating = true;

        yield return new WaitForSeconds(2);

        StartCoroutine(delayChangeRotation());
    }
    
    public void DetectPlayer()
    {
        isPlayerDetected = true;
    }
    public void MoveTowardsPlayer()
    {
        StopAllCoroutines();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        transform.LookAt(player.transform);
        rigidbody.velocity = transform.forward * speed;
    }

    public void RestartRotation()
    {
        Debug.Log("Player not visible, let's rotate");
        isPlayerDetected = false;
        StartCoroutine(delayChangeRotation());
    }
    
}
