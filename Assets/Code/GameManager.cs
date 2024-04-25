using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour
{
    #region variables
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
    public GameObject WinScreenState;
    public GameObject PlayerTwoUI;

    Boolean TwoPlayerVariable = false;

    public GameObject AI_TankPrefab;
    public GameObject AI_TankPrefab_2;
    public GameObject AI_TankPrefab_3;
    public GameObject AI_TankPrefab_4;

    public GameObject AIControllerPrefab;
    public GameObject AIControllerPrefab_2;
    public GameObject AIControllerPrefab_3;
    public GameObject AIControllerPrefab_4;

    public Transform pawnSpawnTransform;
    #endregion variables
    #region startCode
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
    #endregion startCode
    #region states
    public void ActivateTitleScreenState()
    {
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
    public void ActivateWinScreenState() 
    {
        WinScreenState.SetActive(true);
    }
    public void QuitApp()
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        Application.Quit();
        Debug.Log("Quit");
    }
    #endregion states
    #region GameStates
    public void SinglePlayerState() 
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        DeactivateCanvases();

        PlayerTwoUI.SetActive(false);

        //correct cameras
        cameraPlayerTwo.SetActive(false);
        cameraPlayerOne.SetActive(false);
        singlePlayerCamera.SetActive(true);

        TwoPlayerVariable = false;
        
        if (tankPrefabTwo != null)
        {
            tankPrefabTwo.SetActive(false);
        }
        //Debug.Log("One Player Playing");
    }
    public void TwoPlayerGameState() 
    {
        SFX_Manager.instance.PlayClickSound(clickSound, 1f);
        DeactivateCanvases();

        PlayerTwoUI.SetActive(true);

        //Correct Cameras
        singlePlayerCamera.SetActive(false);
        cameraPlayerTwo.SetActive(true);
        cameraPlayerOne.SetActive(true);
        
        //This variable
        TwoPlayerVariable = true;
        
        if (tankPrefabTwo != null) 
        {
            SpawnPlayerTwo();
        }
        //Debug.Log("Two Players Playing!");
    }
    #endregion GameStates
    public void SecondPlayerActive() 
    {
        //This variable
        TwoPlayerVariable = true;

        tankPrefabTwo.SetActive(true);
    }

    public void ActivatePawns() 
    {
        AI_TankPrefab.SetActive(true);
        AI_TankPrefab_2.SetActive(true);
        AI_TankPrefab_3.SetActive(true);
        AI_TankPrefab_4.SetActive(true);
    }

    public void RespawnAI_1() 
    {
        if (AI_TankPrefab != null)
        {
            //Debug.Log("AI_1 Back!");
            SpawnAI();
        }
    }
    public void RespawnAI_2()
    {
        if (AI_TankPrefab_2 != null)
        {
            //Debug.Log("AI_2 Back!");
            SpawnAI_2();
        }
    }
    public void RespawnAI_3()
    {
        if (AI_TankPrefab_3 != null)
        {
            //Debug.Log("AI_3 Back!");
            SpawnAI_3();
        }
    }
    public void RespawnAI_4()
    {
        if (AI_TankPrefab_4 != null)
        {
            //Debug.Log("AI_4 Back!");
            SpawnAI_4();
        }
    }
    public void RespawnAIs() 
    {
        RespawnAI_1();
        RespawnAI_2();
        RespawnAI_3();
        RespawnAI_4();
    }

    #region spawnCodes
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
            cameraPlayerOne.transform.parent = newPlayerObj.transform;
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

            cameraPlayerTwo.transform.parent = newPlayerObj.transform;
    }

    public void SpawnAI()
    {
        AI_TankPrefab.SetActive(true);
        AIControllerPrefab.SetActive(true);

        GameObject newAITank = Instantiate(AI_TankPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController = newAIController.GetComponent<AIController>();

        Pawn newAIPawn = newAITank.GetComponent<Pawn>();

        newAITank.AddComponent<PowerupManager>();

        newController.pawn = newAIPawn;
    }
    public void SpawnAI_2()
    {
        AI_TankPrefab_2.SetActive(true);
        AIControllerPrefab_2.SetActive(true);

        GameObject newAITank_2 = Instantiate(AI_TankPrefab_2, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController_2 = Instantiate(AIControllerPrefab_2, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController_2 = newAIController_2.GetComponent<AIController>();

        Pawn newAIPawn_2 = newAITank_2.GetComponent<Pawn>();

        newAITank_2.AddComponent<PowerupManager>();

        newController_2.pawn = newAIPawn_2;
    }

    public void SpawnAI_3()
    {
        AI_TankPrefab_3.SetActive(true);
        AIControllerPrefab_3.SetActive(true);

        GameObject newAITank_3 = Instantiate(AI_TankPrefab_3, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController_3 = Instantiate(AIControllerPrefab_3, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController_3 = newAIController_3.GetComponent<AIController>();

        Pawn newAIPawn_3 = newAITank_3.GetComponent<Pawn>();

        newAITank_3.AddComponent<PowerupManager>();

        newController_3.pawn = newAIPawn_3;
    }
    public void SpawnAI_4()
    {
        AI_TankPrefab_4.SetActive(true);
        AIControllerPrefab_4.SetActive(true);

        GameObject newAITank_4 = Instantiate(AI_TankPrefab_4, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAIController_4 = Instantiate(AIControllerPrefab_4, Vector3.zero, Quaternion.identity) as GameObject;

        Controller newController_4 = newAIController_4.GetComponent<AIController>();

        Pawn newAIPawn_4 = newAITank_4.GetComponent<Pawn>();

        newAITank_4.AddComponent<PowerupManager>();

        newController_4.pawn = newAIPawn_4;
    }
    #endregion spawnCodes

    public void DeactivateCanvases()
    {
        //Deactivate canvases en masse
        TitleScreenState.SetActive(false);
        LevelSelectState.SetActive(false);
        OptionsState.SetActive(false);
        GameOverState.SetActive(false);
        WinScreenState.SetActive(false);
    }
}
