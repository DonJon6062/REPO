using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAgain : MonoBehaviour
{
    SpawnPawn SpawnPawn;
    public GameObject AI_TankPrefab_1;
    public GameObject AI_TankPrefab_2;
    public GameObject AI_TankPrefab_3;
    public GameObject AI_TankPrefab_4;

    public void OnGameRestart() 
    {
        if (AI_TankPrefab_1 == null) 
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
        }
        else if (AI_TankPrefab_2 == null)
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
        }
        else if (AI_TankPrefab_3 == null)
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
        }
        else if (AI_TankPrefab_4 == null)
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
        }
    }
}
