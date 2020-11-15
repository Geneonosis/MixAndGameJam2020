using UnityEngine;

public class ArtilleryDuck : AdultDuck
{
    public GameObject bombPref;
    public GameObject shootFrom;
    private float _t = 0;

    private void Start()
    {
        if( bombPref == null)
        {
            Debug.LogError("This gameobject does not have Bomb prefab set! Disabling!");
            this.enabled = false;
        }
    }

    public override void Attack()
    {
        if (bombPref == null) return;

        if (Enemy != null)
        {

            if( Vector3.Distance(Enemy.transform.position, transform.position) < range)
            {
                _t += Time.deltaTime / fireRate;
                if (_t > 1)
                {
                    _t = 0;
                    ShootProjectile();
                }
            }
            else
            {
                agent.SetDestination(Enemy.transform.position);
            }
            //agent.updateRotation = true;

            // Get Angle in Radians
            //float AngleRad = Mathf.Atan2(Enemy.transform.position.y - transform.position.y, Enemy.transform.position.x - transform.position.x);
            //// Get Angle in Degrees
            //float AngleDeg = (180 / Mathf.PI) * AngleRad;
            //// Rotate Object
            //this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        }
        else
        {
            currentState = State.Idle;
        }
    }

    private void ShootProjectile()
    {
        Vector3 pos = shootFrom?.transform.position ?? transform.position;
        Quaternion rot = shootFrom?.transform.rotation ?? transform.rotation;
        Instantiate(bombPref, pos, rot);
    }

    public void OnEnable()
    {
        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numArtillery++;
    }

    public void OnDestroy()
    {

        if (FindObjectOfType<DuckManager>() is DuckManager dm)
            dm.numArtillery--;

    }
}
