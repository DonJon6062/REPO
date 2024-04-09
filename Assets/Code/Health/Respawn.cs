using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform respawnPoint;

    public void RespawnPlayer() 
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
