using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject tankPrefab;
    public GameObject tankPrefabTwo;

    public GameObject playerControllerPrefab;
    public GameObject playerControllerPrefabTwo;

    public Transform playerSpawnTransform;
    public Transform playerSpawnTransformTwo;

    public GameObject cameraPlayerOne;
    public GameObject cameraPlayerTwo;

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
        SpawnPlayerOne();
        SpawnPlayerTwo();
    }
    public void SpawnPlayerOne()
    {
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject newPawnObj = Instantiate(tankPrefab, playerSpawnTransform.position, Quaternion.identity) as GameObject;

        Controller newPlayerController = newPlayerObj.GetComponent<Controller>();

        Pawn newPlayerPawn = newPawnObj.GetComponent<Pawn>();

        newPlayerController.pawn = newPlayerPawn;

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.GetComponent<PowerupManager>();

        newController.pawn = newPawn;

        cameraPlayerOne.transform.parent = newPlayerObj.transform;
    }

    public void SpawnPlayerTwo()
    {
        GameObject newPlayerObj = Instantiate(playerControllerPrefabTwo, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject newPawnObj = Instantiate(tankPrefabTwo, playerSpawnTransformTwo.position, Quaternion.identity) as GameObject;

        Controller newPlayerController = newPlayerObj.GetComponent<Controller>();

        Pawn newPlayerPawn = newPawnObj.GetComponent<Pawn>();

        newPlayerController.pawn = newPlayerPawn;

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.GetComponent<PowerupManager>();

        newController.pawn = newPawn;

        cameraPlayerTwo.transform.parent = newPlayerObj.transform;
    }

    public void DieForReal() 
    {
        if (Players == null)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }
}
