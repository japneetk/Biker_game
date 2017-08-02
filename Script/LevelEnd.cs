using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
       if(other.tag.Equals("Player"))
        {
            LanesPrefab.instance.LanesInstantiate();
        }
        
    }

    public void Update()
    {
        if (PlayerMove.instance.transform.position.x > transform.position.x +6000)
        {
            DestroySelf();
        }
    }
        public void DestroySelf()                                           //Destroy previous Lanes after sometime
        {
            Destroy(transform.parent.gameObject);
        }  
}
