using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AdultDuck : MonoBehaviour
{
    private NavMeshAgent agent;
    private RandomWander wanderBehavior;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderBehavior = GetComponent<RandomWander>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void SetDestination(Vector3 newPos)
    {
        wanderBehavior.enabled = false;
        agent.SetDestination(newPos);
    }

}
