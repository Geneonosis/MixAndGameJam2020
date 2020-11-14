using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used to change scenes at the end of a fade animation
/// Usage: add to component and in the animator assign to enable at end of animation
/// </summary>
public class FadeSceneChange : MonoBehaviour
{
    private void OnEnable()
    {
        loadTitleScene();
    }

    public void loadTitleScene()
    {
        SceneManager.LoadScene(1);
    }
}
