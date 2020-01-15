using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    // Start is called before the first frame update

    private float width;
    private float height;

    private float left;
    private float right;
    private float top;
    private float bottom;

    private float leftBorder;
    private float rightBorder;
    private float topBorder;
    private float downBorder;

    void Start()
    {
        Vector3 cornerPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(Camera.main.transform.position.z)));
        leftBorder = Camera.main.transform.position.x - (cornerPos.x - Camera.main.transform.position.x);
        rightBorder = cornerPos.x;
        topBorder = cornerPos.y;
        downBorder = Camera.main.transform.position.y - (cornerPos.y - Camera.main.transform.position.y);

        width = rightBorder - leftBorder;
        height = topBorder - downBorder;

        left = 0 - width / 2;
        right = width / 2;
        top = height / 2;
        bottom = 0 - height / 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getLeft()
    {
        return left;
    }

    public float getRight()
    {
        return right;
    }

    public float getTop()
    {
        return top;
    }

    public float getBottom()
    {
        return bottom;
    }
}
