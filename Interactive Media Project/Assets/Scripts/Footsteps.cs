//code made with help from tutorial : https://www.youtube.com/watch?v=fT32r1dvO_I

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Footsteps : MonoBehaviour
{
    private int MaterialValue;
    private RaycastHit rh;
    private float distance = 0.3f;
    private string EventPath = "event:/Foley/Footsteps";
    private PARAMETER_ID ParamID;
    private PARAMETER_ID ParamID2;
    private LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayWalkEvent()
    {
        MaterialCheck();
        EventInstance Walk = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(Walk, transform, GetComponent<Rigidbody>());

        Walk.setParameterByID(ParamID, MaterialValue, false);

        Walk.start();
        Walk.release();
    }

    void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out rh, distance, lm))
        {
            switch(rh.collider.tag)
            {
                case: "Stone":
                    MaterialValue = 0;
                    break;
                case: "Sand":
                    MaterialValue = 1;
                    break;
            }
        }
    }
}
