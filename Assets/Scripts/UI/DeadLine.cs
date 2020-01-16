using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLine : MonoBehaviour
{
    [SerializeField]
    public float deadTime = 7f;




    public float width;
    public float widthSave;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        widthSave = width;
        speed = widthSave / deadTime;

    }

    private void Update()
    {
        if(width>0)
        {
            WidthChange();
        }
        else if(width<0)
        {
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 10f);

        }
    }

    public void WidthChange()
    {
        width -= speed * Time.deltaTime;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 10f);
    }

    public void WidthReset()
    {
        width = widthSave;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(widthSave, 10f);
    }


}
