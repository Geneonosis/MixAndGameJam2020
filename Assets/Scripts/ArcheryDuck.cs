﻿using UnityEngine;

public class ArcheryDuck : AdultDuck
{
    public GameObject arrows;
    public float fireRate = 0.5f;
    private float _t = 0;

    public override void Attack()
    {
        if (this.Enemy != null)
        {
            // need the definition on how this player attacks? Ranges? etc? damages? arch visibility? etc.
            if (Vector3.Distance(this.Enemy.transform.position, this.transform.position) < this.range)
            {
                // do a line of sight to see if the enemy is in the range.
                RaycastHit hit;
                if (Physics.Linecast(this.transform.position, this.Enemy.transform.position, out hit))
                {
                    this.agent.isStopped = false;
                }
                else
                {
                    this.agent.isStopped = true;
                    // begin shooting the target.
                    _t += Time.deltaTime / fireRate;
                    if (_t > 1)
                    {
                        _t = 0;
                        Instantiate(arrows, transform.position, transform.rotation);
                    }
                }
                // Stop the duck from moving towards the enemy. at least stop moving the player.

            }
        }
        else
        {
            this.currentState = State.Idle;
        }
    }

    public void OnEnable()
    { 
        if( FindObjectOfType<DuckManager>() is DuckManager dm )
            dm.numArchers++;
    }

    public void OnDestroy()
    {
        if( FindObjectOfType<DuckManager>() is DuckManager dm )
            dm.numArchers--;
    }
}
