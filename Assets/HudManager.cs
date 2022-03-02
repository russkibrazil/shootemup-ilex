using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updatePointsText()
    {
        // show player's ponts with 8 digits
        scoreLabel.text = GameManager.instance.getScore().ToString().PadLeft(8,'0');
    }
}
