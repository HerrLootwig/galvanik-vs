using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadNextLevel(int value)
    {
        SceneManager.LoadScene(value);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
