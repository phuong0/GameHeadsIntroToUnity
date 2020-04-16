using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speedLeftKey = new Vector3(-0.1f, 0.0f, 0.0f);
    public Vector3 speedRightKey = new Vector3(0.1f, 0.0f, 0.0f);
    public Vector3 speedUpKey = new Vector3(0.0f, 0.0f, 0.1f);
    public Vector3 speedDownKey = new Vector3(0.0f, 0.0f, -0.1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { gameObject.transform.Translate(speedLeftKey); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { gameObject.transform.Translate(speedRightKey); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { gameObject.transform.Translate(speedUpKey); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { gameObject.transform.Translate(speedDownKey); }
    }
}
