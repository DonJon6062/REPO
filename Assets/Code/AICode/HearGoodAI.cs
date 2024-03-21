using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearGoodAI : AIController
{
    public override void Start()
    {
        ChangeState(AIState.Guard);

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
        Debug.Log("Making Decisions");

        switch (currentState)
        {
            //if target is seen
            case AIState.Guard:
                {
                    DoGuardState();
                    IsCanHear(target);
                    ChangeState(AIState.Flee);
                    break;
                }



            case AIState.Chase:
                //if targetting someone
                if (IsHasTarget())
                {
                    //follow an enemy
                    DoChaseState();
                }
                else
                {
                    TargetEnemy();
                }
                //if close enough atack
                if (IsDistanceLessThan(target, 7))
                {
                    ChangeState(AIState.Attack);
                }
                //if further go back to guarding
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Guard);
                    DoPatrolState();
                }
                break;

            case AIState.Flee:
                //Move away from visible enemies
                if (IsCanSee(target))
                {
                    Flee(target);
                }
                else
                {
                    ChangeState(AIState.Patrol);
                }
                break;

            case AIState.Attack:
                //shoot enemies
                DoAttackState();
                //check for transition
                if (IsDistanceLessThan(target, 7))
                {
                    ChangeState(AIState.Chase);
                }
                break;

            case AIState.Patrol:
                //patrol the arena
                DoPatrolState();
                break;

        }

//        protected bool IsCanHear(GameObject target)
//        {
//            NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();

//            if (noiseMaker == null)
//            {
//                return false;
//            }
//            if (noiseMaker.VolumeDistance <= 0)
//            {
//                return false;
//            }

//            float totalDistance = noiseMaker.VolumeDistance = HearingDistance;

//            if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        protected void TargetNearestTank()
//        {
//            // Get a list of all the tanks (pawns)
//            Pawn[] allTanks = Object.FindObjectsOfType<Pawn>();

//            // Assume that the first tank is closest
//            Pawn closestTank = allTanks[1];
//            float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

//            // Iterate through them one at a time
//            foreach (Pawn tank in allTanks)
//            {
//                // If this one is closer than the closest
//                if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
//                {
//                    // It is the closest
//                    closestTank = tank;
//                    closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
//                }
//            }

//            // Target the closest tank
//            target = closestTank.gameObject;
//        }
//    public virtual void ChangeState(AIState newState)
//    {
//        // Change the current state
//        currentState = newState;
//        // Save the time when we changed states
//        lastStateChangeTime = Time.time;

//    }
    }
}
