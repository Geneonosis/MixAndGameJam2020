using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeekAndAttack : MonoBehaviour
{
    //check if ducklings in range, if they are, turn off wander, and seek to destroy target

    //public void FixedUpdate()
    //{
        
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Follower>())
        {
            //found a duckling, go attack it!
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            GetComponent<RandomWander>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Follower>())
        {
            //No longer following duckling, so start wandering around randomly again.
            GetComponent<RandomWander>().enabled = true;
        }
    }
}
