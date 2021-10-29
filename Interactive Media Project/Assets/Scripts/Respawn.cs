using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script was made following the youtube tutorial ULTIMATE Respawning Guide in Unity [2D & 3D Respawn] by youtuber SpeedTutor
...*/


public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();   //call the sync transform method to update the values
        }
    }

}
