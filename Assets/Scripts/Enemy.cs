using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float RotateSpeed = 10f;

    [SerializeField]
    public EnemyCenter enemyCenter;

    [SerializeField]
    public ParticleSystem EnemyBoomVFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
        if(enemyCenter.IsOver)
        {
            Instantiate(EnemyBoomVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
