using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPawn : MonoBehaviour
{
    [SerializeField] GameObject pawnNotPresesnt;

    public void SpawnThePawn() 
    {
        if (pawnNotPresesnt == null) 
        {
            pawnNotPresesnt.SetActive(true);
        }
    }
}
