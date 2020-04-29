using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{

    public Vector3 speed;

    //Amount of degrees per second to turn
    public float turnSpeed;
    public float jumpForce = 5.0f;

    private bool isJumping = false;
    private Rigidbody rb;
    private CapsuleCollider pCol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float currentSpeed = 0.0f;
        float currentTurnAmount = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            currentTurnAmount -= turnSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            ;
            currentTurnAmount += turnSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = speed.x;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = -speed.x;
        }

        gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime, ForceMode.Impulse);
        rb.angularVelocity = Vector3.zero;

        isGrounded();

        if (Input.GetKeyUp(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //checks for collisions on the ground
        bool isGrounded() {
            RaycastHit hit;
            float castDistance = 1.1f;
            bool boxHit = Physics.SphereCast(pCol.bounds.center, pCol.radius, Vector3.down, out hit, castDistance);
            if (!boxHit)
            {
                isJumping = true;
            } 
            else
            {
                isJumping = false;
            }
            return boxHit;
        }

    }
}
