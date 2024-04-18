using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSpawner : MonoBehaviour
{
    public GameObject AI_TankPrefab;
    public GameObject AI_TankPrefab_2;
    public GameObject AI_TankPrefab_3;
    public GameObject AI_TankPrefab_4;

    public GameObject AIControllerPrefab;
    public GameObject AIControllerPrefab_2;
    public GameObject AIControllerPrefab_3;
    public GameObject AIControllerPrefab_4;

    public Transform pawnSpawnTransform;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAI();
        SpawnAI_2();
        SpawnAI_3();
        SpawnAI_4();
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
    public void SpawnAI_2()
    {
        GameObject newAITank_2 = Instantiate(AI_TankPrefab_2, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController_2 = Instantiate(AIControllerPrefab_2, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController_2 = newAIController_2.GetComponent<AIController>();

        Pawn newAIPawn_2 = newAITank_2.GetComponent<Pawn>();

        newAITank_2.AddComponent<PowerupManager>();

        newController_2.pawn = newAIPawn_2;
    }

    public void SpawnAI_3()
    {
        GameObject newAITank_3 = Instantiate(AI_TankPrefab_3, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController_3 = Instantiate(AIControllerPrefab_3, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController_3 = newAIController_3.GetComponent<AIController>();

        Pawn newAIPawn_3 = newAITank_3.GetComponent<Pawn>();

        newAITank_3.AddComponent<PowerupManager>();

        newController_3.pawn = newAIPawn_3;
    }
    public void SpawnAI_4()
    {
        GameObject newAITank_4 = Instantiate(AI_TankPrefab_4, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController_4 = Instantiate(AIControllerPrefab_4, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController_4 = newAIController_4.GetComponent<AIController>();

        Pawn newAIPawn_4 = newAITank_4.GetComponent<Pawn>();

        newAITank_4.AddComponent<PowerupManager>();

        newController_4.pawn = newAIPawn_4;
    }
}
