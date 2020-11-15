using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCardEnabler : MonoBehaviour
{
    public GameObject EndCard;
    /// <summary>
    /// use this for the Mask Animation (add event) option 
    /// at the end of it's animation
    /// </summary>
    public void enableEndCard()
    {
        this.EndCard.SetActive(true);
    }
}
