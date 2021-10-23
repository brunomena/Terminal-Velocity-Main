using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float turnspeed = 30;
    private float horizontalInput;
    private float upInput;
    private float tiltInput;
    private Vector3 direction = new Vector3(0.5f, 1, 0);
    public int Health = 10;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        upInput = Input.GetAxis("Vertical");
        //tiltInput = Input.GetAxis("Vertical");


        //Code to move the player
        //Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Rotate the player in the X axis, also known as up and down here (left so that the controls are not inverted)
        transform.Rotate(Vector3.left * Time.deltaTime * turnspeed * upInput);
        //Rotate the player in the Y axis, side to side
        transform.Rotate(direction, Time.deltaTime * turnspeed * horizontalInput);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tank Bullet"))
        {
            Destroy(other.gameObject);
            Health -= 1;
            if (Health < 1)
            {
                gameManager.isGameActive = false;
                gameManager.GameOver();
            }
        }

    }
}
