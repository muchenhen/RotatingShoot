using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    float speed = 5f;

    [SerializeField]
    Screen realScreen;
    

    public int Power;
    public float ShootDelayTime;
    public ParticleSystem SuperEvilDeath;

    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {

        //System.Threading.Thread.Sleep(1000);
        //transform.position = new Vector3(0, -10f, 0);
        //InvokeRepeating("Move", 1.0f, 0.03f);
        InvokeRepeating("Shoot", 2.0f, ShootDelayTime);

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        timer += Time.deltaTime;
        if(timer >=1)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);//获取需要移动物体的世界转屏幕坐标

        Vector3 mousePos = Input.mousePosition;//获取鼠标位置

        mousePos.z = screenPos.z;//因为鼠标只有X，Y轴，所以要赋予给鼠标Z轴

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);//把鼠标的屏幕坐标转换成世界坐标

        Vector3 distance = mouseWorldPos - transform.position;

        Vector3 targetPlayerPos = mouseWorldPos + distance;
        Vector3 tempPos = Vector3.Lerp(transform.position, targetPlayerPos, speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(tempPos.x, realScreen.getLeft(), realScreen.getRight()), 
                                         Mathf.Clamp(tempPos.y, realScreen.getBottom(), realScreen.getTop()), 
                                                     tempPos.z);

       
    }
    void Rotate()
    {
        this.transform.LookAt(Vector3.zero);//始终朝向屏幕中心
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        
    }
        
    public void HitTest()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BadBullet" || other.tag=="EnemyFeet")
        {
            Instantiate(SuperEvilDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }

}
