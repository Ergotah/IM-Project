using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;


public class GateTextTrigger : MonoBehaviour
{
    public GameObject UiObject;
       
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);      //at the beginning we don't see the ui text object
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UiObject.SetActive(true);       //when the player has entered the trigger the ui text object becomes visible
        }
    }
}
