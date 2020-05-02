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
        //Hint: Time.deltaTime, use it to count how much time pass

        //Destroy(this);

        //hit ground, use onCollisionEnter
    }
}
