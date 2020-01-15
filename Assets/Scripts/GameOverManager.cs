using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{


    public GameObject enemy;
    public GameObject player;
    public GameObject victory;
    public GameObject failure;

    public float fadeDuration = 2f;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((!enemy) && player)
        {
            victory.SetActive(true);
            timer = timer+=Time.deltaTime;
            victory.GetComponent<Image>().color = new Color(1,1,1, timer / fadeDuration);
            victory.GetComponentInChildren<Image>().color = new Color(1, 1, 1, timer / fadeDuration);
        }
        if(!player)
        {
            failure.SetActive(true);
            timer = timer += Time.deltaTime;
            failure.GetComponent<Image>().color = new Color(1, 1, 1, timer / fadeDuration);
            failure.GetComponentInChildren<Image>().color = new Color(1, 1, 1, timer / fadeDuration);
        }
    }
}
