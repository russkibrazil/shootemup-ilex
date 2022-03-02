using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaserMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // We should have a way to avoid leaks. So, make sure the lasers got destroyed after 5 sec
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Push the laser down
        transform.position -= Vector3.up;
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
