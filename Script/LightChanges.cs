using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanges : MonoBehaviour
{
    public bool lightChange = false;
    public SpriteRenderer light0;

    public CrowdMovement cw1;
    public CrowdMovement cw2;

    bool started = false;
    
    // Use this for initialization
    public void Start()
    {
        Color c = light0.color;
        c.a = 1;
        light0.color = c;
    }
    void Update()
    {
        if (transform.position.x - PlayerMove.instance.transform.position.x < 2000 && !started)
        {
            if (LanesPrefab.instance.image4)
            {
                started = false;
            }
            else
            {
                started = true;
                cw1.CrowdMove();
                cw2.CrowdMove();
            }
            
        }

        if (!lightChange)
        {
            if (cw1.done && cw2.done)
            {
                lightChange = true;
                LightModeOn();
            }
        }
        
    }

    public void LightModeOn()
    {
        Color c = light0.color;
        c.a = 0;
        light0.color = c;
    }
}