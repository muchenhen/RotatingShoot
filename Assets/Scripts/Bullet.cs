using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float MoveSpeed;
    int power;
    Rigidbody rigidbody;
    public Player Player;
    public Enemy Enemy;
    public ParticleSystem BoomVFX;
    public ParticleSystem BulletChange;
    public EnemyFeet EnemyFeet;
    public Screen realScreen;
    //屏幕
    private float width;
    private float height;

    private float left;
    private float right;
    private float top;
    private float bottom;


    public void Init(int power)
    {
        this.power = power;

    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = this.transform.forward * MoveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if( this.transform.position.y > realScreen.getTop()    +2 ||
            this.transform.position.x < realScreen.getLeft()   -2 ||
            this.transform.position.x > realScreen.getRight()  +2 ||
            this.transform.position.y < realScreen.getBottom() -2 )
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyCenter")
        {

            EnemyCenter enemyCenter = other.gameObject.GetComponent<EnemyCenter>();
            Instantiate(BoomVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(other.tag == "EnemyFeet")
        {
            this.rigidbody.velocity = Vector3.zero;

            Instantiate(BulletChange, transform.position, Quaternion.identity);

            GetComponent<Renderer>().material.shader = Shader.Find("Unlit/EnemyFeet");
            GetComponent<Renderer>().material.SetColor("_Color", EnemyFeet.GetComponent<Renderer>().material.GetColor("_Color"));
            GetComponent<SphereCollider>().isTrigger = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            this.transform.parent = Enemy.transform;
            this.tag = "BadBullet";
            
            //transform.RotateAround(Vector3.zero, Vector3.forward, Enemy.RotateSpeed * Time.deltaTime);
        }
        else if(other.tag == "BadBullet")
        {
            this.rigidbody.velocity = Vector3.zero;

            Instantiate(BulletChange, transform.position, Quaternion.identity);

            GetComponent<Renderer>().material.shader = Shader.Find("Unlit/EnemyFeet");
            GetComponent<Renderer>().material.SetColor("_Color", EnemyFeet.GetComponent<Renderer>().material.GetColor("_Color"));

            this.transform.parent = Enemy.transform;
            this.tag = "BadBullet";
        }
        else
        {
            return;
        }
    }

}
