using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPause : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
