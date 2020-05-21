using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject g;
    private ChangeScore refScript;

    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.Find("Player");
        refScript = g.GetComponent<ChangeScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            refScript.changingScore();
        }
        
    }
}
