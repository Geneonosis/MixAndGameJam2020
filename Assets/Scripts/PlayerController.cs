using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float movementSpeed = 5;
    

    public void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);

        transform.position += (transform.forward * Input.GetAxis("Vertical")) * Time.deltaTime * movementSpeed;
    }


}
