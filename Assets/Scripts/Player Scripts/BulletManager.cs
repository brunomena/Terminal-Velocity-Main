using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Pressing Space Key to fire a projectile
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            //Creates a copy of the projectile, the ideal here is using object pooling
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            //prevents the player from shootinmg an infinite amount of projectiles
            canShoot = false;
            //Cadency of bullets
            StartCoroutine("BulletDelay");
        }
    }

    //Sets the delays between bullets being fired
    IEnumerator BulletDelay()
    {

        //Time the player has to wait until he can shoot another bullet
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
