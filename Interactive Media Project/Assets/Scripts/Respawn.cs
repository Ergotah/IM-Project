using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This is a simple respawning script that transforms the player back to an empty game object called respawnpoint.*/


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
