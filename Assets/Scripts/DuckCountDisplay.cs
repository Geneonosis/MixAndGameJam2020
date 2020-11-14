using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DuckCountDisplay : MonoBehaviour
{
    public TextMeshProUGUI archerText;
    public TextMeshProUGUI mageText;
    public TextMeshProUGUI artilleryText;
    private DuckManager ducks;
    
    public void Start()
    {
        ducks = FindObjectOfType<DuckManager>();
    }

    public void FixedUpdate()
    {
        archerText.text = ducks.numArchers.ToString();
        mageText.text = ducks.numMages.ToString();
        artilleryText.text = ducks.numArtillery.ToString();

    }
}
