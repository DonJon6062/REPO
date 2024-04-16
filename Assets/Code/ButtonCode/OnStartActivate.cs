using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartActivate : MonoBehaviour
{
    public void ChangeToTitleScreen()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateLevelSelectState();
            Debug.Log("Changed to LevelSelect!");
        }
    }
}
