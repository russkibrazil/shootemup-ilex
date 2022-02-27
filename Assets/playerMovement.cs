using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    const float STEP_ANIMATION = 0.25f;
    private Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
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
    
    bool insideScreen(Vector2 pos) {
        Vector2 nextPos = (Vector2)transform.position + pos;
        //cam = UnityEngine.Camera.main;
        return (nextPos.x > 0 && nextPos.x < 16);
    }
    
    bool valid(Vector2 dir) {
        // Let's be sure anything hit me
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
