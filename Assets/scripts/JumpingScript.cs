using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public Rigidbody reggiebody;
    public float jumpForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeScale >= 1f)
        {
            reggiebody.AddForce(Vector3.up * jumpForce);
            //reggiebody.AddForce(new Vector3(1, 1, 0).normalized * jumpForce);
        }
    }
}
