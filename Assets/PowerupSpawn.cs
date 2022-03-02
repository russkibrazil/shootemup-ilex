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
        // From time to time, we will drop an item to the player...
        InvokeRepeating("spawnPowerUp", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPowerUp()
    {
        // ... but the drop only occurs if a lucky value is above the threshold
        if (Random.value > 0.75)
        {
            // ... and the selected powerup is randomized, too!
            Object pwr = powerup1;
            if (Random.value > 0.5)
            {
                pwr = powerup2;
            }
            int left = Random.value < 0.5f ? 1 : 0-1;
            Vector3 dropPosition = new Vector3(Random.value * 7 * left, transform.position.y, 0);
            // Ensuring the powerup is destroyied if not collected
            Destroy(Instantiate(pwr, dropPosition, Quaternion.identity), spawnInterval);        
        }
    }
}
