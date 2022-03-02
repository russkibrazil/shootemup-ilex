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
    private int actualHp;
    // Start is called before the first frame update
    void Start()
    {
        // just a safety measure against invalid values
        if (enemy1Hp < 1)
            enemy1Hp = 1;
        actualHp = enemy1Hp;
    }

    // This rustic AI is capable of moving to the right (a little slower than
    // the player can) and shooting "whenever" it wants
    void FixedUpdate()
    {
        dest = (Vector2)transform.position + (Vector2.right * 0.8f);
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
    
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        // When the player laser hits a enemy ship, the enemy life is
        // decreased and the ship removed when the enemy is dead
        if (colliderObject.tag == "player_laser")
        {
            Destroy(colliderObject.gameObject);
            if (takeHitAndDie())
            {
                GameManager.instance.addScore(enemy1Points);
                Destroy(this.gameObject);            
            }
        }
    }
    
    // This method remove 1 HP and return *true* if the enemy life equals zero (therefore, is dead)
    bool takeHitAndDie()
    {
        return --actualHp == 0;
    }
}
