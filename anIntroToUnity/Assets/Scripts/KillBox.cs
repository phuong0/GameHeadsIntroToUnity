using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    public Transform spawnPoint;

    public void OnCollisionEnter(Collision collision)
    {
        
    }

    public void OnCollisionExit(Collision collision)
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CapsulePlayer") )
        {
            Debug.Log("Player hit me!");

            other.gameObject.transform.position = spawnPoint.position;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
    }
}
