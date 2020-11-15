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
            Destroy(this.gameObject);
    }


}
