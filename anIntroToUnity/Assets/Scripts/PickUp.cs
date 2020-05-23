using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private UpdateScore refScript;

    private void OnTriggerEnter2D(Collider2D theCollider)
    {
        if (theCollider.gameObject.CompareTag("Player"))
        {
            refScript = theCollider.gameObject.GetComponent<UpdateScore>();
            Destroy(gameObject);
            refScript.changeTheScore();
        }
        
    }
}
