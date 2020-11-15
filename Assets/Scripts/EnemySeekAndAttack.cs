using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySeekAndAttack : MonoBehaviour
{

    public void FixedUpdate()
    {
        Attack();
    }

    private float _t = 0;
    public GameObject target;
    private float sightRange = 5;
    public float attackRange = 1;
    private NavMeshAgent agent;
    public float fireRate = 1;
    public float damageAmount = 2;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }   
    public void Attack()
    {

        if (target != null)
        {
            // need the definition on how this player attacks? Ranges? etc? damages? arch visibility? etc.
            if (Vector3.Distance(this.target.transform.position, this.transform.position) < attackRange)
            {
                this.transform.LookAt(target.transform.position);
                //this.agent.isStopped = true;
                // begin attacking the target.
                _t += Time.deltaTime / fireRate;
                if (_t > 1)
                {
                    //Debug.Log("enemy attacking target " + target.gameObject.name);
                    _t = 0;
                    target.GetComponent<Health>().TakeDamage(damageAmount);
                }

            }
            else //target not in attack range, move towards it
            {
                //Debug.Log("enemy moving towards target " + target.gameObject.name);
                //Vector3 newPos;
                //newPos = new Vector3(target.transform.position.x, 0, target.transform.position.z);
                this.agent.isStopped = false;
                agent.SetDestination(target.transform.position);
            }
        }
        else
        {
            //seek targets
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, sightRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.GetComponent<Follower>()
                    || hitCollider.gameObject.GetComponent<ArtilleryDuck>()
                    || hitCollider.gameObject.GetComponent<MageDuck>()
                    || hitCollider.gameObject.GetComponent<ArcheryDuck>()
                    || hitCollider.gameObject.GetComponent<PlayerController>())
                { //set the target
                    //Debug.Log("enemy found target in sight range " + hitCollider.gameObject.name);
                    target = hitCollider.gameObject;
                    break;
                }

            }

        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("en on triger entered");
    //    if (other.gameObject.GetComponent<Follower>())
    //    {
    //        //found a duckling, go attack it!
    //        GetComponent<NavMeshAgent>().SetDestination(other.gameObject.transform.position);
    //        GetComponent<RandomWander>().enabled = false;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Follower>())
    //    {
    //        //No longer following duckling, so start wandering around randomly again.
    //        GetComponent<RandomWander>().enabled = true;
    //    }
    //}
}
