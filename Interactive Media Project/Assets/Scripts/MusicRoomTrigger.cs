//code made with help from https://alessandrofama.com/tutorials/fmod-unity/events/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRoomTrigger : MonoBehaviour
{
    [FMODUnity.EventRef] //reference to FMOD plugin
    public string Rumble = “event:/Rumble”; //create string with FMOD event
    public FMOD.Studio.EventInstance AUDIO EVENT; //create instance of the event
    public FMOD.Studio.ParameterInstance PARAMETER EVENT; //create instance of the parameter
    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(Rumble);
        instance.getParameter(“Room”, out PARAMETER EVENT);
        instance.start();
    }

 
    void OnTriggerEnter(Collider other)
    {
        instance.setValue(1.0);
    }
}
