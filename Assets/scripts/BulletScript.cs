using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 1f;
    public Transform collisionParticle;

    public float lifetime = 2f;
    float lifetimePassed = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        //Same as
        //transform.position = transform.position + transform.up * speed * Time.deltaTime;

        //If this object has lived past its lifetime its destroyed, otherwise its increased
        if (lifetimePassed >= lifetime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            lifetimePassed += Time.deltaTime;
        }
    }
}
