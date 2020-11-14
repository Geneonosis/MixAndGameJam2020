using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<FollowerDetectionArea>())
        {
            //found a leader to follow, so start following them!
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            GetComponent<RandomWander>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<FollowerDetectionArea>())
        {
            //No longer following leader, so start wandering around randomly again.
            GetComponent<RandomWander>().enabled = true;
        }
    }
}
