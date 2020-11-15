using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject enemyToFollow = null;
    public bool setEnemy = false;


    // Update is called once per frame
    void Update()
    {
        
        //if (enemyToFollow != null && setEnemy == false)
        //{
        //    //TODO: set this game object as a child of the enemy object and then lock this function
        //    this.transform.parent = enemyToFollow?.transform;

        //    //TODO: lock this function
        //    setEnemy = true;
        //}

        //if (enemyToFollow == null)
        //{
        //    setEnemy = false;
        //}
    }
}
