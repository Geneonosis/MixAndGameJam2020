using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMap : MonoBehaviour
{
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            transform.position = hit.point;
        }
    }
}
