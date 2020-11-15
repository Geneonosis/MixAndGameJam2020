using UnityEngine;

public class MageDuck : AdultDuck
{
    public GameObject fireBall;
    private float _t = 0;
    public GameObject fireFrom;

    public override void Attack()
    {
        if (this.Enemy != null)
        {
            // need the definition on how this player attacks? Ranges? etc? damages? arch visibility? etc.
            if (Vector3.Distance(this.Enemy.transform.position, this.transform.position) < this.range)
            {
                //// do a line of sight to see if the enemy is in the range.
                //RaycastHit hit;
                //if (Physics.Linecast(this.transform.position, this.Enemy.transform.position, out hit))
                //{
                //    this.agent.isStopped = false;
                //}
                //else
                //{
                //Debug.Log("enemy in range for mage to atck");
                this.transform.LookAt(Enemy.transform.position);
                this.agent.isStopped = true;
                // begin shooting the target.
                _t += Time.deltaTime / fireRate;
                if (_t > 1)
                {
                    //Debug.Log("time for mage to attack");
                    _t = 0;
                    Instantiate(fireBall, fireFrom.transform.position, transform.rotation);
                }
                //}
                // Stop the duck from moving towards the enemy. at least stop moving the player.
            }
            else //enemy not in range, go towards it
            {
                this.agent.isStopped = false;
                this.agent.SetDestination(Enemy.transform.position);
            }
        }
        else
        {
            //Debug.Log("mage went back to idle");
            this.StartIdle();
        }
    }

    public void OnEnable()
    {
        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numMages++;

        this.range = 10;
        this.fireRate = 2;
    }

    public void OnDestroy()
    {

        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numMages--;

    }
}
