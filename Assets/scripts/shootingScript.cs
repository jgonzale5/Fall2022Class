using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    //The projectile to be shot
    public Transform projectile;
    //The time between each shot if you hold the fire button
    public float fireRate = 0.1f;
    //Where the projectiles will be coming from
    public GameObject muzzlePosition;

    //The time passed since the last shot
    float cooldown = 0;

    void Update()
    {
        //If youre holding the fire button and the cooldown is higher than the fire rate
        if (Input.GetButton("Fire1") && cooldown >= fireRate)
        {
            //We spawn the projectile at the position of the muzzle, with the rotation of said muzzle
            Instantiate(projectile, muzzlePosition.transform.position, muzzlePosition.transform.rotation);

            //Reset the cooldown
            cooldown = 0;
        }

        //Increase the cooldown
        cooldown += Time.deltaTime;
    }
}
