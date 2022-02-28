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
        InvokeRepeating("spawnNext", spawnInterval, spawnInterval*2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void spawnNext() {
        Instantiate(enemyT1, transform.position, Quaternion.identity);
    }
}
