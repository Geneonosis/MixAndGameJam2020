using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    [NonSerialized]
    public int numArchers;
    [NonSerialized]
    public int numArtillery;
    [NonSerialized]
    public int numMages;
    private CommandingUIScroller selection;

    public void Start()
    {
        selection = FindObjectOfType<CommandingUIScroller>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                AdultDuck[] adultDucks = FindObjectsOfType<AdultDuck>();
                //need to check if enemy was clicked
                if (hit.transform.tag == "Enemy")
                {   
                    foreach (AdultDuck duck in adultDucks)
                    {
                        if (duck.myType == selection.commandingDuck || selection.commandingDuck == DUCKTYPES.ALL)
                            duck.StartAttacking(hit.transform.gameObject);
                    }
                }
                else
                { 
                    foreach (AdultDuck duck in adultDucks)
                    {
                        if (duck.myType == selection.commandingDuck || selection.commandingDuck == DUCKTYPES.ALL)
                            duck.SetDestination(hit.point);
                    }

                }
            }
        }

        if (Input.GetMouseButtonDown(1)) //right click to make ducks follow the player
        {
            AdultDuck[] adultDucks = FindObjectsOfType<AdultDuck>();
            foreach (AdultDuck duck in adultDucks)
            {
                if (duck.myType == selection.commandingDuck || selection.commandingDuck == DUCKTYPES.ALL)
                    duck.StartFollowing(this.gameObject);
            }

        }
    }


}
