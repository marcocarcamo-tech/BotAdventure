using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //Variables

    //Object that will be throw to the pool
    [SerializeField] GameObject bulletPrefab;

    //Point where objects will be spawned
    //[SerializeField] Transform spawnPoint;

    //Size of the pool
    public int poolSize = 100;
    public bool emptyPool;

    //Queue for the pool where objects will be stored
    private Queue<GameObject> objectPool;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize Pool
        InitializePool();

    }

    private void InitializePool()
    {
        //Initialize Queue
        objectPool = new Queue<GameObject>();

        //Fill the pool
        for (int i = 0; i < poolSize; i++)
        {
            AddObjectToPool();
        }

    }

    private void AddObjectToPool()
    {
        //Instantiate a new object
        GameObject newObject = Instantiate(bulletPrefab);

        //Add object to the Queue
        objectPool.Enqueue(newObject);

        //Set object active to false
        newObject.SetActive(false);
    }

    public GameObject GetObjectFromPool(Vector3 newPosition, Quaternion newRotation)
    {
        //We get firts object available in Queue
        GameObject newObject = objectPool.Dequeue();
        //Activate the object
        newObject.SetActive(true);
        //Assign position and rotation
        newObject.transform.SetPositionAndRotation(newPosition, newRotation);

        return newObject;
    }
    public void ReturnObjToPool(GameObject gameObject)
    {
        //Deactivate the object
        gameObject.SetActive(false);
        //Add again to the Queue
        objectPool.Enqueue(gameObject);
        Debug.Log("Returned to pool");
    }

    public bool EmptyShots()
    {
        if (poolSize <= 0)
        {
            poolSize = 0;
            emptyPool = true;
        }
        else
        {
            emptyPool = false;
        }

        return emptyPool;
    }
}
