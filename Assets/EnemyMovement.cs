using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    const float STEP_ANIMATION = 0.1f;
    public GameObject laserEnemy1;
    public int enemy1Hp = 1;
    public int enemy1Points = 1;
    private Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dest = (Vector2)transform.position + Vector2.right;
        Vector2 p = Vector2.MoveTowards(transform.position, dest, STEP_ANIMATION);
        GetComponent<Rigidbody2D>().MovePosition(p);
        if (Random.value >= 0.9)
        {
            Instantiate(laserEnemy1, this.gameObject.transform.position, Quaternion.identity);
        }
    }
    
    void OnBecameInvisible(){
        Destroy(this.gameObject);
    }
    

}
