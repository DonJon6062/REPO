using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAgain : MonoBehaviour
{
    [SerializeField] PawnSpawner spawner;
    [SerializeField] SpawnPawn SpawnPawn;
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
            spawner.SpawnAI();
        }
        else if (AI_TankPrefab_2 == null)
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
            spawner.SpawnAI_2();
        }
        else if (AI_TankPrefab_3 == null)
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
            spawner.SpawnAI_3();
        }
        else if (AI_TankPrefab_4 == null)
        {
            SpawnPawn = GetComponent<SpawnPawn>();
            SpawnPawn.SpawnThePawn();
            spawner.SpawnAI_4();
        }
    }
}
