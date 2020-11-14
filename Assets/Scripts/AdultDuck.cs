using System;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(RandomWander))]
public abstract class AdultDuck : MonoBehaviour
{
    public DUCKTYPES myType;
    private NavMeshAgent agent;
    private RandomWander wanderBehavior;
    public GameObject TargetToObject { get; private set; }
    [Range(0.01f, 10f)]
    public float range = 2f;
    
    public void OnDrawGizmosSelected()
    {
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

    public void SetDestination(Vector3 newPos)
    {
        wanderBehavior.enabled = false;
        this.currentState = State.MoveTowards;
        agent.SetDestination(newPos);
    }

    // Have the duck start moving toward the target destination.
    public void MoveToTarget(GameObject target)
    {
        this.TargetToObject = target;
        currentState = State.MoveTowards;
        SetDestination(target.transform.position);
    }

    public void RemoveTarget()
    {
        // remove the target to move towards
        TargetToObject = null;
        // update current state to idle.
        currentState = State.Idle;
        // make the agent stop.
        SetDestination( transform.position );
        // make the duck wander?
        wanderBehavior.enabled = true;  
    }
}
