using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCardController : MonoBehaviour
{
    /// <summary>
    /// Reloads the current scene
    /// </summary>
    public void onRetryPress()
    {
        //retry will only work when the game is built
        Debug.Log("scene needs to exist in build list");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Loads the Main Menu
    /// </summary>
    public void onGetTheDuckOuttaHere()
    {
        SceneManager.LoadScene(1);
    }
}
