using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    public GameObject powerup1, powerup2;
    const int spawnInterval = 5;
    // Start is called before the first frame update
    void Start()
    {
        // TODO: SEND RANDOMIZER TO spawnPowerUp()
        // To avoid predictability, the powerup spawn time will be randomized after the first one...
        InvokeRepeating("spawnPowerUp", spawnInterval, spawnInterval* Random.value * 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // ... and the selected powerup is randomized, too!
    void spawnPowerUp()
    {
        Object pwr = powerup1;
        if (Random.value > 0.5)
        {
            pwr = powerup2;
        }
        // Ensuring the powerup is destroyied if not collected
        Destroy(Instantiate(pwr, transform.position, Quaternion.identity), spawnInterval);
    }
}
