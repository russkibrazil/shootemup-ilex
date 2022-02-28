using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
