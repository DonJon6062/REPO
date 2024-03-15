using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Pawn
{
    private float TimeBetweenShots;
    private float ShotDelay; 

    // Start is called before the first frame update
    public override void Start()
    {
        float SecondsPerShot;
        if (fireRate <= 0)
        { 
            SecondsPerShot = Mathf.Infinity;
        }
        else
        {
            SecondsPerShot = 1/fireRate;
        }

        ShotDelay = SecondsPerShot;

        TimeBetweenShots = Time.time + ShotDelay;

        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveForward()
    {
        Debug.Log("Move Forward");
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    {
        Debug.Log("Move Backward");
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        Debug.Log("Rotate Clockwise");
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotate Counter-Clockwise");
        mover.Rotate(-turnSpeed);
    }

    public override void Shoot()
    {
        if (Time.time >= TimeBetweenShots)
        {
            shooter.Shoot(bulletPrefab, fireForce, damageDone, bulletLifespan);
            TimeBetweenShots = Time.time + ShotDelay;
        }
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        //get target vector
        Vector3 vectorToTarget = targetPosition - transform.position;

        //find rotation for the vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        
        //rotate but at a speed people can react to
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public override void MakeNoise()
    {
        if (NoiseMaker != null)
        {
            NoiseMaker.VolumeDistance = NoiseMakerVolume;
        }
    }

    public override void StopNoise()
    {
        if (NoiseMaker != null)
        {
            NoiseMaker.VolumeDistance = 0;
        }
    }
}