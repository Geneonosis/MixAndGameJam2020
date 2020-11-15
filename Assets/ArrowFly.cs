using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFly : MonoBehaviour
{
    public float movementSpeed = 20;
    public float damageAmount;
    // Update is called once per frame
    void Update()
    {
        //fly off in facing forward direction
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
        //if detect collider, delete self
        //if detect enemy collider, hurt enemy
        //delete self after some time so dont go off forever
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("hit " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<Health>())
            collision.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
        Destroy(this.gameObject);
        
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("hit " + other.gameObject.name);
    //    Destroy(this.gameObject);
    //}


    public void Start()
    {
        Destroy(this.gameObject, 10);
    }
}
