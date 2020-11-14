using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    //pick up item has a type which determines what the duckling should evolve into
    public enum itemType { red, blue, green };
    public itemType myType;

}
