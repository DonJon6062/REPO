using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Guard, Chase, Flee, Patrol, Attack };
    public AIState currentState;
    private float lastStateChangeTime;
    public GameObject target;

    public Transform[] waypoints;
    public float WaypointStopDistance;
    private int CurrentWaypoint = 0;

    public float HearingDistance;
    public float FieldOfView;


    // Start is called before the first frame update
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
                IsCanSee(target);
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
    }

    protected void DoGuardState()
    {
        Debug.Log("Guarding");
        pawn.Shoot();
        Seek(target);
    }

    protected void DoChaseState() 
    {
        Debug.Log("Chasing");
        Seek(target);
    }

    protected void DoAttackState() 
    {
        //go to target
        Seek(target);
        //attack
        pawn.Shoot();
    }

    protected void DoPatrolState() 
    {
        if (waypoints.Length > CurrentWaypoint) 
        {
            //go to the waypoint
            Seek(waypoints[CurrentWaypoint]);
            //once close enough, go to the next waypoint
            if (Vector3.Distance(pawn.transform.position, waypoints[CurrentWaypoint].position) < WaypointStopDistance)
            {
                CurrentWaypoint++;
            }
            else
            { 
                RestartPatrol();
            }
        }
    }

    protected void RestartPatrol()
    {
        //set index back to 0
        CurrentWaypoint = 0;
    }
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            Debug.Log("True");
            return true;
        }
        else
        {
            Debug.Log("False");
            return false;
        }
    }

    public void Seek(GameObject target)
    {
        //rotate towards target
        pawn.RotateTowards(target.transform.position);
        //move to target
        pawn.MoveForward();
    }

    public void Seek(Transform targetTransform) 
    {
        //seek position of target tf
        Seek(targetTransform.gameObject);
    }

    public void TargetEnemy() 
    {
        if (GameManager.instance != null) 
        {
            //if there are players
            if (GameManager.instance.Players.Count > 0) 
            {
                TargetNearestTank();
            }
        }
    }

    protected bool IsHasTarget()
    {
        // return true if we have a target, false if we don't
        return (target != null);
    }

    public bool IsCanSee(GameObject target)
    {
        // Find the vector from the agent to the target
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
        float AngleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        Debug.Log(AngleToTarget);
        // if that angle is less than our field of view
        if (AngleToTarget < FieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool IsCanHear(GameObject target)
    { 
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();

        if (noiseMaker == null)
        {
            return false;
        }
        if (noiseMaker.VolumeDistance <= 0)
        {
            return false;
        }

        float totalDistance = noiseMaker.VolumeDistance = HearingDistance;

        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        { 
            return true;
        }
        else 
        {
            return false;
        }
    }

    protected void TargetNearestTank()
    {
        // Get a list of all the tanks (pawns)
        Pawn[] allTanks = Object.FindObjectsOfType<Pawn>();

        // Assume that the first tank is closest
        Pawn closestTank = allTanks[1];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTanks)
        {
            // If this one is closer than the closest
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                // It is the closest
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }

        // Target the closest tank
        target = closestTank.gameObject;
    }
    public virtual void ChangeState(AIState newState)
    {
        // Change the current state
        currentState = newState;
        // Save the time when we changed states
        lastStateChangeTime = Time.time;

    }
}
