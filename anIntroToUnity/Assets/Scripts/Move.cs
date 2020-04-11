using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(speed);
    }
}
