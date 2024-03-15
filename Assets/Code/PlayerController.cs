using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;

    // Start is called before the first frame update
    public override void Start()
    {
        if (GameManager.instance != null)
        { 
            GameManager.instance.Players.Add(this);
        }
        base.Start();
    }
    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();

        base.Update();
    }
    public override void ProcessInputs()
    {
        base.ProcessInputs();

        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKeyDown(shootKey)) 
        {
            pawn.Shoot();
            pawn.MakeNoise();
        }

        if (!Input.GetKey(moveForwardKey) && !Input.GetKey(moveBackwardKey) && !Input.GetKey(rotateClockwiseKey) && !Input.GetKey(rotateCounterClockwiseKey) && !Input.GetKey(shootKey)) 
        {
            pawn.StopNoise();
        }
    }

    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.Players != null) 
            {
                GameManager.instance.Players.Remove(this);
            }
        }
    }
}