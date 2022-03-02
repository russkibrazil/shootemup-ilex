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
        if (Input.GetKey(KeyCode.Q))
        {
            fireSecondary();
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
    
    void fireSecondary()
    {
        Quaternion quatRotateLeft = Quaternion.Euler(0, 0, 30);
        Quaternion quatRotateRight = Quaternion.Euler(0, 0, -30);
        Instantiate(laserPrefab, this.gameObject.transform.position, quatRotateLeft);
        Instantiate(laserPrefab, this.gameObject.transform.position, quatRotateRight);
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
