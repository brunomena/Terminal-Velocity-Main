using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    // The object we want to check the distance to
    [SerializeField] Transform target;

    // If the target is within this many units of us, it's in range
    [SerializeField] float range = 50;

    // Remembers if the target was in range on the previous frame.
    private bool targetWasInRange = false;

    public GameObject tankBullet;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if the player is in range of the tank
        IsInRange();
    }


        void IsInRange()
        {
            // Calculate the distance between the objects
            var distance = (target.position - transform.position).magnitude;

            if (distance <= range && targetWasInRange == false)
            {
                // If the object is now in range, and wasn't before, log it
                Debug.LogFormat("Target {0} entered range!", target.name);

            // Remember that it's in range for next frame
            targetWasInRange = true;

            }
            else if (distance > range && targetWasInRange == true)
            {
                // If the object is not in range, but was before, log it
                Debug.LogFormat("Target {0} exited range!", target.name);

                // Remember that it's no longer in range for next frame
                targetWasInRange = false;
            }


        if (canShoot && targetWasInRange)
        {
            Vector3 playerPos = new Vector3(target.position.x, target.position.y, target.position.z+8);
            Instantiate(tankBullet, transform.position, Quaternion.LookRotation(playerPos));
            //Quaternion.LookRotation(playerPos)
            canShoot = false;
            //Cadency of bullets
            StartCoroutine("BulletDelay");
        }


    }
    IEnumerator BulletDelay()
    {

        //Time the player has to wait until he can shoot another bullet
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
