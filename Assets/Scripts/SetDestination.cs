using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetDestination : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                AdultDuck[] adultDucks = FindObjectsOfType<AdultDuck>();
                foreach (AdultDuck duck in adultDucks)
                {
                    duck.SetDestination(hit.point);
                }
            }
        }
    }


}
