using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float currentSpeed = 5f;
    private float lifespan = 2.5f;
    private float lifetimer;
    // Start is called before the first frame update
    void OnEnable()
    {
        lifetimer = lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * currentSpeed * Time.deltaTime);

        lifetimer -= Time.deltaTime;
        if(lifetimer <= 0){
            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }
}
