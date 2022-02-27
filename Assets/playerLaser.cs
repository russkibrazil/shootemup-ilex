using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space")) {
          fireLaser ();
        }
    }
    /*
    * Function to instantiate a projectile. To avoid memory leak, it's desctruction will be timed
    * @method fireLaser
    */
    void fireLaser() {
       Destroy(
           Instantiate (laserPrefab, this.gameObject.transform.position, Quaternion.identity),
           1
       );
    }
}