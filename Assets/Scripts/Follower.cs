using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public GameObject redDuck;
    public GameObject blueDuck;
    public GameObject greenDuck;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<FollowerDetectionArea>())
        {
            //found a leader to follow, so start following them!
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            GetComponent<RandomWander>().enabled = false;
        }
        else if (other.gameObject.GetComponent<EnemySeekAndAttack>())
        {
            Debug.Log("ouch! duckling got hit!");
            Destroy(this.gameObject);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PickUpItem>())
        {
            //found a pickup item, lets evolve into a adult duckling based on the type of item
            switch (other.gameObject.GetComponent<PickUpItem>().myType)
            {
                case PickUpItem.itemType.blue:
                    Instantiate(blueDuck, this.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                    break;
                case PickUpItem.itemType.green:
                    Instantiate(greenDuck, this.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                    break;
                case PickUpItem.itemType.red:
                    Instantiate(redDuck, this.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                    break;
                default:
                    Debug.Log("did not find a valid item type on pick up");
                    break;
            }
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            GetComponent<RandomWander>().enabled = false;
        }
    }
}
