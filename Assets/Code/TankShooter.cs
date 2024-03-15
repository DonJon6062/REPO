using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public Transform firePointTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Shoot(GameObject bulletPrefab, float fireForce, float damageDone, float lifespan)
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePointTransform.position, firePointTransform.rotation) as GameObject;

        DamageOnHit damageOnHit = newBullet.GetComponent <DamageOnHit>();

        if (damageOnHit != null)
        {
            damageOnHit.damageDone = damageDone;
            damageOnHit.owner = GetComponent <Pawn>();
        }

        Rigidbody rb = newBullet.GetComponent <Rigidbody>();

        if (rb != null) 
        {
            rb.AddForce(firePointTransform.forward * fireForce);
        }

        Destroy(newBullet, lifespan);
    }


}
