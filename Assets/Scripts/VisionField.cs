using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionField : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            enemy.DetectPlayer();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.RestartRotation();
        }
    }
}
