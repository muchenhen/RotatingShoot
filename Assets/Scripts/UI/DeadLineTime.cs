using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLineTime : MonoBehaviour
{

    public int Time=5;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = Time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Time.ToString();
    }

    public void SetTime(int tempTime)
    {
        Time = tempTime;
    }
}
