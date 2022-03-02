using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyT1, enemyT2, enemyT3;
    public float spawnInterval = 3;
    // Start is called before the first frame update
    void Start()
    {
        // Spawn enemies repeatedly
        InvokeRepeating("spawnNext", spawnInterval, spawnInterval*2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // The enemy type spawned is random, but each type get spawned at specific points
    void spawnNext() {
        float random = Random.value * 3;
        if (random < 1)
        {
            Instantiate(enemyT1, (Vector2)transform.position - (2 * Vector2.up), Quaternion.identity);
            return;
        }
        if (random < 2)
        {
            Instantiate(enemyT2, (Vector2)transform.position - Vector2.up, Quaternion.identity);
            return;
        }
        Instantiate(enemyT3, transform.position, Quaternion.identity);
    }
}
