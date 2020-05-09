using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 3.0f;
    private float currentLife = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //when lifeSpan seconds has past delete me
        currentLife += Time.deltaTime;

        if (currentLife >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    //destory when collide with anything but player and added 0.1f of delay
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("CapsulePlayer"))
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
