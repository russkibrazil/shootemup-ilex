using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    const float STEP_ANIMATION = 0.25f;
    public enum PlayerState
    {
        Alive,
        Dead,
        Respawn,
        Shielded,
        WeaponBoost,
        ShieldAndWeaponBoost
    }
    public GameObject shield;
    private Vector2 dest = Vector2.zero;
    private PlayerState state = PlayerState.Respawn;
    private Queue<PlayerState> powerupQueue;
    
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        state = PlayerState.Alive;
        powerupQueue = new Queue<PlayerState>();
    }

    // Update is called once per frame;
    void Update()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, STEP_ANIMATION);
        GetComponent<Rigidbody2D>().MovePosition(p);
        
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && valid(Vector2.right) && insideScreen(Vector2.right))
            dest = (Vector2)transform.position + Vector2.right;
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && valid(-Vector2.right) && insideScreen(-Vector2.right))
            dest = (Vector2)transform.position - Vector2.right;
    }
    
    // When something hits the player, it's important to know what kind of item hit.
    // If it is a enemy projectile and the player is not shielded, then the player dies (and respawns)
    // If it is a powerup, we detect what powerup hit the player and activate its power
    void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.tag == "enemy_laser")
        {
            if (state != PlayerState.Shielded)
                destroyPlayer();
            return;
        }
        if (colliderObject.tag == "powerup")
        {
            activatePowerup(colliderObject);
            return;
        }
    }
    
    void OnDisable()
    {
        // Show the player again after the spaceship has exploded
        Invoke("respawnPlayer", 4.0f);
        state = PlayerState.Respawn;
    }
    
    bool insideScreen(Vector2 pos) {
        Vector2 nextPos = (Vector2)transform.position + pos;
        //cam = UnityEngine.Camera.main;
        return (nextPos.x > 0 && nextPos.x < 16);
    }
    
    bool valid(Vector2 dir) {
        // Let's be sure anything hit me
        // Vector2 pos = transform.position;
        // RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        // return (hit.collider == GetComponent<Collider2D>());
        return true;
    }
    
    void destroyPlayer()
    {
        state = PlayerState.Dead;
        this.gameObject.SetActive(false);
    }
    
    // If the player is coming back from the dead, there's no special
    // power with it
    void respawnPlayer()
    {
        // But before coming back, let's make sure no stacked "commands" from 
        // the last life get executed
        CancelInvoke();
        
        this.gameObject.SetActive(true);
        powerupQueue.Clear();
        resetPlayerState();
    }
    
    // When a powerup hits the player, the powerup is activated
    // and the respective object removed from the screen.
    // Elapsed powerup duration, the player state is "normal" again
    void activatePowerup(Collider2D powerup)
    {
        string objectName = powerup.gameObject.name;
        float powerupDuration = 0.0f;
        if (objectName.StartsWith("weapon"))
        {
            if (state == PlayerState.Shielded)
            {
                state = PlayerState.ShieldAndWeaponBoost;
            }
            else
            {
                state = PlayerState.WeaponBoost;
            }
            powerupQueue.Enqueue(PlayerState.WeaponBoost);
            powerupDuration = 15.0f;
        }
        else
        {
            if (state == PlayerState.WeaponBoost)
            {
                state = PlayerState.ShieldAndWeaponBoost;
            }
            else
            {
                state = PlayerState.Shielded;
            }
            powerupQueue.Enqueue(PlayerState.Shielded);
            powerupDuration = 10.0f;
            Destroy(Instantiate(shield, transform.position, Quaternion.identity), powerupDuration);
        }
        Invoke("resetPlayerState", powerupDuration);
        Destroy(powerup.gameObject);
    }
    
    // This function intends mainly to manage the player powerup state. We know powerups may stack,
    // so there's a queue helping to determinate the player's state when a powerup expirates.
    // We may use this method to reenable the player in the scene, but we must clear the queue
    // before doing so.
    void resetPlayerState()
    {
        try
        {
            powerupQueue.Dequeue();
        }
        catch (System.InvalidOperationException e)
        {}
        if (powerupQueue.Count == 0)
        {
            state = PlayerState.Alive;
            return;
        }
        
        if (powerupQueue.Contains(PlayerState.Shielded) && powerupQueue.Contains(PlayerState.WeaponBoost))
        {
            return;
        }
        
        state = powerupQueue.Peek();
        
        
    }
    
    public int getPlayerState()
    {
        return (int) state;
    }
}
