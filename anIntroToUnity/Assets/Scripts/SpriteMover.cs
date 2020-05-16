using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.GameCenter;

public class SpriteMover : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 2.0f;
    public Slider healthbar;

    private Rigidbody2D rb;
    private BoxCollider2D pCollider;
    private float currentSpeed;


    // Start is called before the first frame update
    void Start()
    {
        healthbar.value = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        pCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += speed;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            healthbar.value -= 0.1f;
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        rb.AddForce(new Vector2(currentSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(pCollider.bounds.center, pCollider.bounds.size, 0f, Vector2.down, 1f);
    }

}