using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private AudioClip clickSound;

    public GameObject tankPrefab;
    public GameObject tankPrefabTwo;

    public GameObject playerControllerPrefab;
    public GameObject playerControllerPrefabTwo;

    public Transform playerSpawnTransform;
    public Transform playerSpawnTransformTwo;

    public GameObject cameraPlayerOne;
    public GameObject cameraPlayerTwo;
    public GameObject singlePlayerCamera;

    public List<PlayerController> Players;

    public GameObject TitleScreenState;
    public GameObject LevelSelectState;
    public GameObject OptionsState;
    public GameObject GameOverState;

    Boolean TwoPlayerVariable = false;

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

        ActivateTitleScreenState();
    }

    private void Start()
    {
        SpawnPlayerOne();
    }

    public void ActivateTitleScreenState()
    {
        //SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        TitleScreenState.SetActive(true);
        tankPrefabTwo.SetActive(true);
    }
    public void ActivateLevelSelectState()
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        LevelSelectState.SetActive(true);
    }
    public void ActivateOptionsState()
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        OptionsState.SetActive(true);
    }
    public void ActivateGameOverState()
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        GameOverState.SetActive(true);
    }

    public void SinglePlayerState() 
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);

        //Deactivate canvases en masse
        TitleScreenState.SetActive(false);
        LevelSelectState.SetActive(false);
        OptionsState.SetActive(false);
        GameOverState.SetActive(false);

        cameraPlayerTwo.SetActive(false);
        cameraPlayerOne.SetActive(false);

        TwoPlayerVariable = false;
        
        if (tankPrefabTwo != null)
        {
            tankPrefabTwo.SetActive(false);
        }
        Debug.Log("One Player Playing");
    }
    public void TwoPlayerGameState() 
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);

        //Deactivate canvases en masse
        TitleScreenState.SetActive(false);
        LevelSelectState.SetActive(false);
        OptionsState.SetActive(false);
        GameOverState.SetActive(false);

        singlePlayerCamera.SetActive(false);
        cameraPlayerTwo.SetActive(true);
        cameraPlayerOne.SetActive(true);
        
        TwoPlayerVariable = true;
        
        if (tankPrefabTwo != null) 
        {
            SpawnPlayerTwo();
        }
        Debug.Log("Two Players Playing!");
    }
    public void QuitApp()
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        Application.Quit();
        Debug.Log("Quit");
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

        if (cameraPlayerOne != null) 
        {
            cameraPlayerOne.transform.parent = newPawnObj.transform;
        }

        if (TwoPlayerVariable == false)
        {
            singlePlayerCamera.transform.parent = newPawnObj.transform;
        }
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

            cameraPlayerTwo.transform.parent = newPawnObj.transform;
    }
}
