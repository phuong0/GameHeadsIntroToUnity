using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Move : MonoBehaviour
{
    // The code that is commented out is my code that I was working on. Raymond said that having different variables is not a good idea.

    // The code that isn't commented out is what Raymond would do.

    //public Vector3 speedLeftKey = new Vector3(-0.1f, 0.0f, 0.0f);
    //public Vector3 speedRightKey = new Vector3(0.1f, 0.0f, 0.0f);
    //public Vector3 speedUpKey = new Vector3(0.0f, 0.0f, 0.1f);
    //public Vector3 speedDownKey = new Vector3(0.0f, 0.0f, -0.1f);

    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentSpeed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            currentSpeed.x = -speed.x;
            //gameObject.transform.Translate(speedLeftKey); 
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            currentSpeed.x = speed.x;
            //gameObject.transform.Translate(speedRightKey); 
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            currentSpeed.z = speed.z;
            //gameObject.transform.Translate(speedUpKey); 
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            currentSpeed.z = -speed.z;
            //gameObject.transform.Translate(speedDownKey);
        }

        gameObject.transform.Translate(currentSpeed * Time.deltaTime);
    }
}
