using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    //[NonSerialized]
    public int numArchers;
    //[NonSerialized]
    public int numArtillery;
    //[NonSerialized]
    public int numMages;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //need to check if enemy was clicked

                AdultDuck[] adultDucks = FindObjectsOfType<AdultDuck>();
                foreach (AdultDuck duck in adultDucks)
                {
                    duck.SetDestination(hit.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) //right click to make ducks follow the player
        {
            //need to get the selected type first
            AdultDuck[] adultDucks = FindObjectsOfType<AdultDuck>();
            foreach (AdultDuck duck in adultDucks)
            {
                duck.SetDestination(this.gameObject.transform.position);
            }

        }
    }


}
