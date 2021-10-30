using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 This script is made by following a youtube tutorial by youtuber Killer Whale. 
It's from a video called Unity C#Tutorial: Opening A Door With A Key, published on may 3, 2020
https://www.youtube.com/watch?v=hWbdaihafjo
We added code for the UIobject to display text so that the player knows to press E
Furthermore the trigger to show the objective is destroyed
 */


public class PickKey : MonoBehaviour
{
    public Component doorcolliderhere;  //pass the doorcollider so that we can enable and disable it
    public GameObject keygone;
    public GameObject UiObject;
    public GameObject UiGateText;
    public GameObject GateTrigger;  //pass the cube that acts as the gate trigger for objective text
    public GameObject target;
    public Camera cam;

    [FMODUnity.EventRef]
    public string selectsound;
    FMOD.Studio.EventInstance soundevent;

    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
        
        soundevent = FMODUnity.RuntimeManager.CreateInstance(selectsound);
    }

    private bool IsVisible(Camera c, GameObject target)     //check whether the view of the camers is focused on the key
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")   //when the player triggered the key collider
        {
            if (IsVisible(cam, target))     //check whether the player has found the key
            {
                UiObject.SetActive(true);       //show the grab key text
                UiGateText.SetActive(false);    //make the objective text dissapear
            }
        }
    }


    // Update is called once per frame
    void OnTriggerStay()   //when the trigger of the key is found
    {

        //The box collider should be enabled only after the key has been gotten
        if (Input.GetKey(KeyCode.E))        //player presses keycode E when they are near the key
        {
            doorcolliderhere.GetComponent<BoxCollider>().enabled = true;    //box collider of door is enabled
            keygone.SetActive(false);   //key dissappears
            UiObject.SetActive(false);  //objective text dissapears
            Destroy (GateTrigger); //make sure the objective text to find the key won't be shown again by destrying the trigger
            //FMODUnity.RunTimeManager.CreateInstance (event:/Key_PickUp);
            soundevent.start();
        }
    }

    
}
