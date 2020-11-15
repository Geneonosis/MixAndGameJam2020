﻿using System;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(RandomWander))]
public abstract class AdultDuck : MonoBehaviour
{
    public DUCKTYPES myType;
    internal NavMeshAgent agent;
    private RandomWander wanderBehavior;

    //Enemy gameobject to target.
    public GameObject Enemy { get; private set; }

    // target object to go after.
    public GameObject TargetToObject { get; private set; }
    private GameObject TargetVector3;
    [Range(0.01f, 10f)]
    public float range = 2f;

    public bool debugMode = false;
    
    public void OnDrawGizmos()
    {
        // if debug mode is enabled then show the gizmos
        if (!debugMode) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }

    /**
        Adult ducks should either be one of these state:
        Goto position (set by user)
        Following player
        Scan for enemies in range (this is basically the idle)
        Attack target (set by user)
     */
    public enum State
    {
        MoveTowards,
        Following,
        Idle,
        Attack
    }
    public State currentState = State.Idle;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderBehavior = GetComponent<RandomWander>();
        TargetVector3 = new GameObject();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Idle: Idle(); break;
            case State.MoveTowards: MoveTowards(); break;
            case State.Following: Following(); break;
            case State.Attack: Attack(); break;
        }
    }

    // Goto position (set by user)
    public void MoveTowards()
    {
        // basically do nothing since we're moving the navmesh agent already. 
        // unless of course this duck sees an enemy then that's how we control the state to attack?
    }

    public void StartFollowing(GameObject target)
    {
        // remove the target to move towards
        TargetToObject = target;
        // update current state to following.
        currentState = State.Following;
        // make the duck not wander
        wanderBehavior.enabled = false;
    }

    public void StartAttacking(GameObject target)
    {
        // remove the target to move towards
        TargetToObject = target;
        // update current state to following.
        currentState = State.Attack;
        // make the duck not wander
        wanderBehavior.enabled = false;
    }

    // Following player
    public void Following()
    {
        // follow the target unless the target has been set to null.
        if (TargetToObject != null)
            agent.SetDestination(TargetToObject.transform.position);
        else
            RemoveTarget();
    }

    //Scan for enemies in range (this is basically the idle)
    public void Idle()
    {
        // basically do nothing, until we hear something from the player?
        if (!wanderBehavior.enabled)
            wanderBehavior.enabled = true;
    }

    // Attack target (set by user)
    public abstract void Attack();

    [Obsolete("This script is obsolete please use MoveToTarget instead!")]
    public void SetDestination(Vector3 newPos)
    {
        MoveToTarget(newPos);
    }

    /// <summary>
    /// Have the duck start moving toward the target destination using GameObject
    /// </summary>
    /// <param name="target"></param>
    public void MoveToTarget(GameObject target)
    {
        wanderBehavior.enabled = false;
        TargetToObject = target;
        currentState = State.MoveTowards;
        agent.SetDestination(target.transform.position);
    }

    /// <summary>
    /// Overload function to handle Vector3 instead of GameObject
    /// </summary>
    /// <param name="target"></param>
    public void MoveToTarget(Vector3 target)
    {
        TargetVector3.transform.position = target;
        MoveToTarget(TargetVector3);
    }

    public void RemoveTarget()
    {
        // remove the target to move towards
        TargetToObject = null;
        // update current state to idle.
        currentState = State.Idle;
        // make the agent stop.
        MoveToTarget( transform.position );
        // make the duck wander?
        wanderBehavior.enabled = true;  
    }
}
