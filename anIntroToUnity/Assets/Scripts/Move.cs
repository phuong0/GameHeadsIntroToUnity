using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;

    public Vector3 speed;

    //Amount of degrees per second to turn
    public float turnSpeed;
    public float jumpForce = 5.0f;

    private Rigidbody rb;
    private CapsuleCollider pCol;
    private float castDistance;
    private float currentSpeed = 0.0f;
    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = 0.0f;
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

        if (Input.GetKey(KeyCode.F))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawnPoint.position, new Quaternion());
            Rigidbody bulletBody = newBullet.GetComponent<Rigidbody>();
            //direction * amount of force
            bulletBody.AddForce(transform.forward * 30, ForceMode.Impulse);
        }

        gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime, ForceMode.Impulse);

        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) && (isGrounded || jumpCount < 2))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }

        rb.angularVelocity = Vector3.zero;
    }
    
    //checks for collisions on the ground
    bool IsGrounded()
    {
        RaycastHit hit;
        castDistance = pCol.bounds.extents.y + 0.1f;
        bool boxHit = Physics.SphereCast(pCol.bounds.center, pCol.radius, Vector3.down, out hit, castDistance);
        return boxHit;
    }
}
