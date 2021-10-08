using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 This script is made by following a youtube tutorial by youtuber Killer Whale. 
It's from a video called Unity C#Tutorial: Opening A Door With A Key, published on may 3, 2020
https://www.youtube.com/watch?v=hWbdaihafjo
 */


public class PickKey : MonoBehaviour
{
    public Component doorcolliderhere;  //pass the doorcollider so that we can enable and disable it
    public GameObject keygone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   //should check whether to use ontriggerenter or something as ontriggerstay didnt work
    {
        //The box collider should be enabled only after the key has been gotten
        if (Input.GetKey(KeyCode.E))        //player presses keycode E when they are near the key
        {
            doorcolliderhere.GetComponent<BoxCollider>().enabled = true;    //box collider of door is enabled
            keygone.SetActive(false);   //key dissappears
        }
    }
}
