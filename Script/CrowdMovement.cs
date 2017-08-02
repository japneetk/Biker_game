using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    public static CrowdMovement instance;
    public float startingPos;
    public float endingPos;
    public bool minToMax;
    public bool startMoving;
    public float speed;
    public bool done;

    ////public void Start()
    ////{
    ////    if (instance == null)
    ////    {
    ////        instance = this;
    ////    }
    ////}

    public void CrowdMove()
    {
        
        startMoving = true;
        
    }

    private void Update()
    {
        if (startMoving)
        {
            if (minToMax)
            {
                if (transform.localPosition.x >= endingPos)
                {
                    done = true;
                    return;
                }
                Vector3 pos = transform.localPosition;
                pos.x += speed * Time.deltaTime;
                transform.localPosition = pos;
            }
            else
            {
                if (transform.localPosition.x <= startingPos)
                {
                    done = true;
                    return;
                }
                Vector3 pos = transform.localPosition;
                pos.x -= speed * Time.deltaTime;
                transform.localPosition = pos;
            }
        }
    }
}