using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float powerupTimer;


    public void OnTriggerEnter(Collider other)
    {
        Pawn pawn = other.GetComponent<Pawn>();
        if (pawn != null) 
        {
            StartCoroutine(SpeedUp(pawn));
        }
    }

    public IEnumerator SpeedUp(Pawn pawn) 
    {
        ActivatePowerup(pawn);
        yield return new WaitForSeconds(powerupTimer);
        DeactivatePowerup(pawn);
        Destroy(gameObject);
    }

    public void ActivatePowerup(Pawn pawn) 
    {
        pawn.AdjustSpeed(speed);
    }

    public void DeactivatePowerup(Pawn pawn)
    {
        pawn.AdjustSpeed(-speed);
    }
}
