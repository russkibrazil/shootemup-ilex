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
        scoreLabel.text = GameManager.instance.getScore().ToString().PadLeft(8,'0');
    }
}
