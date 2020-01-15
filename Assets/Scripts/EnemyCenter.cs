using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCenter : MonoBehaviour
{
    [SerializeField]
    public float health = 0f;

    public float maxHealth = 200f;

    public Bullet bullet;

    float damege = 10f;

    public Slider Hp;

    public Material material;
    public Material materialTarget;
    public Material materialBullet;

    Color colorPerHit;
    Color rimColorPerHit;

    Color color;
    Color rimColor;
    Color colorTarget;
    Color rimTarget;
    Color colorBullet;

    public float lightSpeed = 0.02f;

    public bool IsOver = false;

    // Start is called before the first frame update
    void Start()
    {
        damege = bullet.damage;

        Hp.maxValue = maxHealth;

        material.SetFloat("_AlphaRange", 0f);

        colorTarget = materialTarget.GetColor("_Color");
        rimTarget = materialTarget.GetColor("_RimColor");
        colorBullet = materialBullet.GetColor("_Color");

        material.SetColor("_Color", colorTarget);
        material.SetColor("_RimColor", rimTarget);

        color = material.GetColor("_Color");
        rimColor = material.GetColor("_RimColor");



        colorPerHit = (colorBullet - color) / 100;
        colorPerHit.a = 0;

        rimColorPerHit = (colorBullet - rimColor) / 100;
        rimColorPerHit.a = 0; 


    }

    // Update is called once per frame
    void Update()
    {
        Hp.value = health;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Bullet"))
        {
            ColorChange();
            if (health <= maxHealth)
            {
                health += 1f;
            }
            else
            {
                material.SetColor("_Color", colorBullet);
                material.SetFloat("_AlphaRange", 1f);
                material.SetColor("_RimColor", colorBullet);
                IsOver = true;
            }
        }
        else
        {
            return;
        }
    }

    void ColorChange()
    {
        color = material.GetColor("_Color");
        if (color.r < colorBullet.r || color.g < colorBullet.g)
        {
            material.SetColor("_Color", colorPerHit + color);
        } 
        else if(material.GetFloat("_AlphaRange")<1)
        {
            float temp=material.GetFloat("_AlphaRange");
            material.SetFloat("_AlphaRange", temp + lightSpeed);
        }
        else
        {

            return;
        }
    }
}
