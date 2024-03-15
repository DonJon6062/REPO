using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{

    // Variable for move speed
    public float moveSpeed;
    // Variable for turn speed
    public float turnSpeed;
    //var for fire rate
    public float fireRate;
    //var for fireforce
    public float fireForce;
    //var for fire rate
    //float secondsPerShot = 1 / shotsPerSecond;
    //var for damage done
    public float damageDone;
    //var for bullet lifespan
    public float bulletLifespan;
    //Var for holding Mover
    public Mover mover;
    //var for holding firerate
    public Shooter shooter;
    //var for shell prefab
    public GameObject bulletPrefab;
    //var for noisemaker
    public NoiseMaker NoiseMaker;
    //var for vol
    public float NoiseMakerVolume;

    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        NoiseMaker = GetComponent<NoiseMaker>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);

    public abstract void MakeNoise();

    public abstract void StopNoise();
}