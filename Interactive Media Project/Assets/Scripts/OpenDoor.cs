using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 This script is made by following a youtube tutorial by youtuber Killer Whale. 
It's from a video called Unity C#Tutorial: Opening A Door With A Key, published on may 3, 2020
https://www.youtube.com/watch?v=hWbdaihafjo
 */

public class OpenDoor : MonoBehaviour
{
    public Animation hingehere;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay()        //when you get to the box collider of the door you can press E and the hinge animation will play
    {
        if (Input.GetKey(KeyCode.E))
        {
            hingehere.Play();
        }
    }
}