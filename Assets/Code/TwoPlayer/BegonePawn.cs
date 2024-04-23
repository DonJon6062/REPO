using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegonePawn : MonoBehaviour
{
    [SerializeField] GameObject tankPresent;
    //[SerializeField] GameObject tankController;

    public void GoAwayPawn()
    {
        if (tankPresent != null)
        {
            Debug.Log("Tank Down!");
            tankPresent.SetActive(false);
        }
    }
}
