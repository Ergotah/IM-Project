using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSarcophagus : MonoBehaviour
{
    public Animation hingehere;
    public Animation mummyFall;

    [FMODUnity.EventRef]
    public string selectsound;
    FMOD.Studio.EventInstance soundevent;

    // 
    void Start()
    {
        soundevent = FMODUnity.RuntimeManager.CreateInstance(selectsound);
    }

    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundevent, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    void OnTriggerEnter()
    {
        hingehere.Play();
        soundevent.start();
        mummyFall.Play();
    }
}
