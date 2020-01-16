using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bottoms : MonoBehaviour
{
    [SerializeField]
    private int MaxLevel = 12;
    public void OnStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void OnLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void OnQuit()
    {
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnNext()
    {
        int temp = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if(temp < MaxLevel)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(temp + 1);
            Time.timeScale = 1f;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}
