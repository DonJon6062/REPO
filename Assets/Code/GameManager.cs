using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject tankPrefab;
    public GameObject playerControllerPrefab;
    public Transform playerSpawnTransform;

    public List<PlayerController> Players;

    //Awake; happens when the obj is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //if gameManager already exists
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject newPawnObj = Instantiate(tankPrefab, playerSpawnTransform.position, Quaternion.identity) as GameObject;

        Controller newPlayerController = newPlayerObj.GetComponent<Controller>();

        Pawn newPlayerPawn = newPawnObj.GetComponent<Pawn>();

        newPlayerController.pawn = newPlayerPawn;

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.NoiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.NoiseMakerVolume = 3;

        newController.pawn = newPawn;
    }
}
