using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItems : MonoBehaviour
{
    [SerializeField]
    public int LevelID;

    public void OnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelID);
        
        Time.timeScale = 1f;

    }

}
