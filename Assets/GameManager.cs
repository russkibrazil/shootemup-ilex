using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // It is not necessary that someone else messes around with player
    // score. Following some Software Engineering principles,
    // lets use getters/setters
    private int score;
    private GameObject hudManager;
    public static GameManager instance = null;
    
    void Awake()
    {
        // if gamemanager doesn't exist, set the instance to the current object
        if(instance == null)
        {
            instance = this;
        }
        // There can only be a single instance of the game manager
        else if(instance != this)
        {
            // Destroy the current object, so there is just one manager
            Destroy(this.gameObject);
        }
        hudManager = GameObject.Find("HudManager");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        resetScore();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int pointsToAdd)
    {
        // add the points and refresh the hud
        score += pointsToAdd;
        hudManager.GetComponent<HudManager>().updatePointsText();
    }
    
    public void resetScore()
    {
        score = 0;
        hudManager.GetComponent<HudManager>().updatePointsText();
    }
    
    public int getScore()
    {
        return score;
    }
}
