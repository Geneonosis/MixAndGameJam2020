using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    private Animator animator;
    public GameObject redDuck;
    public GameObject blueDuck;
    public GameObject greenDuck;
    //public int numInTail;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<FollowerDetectionArea>())
        {
            //found a leader to follow, so start following them!
            GetComponent<NavMeshAgent>().SetDestination(other.gameObject.GetComponent<FollowerDetectionArea>().GetRandomPointInCollider());
            GetComponent<RandomWander>().enabled = false;
            //numInTail = other.gameObject.GetComponent<DuckTrail>().AddDuckling(this);

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
            //other.gameObject.GetComponent<DuckTrail>().RemoveDuckling();
        }
    }


    private void Start()
    {
        animator = this.gameObject.GetComponentInChildren<Animator>();
        animator.StopPlayback();
        animator.Play("DucklingWalk", 0, Random.Range(0f, 1f));
    }

    //private void OnDestroy()
    //{
    //    FindObjectOfType<DuckTrail>()
    //}

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
            //GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
            //GetComponent<RandomWander>().enabled = false;
        }
    }
}
