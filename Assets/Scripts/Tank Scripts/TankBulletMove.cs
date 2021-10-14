using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletMove : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        //transform.Translate(transform.InverseTransformDirection(transform.forward) * Time.deltaTime * speed);
        Destroy(gameObject, 3.0f);
    }

}
