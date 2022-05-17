using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    float x;
    float z;
    Vector3 movement;
    [SerializeField] int speed = 1;
    Rigidbody rb;
    Vector3 rotationVector;
    float rotationAngle = 90f;
    [SerializeField] PoolManager poolManager;
    [SerializeField] Transform pool;
    [SerializeField] Rigidbody bulletRb;
    bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            isShooting = true;
        } else
        {
            isShooting = false;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        movement = z * transform.forward;
        rotationVector = new Vector3(0.0f, x * rotationAngle, 0.0f);



    }

    private void FixedUpdate()
    {
        if (isShooting == true)
        {
            Shoot();
        }
        
        float verticalVelocity = movement.normalized.z * speed;
        float horizontalVelocity = movement.normalized.x * speed;
        rb.velocity = new Vector3(horizontalVelocity, rb.velocity.y, verticalVelocity);

        if (x >= 0.1 || x <= -0.1) {
            Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
            //rb.rotation = deltaRotation;
            rb.MoveRotation(rb.rotation * deltaRotation);
        } else
        {
            rb.freezeRotation = true;
        }
        
    }

    public void Shoot()
    {
        
        GameObject bullet = poolManager.GetObjectFromPool(pool.position, pool.rotation);
        float force = 50f;
        Vector3 shotVelocity = bullet.transform.forward * force;
        bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shotVelocity;
        poolManager.poolSize--;
        StartCoroutine(ReturnToPoolRoutine(bullet));
    }

    IEnumerator ReturnToPoolRoutine(GameObject bullet)
    {
        yield return new WaitForSeconds(5);
        poolManager.ReturnObjToPool(bullet);
    }
}
