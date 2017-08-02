﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float xOffset;
	
    // Update is called once per frame
	void Update () {
        
        Vector3 pos = transform.position;
      
        pos.x = target.transform.position.x + xOffset;
        
        transform.position = pos;
       
    }
}
