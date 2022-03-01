using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab, specialWeaponPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey("space"))
        {
            fireLaser();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fireSpecial();
        }
    }

    void fireLaser()
    {
       Instantiate(laserPrefab, this.gameObject.transform.position, Quaternion.identity);
    }
    
    void fireSpecial()
    {
        int playerState = GetComponent<playerMovement>().getPlayerState();
        if (playerState == (int) playerMovement.PlayerState.WeaponBoost)
        {
            Instantiate(specialWeaponPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
