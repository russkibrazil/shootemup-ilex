using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME Watch out for stacking powerups. Looks like the timer is not ticking properly
public class ShieldPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.tag == "enemy_laser")
        {
            Destroy(colliderObject.gameObject);
        }
    }
}
