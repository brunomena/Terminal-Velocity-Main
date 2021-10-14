using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        //Makes the projectile move forward in the local direction of the bulletmanager, not Global as it would be standard
        transform.Translate(transform.InverseTransformDirection(transform.forward) * Time.deltaTime * speed);
        //Destroys projectiles after 2 seconds, the ideal here would be using object pooling
        Destroy(gameObject, 2.0f);
    }

    //ou eu utilizo transform.translate ou força e descubro a direção
    //bulletRb.AddForce(transform.up* speed * Time.deltaTime);
    //bulletPrefab.transform.Translate(transform.forward * speed * Time.deltaTime);
}
