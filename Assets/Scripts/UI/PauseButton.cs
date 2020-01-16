using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject image;
    public GameObject victory;
    public GameObject failure;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
    }
    public void OnPause()
    {
        Time.timeScale = 0;
        image.SetActive(true);
    }

    public void OnContinue()
    {
        image.SetActive(false);
        
        if (timer >= 1)
        {
            Time.timeScale = 1f;           
        }

    }

    public void OnMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
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
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnRestart()
    {
        failure.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

}
