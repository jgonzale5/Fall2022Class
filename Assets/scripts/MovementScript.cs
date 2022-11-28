using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //The speed of the object with this script
    public float speed;

    //The amount of angles that our player will rotate in a second
    public float angleSpeed = 20;

    //The length of the raycast used to determine if there's an obstacle in the way
    public float skinWidth = 0.1f;

    //What layers can be hit by the ray
    public LayerMask skinLayers;

    // Update is called once per frame
    void Update()
    {
        #region Movement
        //We get the user input and store it in local variables
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //We multiply the input by speed and time delta time to determine how much the player should move this frame
        x = x * speed * Time.deltaTime;
        y = y * speed * Time.deltaTime;

        //If the function CheckForWall returns true, after being sent the direction and the range,
        //dont move the player in that direction
        //this.tranform.right will give us the direction vector coming to the right of the transform
        if (CheckForWall(this.transform.right * x, skinWidth) == false)
        {
            x = 0;
        }
        if (CheckForWall(this.transform.up * y, skinWidth) == false)
        {
            y = 0;
        }

        //We set the new position of the transform this frame
        //Local
        //this.transform.localPosition = this.transform.localPosition + new Vector3(x, y, 0);
        this.transform.position = this.transform.position + (this.transform.up * y) + (this.transform.right * x);
        //World
        //this.transform.position = this.transform.position + new Vector3(x, y, 0);
        //Equivalent to this as well
        //this.transform.position = new Vector3(this.transform.position.x + x, 
        //    this.transform.position.y + y, this.transform.position.z + 0);
        #endregion

        #region Rotation
        float rotX = Input.GetAxisRaw("Rotation") * angleSpeed * Time.deltaTime;

        this.transform.rotation = Quaternion.Euler(0, 0, this.transform.eulerAngles.z + rotX); 
        

        #endregion
    }

    bool CheckForWall(Vector3 direction, float range)
    {
        RaycastHit info;

        //This will draw the ray in our editor for debugging purposes
        Debug.DrawRay(this.transform.position, direction * range *2, Color.blue, 1);


        //If we can cast a ray from the the position of this transform, in the direction specified,
        //with a maximum distance of range, and hit something. Put the result of the hit into info.
        //Ignore all layers not specified by skinLayers
        if (Physics.Raycast(this.transform.position, direction, out info , range, skinLayers))
        {
            //This will tell us the name of the transform hit
            Debug.Log(info.transform.name);
            return false;
        }
        else
        {
            return true;
        }
    }
}
