using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float healthLevel;

    public void TakeDamage(float amount)
    {
        healthLevel -= amount;
        if (healthLevel <= 0)
        {
            if(this.gameObject.tag == "Player")
            {
                this.gameObject.GetComponentInChildren<Camera>().transform.parent = null;
            }
            Destroy(this.gameObject);
        }
            
    }
}
