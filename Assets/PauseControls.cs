using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
    public GameObject tutorial;
    
    public void onRetryPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onTutorialPopup()
    {
        Time.timeScale = 0;
        tutorial.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnQuitGame()
    {
        SceneManager.LoadScene(1);
    }
}
