using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.GameCenter;

public class SpriteMover : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 2.0f;

    private Rigidbody2D rb;
    private float distanceToGround = 0.0f;
    private bool isJumping = false;
    private LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        int maskValue = LayerMask.GetMask("Player");
        mask = ~maskValue;

        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<CircleCollider2D>().radius + Mathf.Epsilon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && IsGrounded())
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        float currentSpeed = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += speed;
        }

        rb.AddForce(new Vector2(currentSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse); 

        if(isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - distanceToGround), Vector2.down, 0.1f, mask);
        return (hit.collider != null);
    }

}