using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSceneButton : MonoBehaviour
{
    [SerializeField] GameObject canvas;


    public void Awake()
    {

    }
    public void DeactivateCanvas() 
    {
        if (gameObject != null) 
        {
            canvas.SetActive(false);
        }
    }
}
