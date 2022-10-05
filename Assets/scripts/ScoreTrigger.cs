using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    //The static keyword makes it shared between all instances of this script
    static int score = 0;

    void OnTriggerEnter(Collider other)
    {
        //We check if the other collider has 
        //the tag "Amogu" on its object
        if (other.gameObject.tag == "Amogu")
        {
            score++;
            //is the same as saying
            //score = score + 1;
            //and increases the value of score by 1

            Debug.Log(transform.name + " : " + score);
        }
    }
}
