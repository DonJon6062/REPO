using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;

    public void RespawnPlayer(Pawn source) 
    {
        player.transform.position = spawnPoint.transform.position;
    }
}
