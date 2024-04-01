using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSpawner : MonoBehaviour
{
    public GameObject AI_TankPrefab;
    public GameObject AIControllerPrefab;
    public Transform pawnSpawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAI()
    { 
        GameObject newAITank = Instantiate(AI_TankPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController = newAIController.GetComponent<AIController>();

        Pawn newAIPawn = newAITank.GetComponent<Pawn>();

        newAITank.AddComponent<PowerupManager>();

        newController.pawn = newAIPawn;
    }
}
