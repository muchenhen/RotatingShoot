using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] badNums;

    public GameObject enemy;

    public string x = "0";
    // Start is called before the first frame update
    void Start()
    {
        badNums = GameObject.FindGameObjectsWithTag("BadBullet");
        x = badNums.Length.ToString();
        print(x);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy)
        {
            badNums = GameObject.FindGameObjectsWithTag("BadBullet");
            badNums.Length.ToString();
            GetComponent<Text>().text = badNums.Length.ToString();
        }
    }
}
