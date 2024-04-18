using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegonePawn : MonoBehaviour
{
    [SerializeField] GameObject tankPresent;

    public void GoAwayPawn()
    {
        if (tankPresent != null)
        {
            tankPresent.SetActive(false);
        }
    }
}
