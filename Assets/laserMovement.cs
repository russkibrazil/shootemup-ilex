using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // We should have a way to avoid leaks. So, make sure the lasers got destroyed after 2 sec
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up;
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
