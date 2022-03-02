using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour
{
    private bool angulated, towardsLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        // We should have a way to avoid leaks. So, make sure the lasers got destroyed after 2 sec
        Destroy(this.gameObject, 2);
        if (!(Quaternion.identity == transform.rotation))
        {
            angulated = true;
            if (transform.rotation.eulerAngles.z < 180)
            {
                towardsLeft = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (angulated)
        {
            if (towardsLeft)
            {
                transform.position -= Vector3.right;
            }
            else
            {
                transform.position += Vector3.right;
            }
        }
        transform.position += Vector3.up;
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
