using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{

    public float speed = 5;
    private Rigidbody2D rb;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed += speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed -= speed;
        }

        //add jumping
        rb.AddForce(new Vector2(currentSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }
}
