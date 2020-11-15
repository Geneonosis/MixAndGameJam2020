using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;
    public GameObject explosionPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * thrust);
        rb.AddForce(transform.forward * thrust);
        Invoke("SpawnExplosion", 2.8f);
        Destroy(this.gameObject, 3);
    }

    void SpawnExplosion()
    {
        Instantiate(explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
