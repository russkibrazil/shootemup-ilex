using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Let's find the player and activate the shield only if the player is alive
        player = GameObject.FindWithTag("Player");
        if (player == null)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // the shield sticks with the player ship
        transform.position = player.transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        // if a enemy laser hits the shield, the laser is destroyied
        if (colliderObject.tag == "enemy_laser")
        {
            Destroy(colliderObject.gameObject);
        }
    }
}
