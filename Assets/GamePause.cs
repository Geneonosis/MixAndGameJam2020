using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject EscapeMenu;
    public bool pause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            if (pause)
            {
                this.EscapeMenu.SetActive(pause);
                Time.timeScale = 0;
            }
            else
            {
                this.EscapeMenu.SetActive(pause);
                Time.timeScale = 1;
            }
        }
    }
}
