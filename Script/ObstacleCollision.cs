using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    
    bool done;
    

    public void Awake()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if(!done)
        {
            if (col.gameObject.tag.Equals("Player"))
            {
                done = true;
                if (PlayerMove.instance.godBool == false)
                {
                    
                    if (GetComponent<LaneType>().obstType == ObstracleType.fullLane)
                    {
                       if(!GetComponent<LightChanges>().lightChange)
                        {
                            NextLife.instance.OtherLife();
                        }
                        
                    }
                     
                    if (GetComponent<LaneType>().obstType == ObstracleType.singleLane)
                    {
                        NextLife.instance.OtherLife();
                    }

                }
                else
                {
                    print("GodMode");

                }
            }
        }
        
    }


    public void Update()
    {

        if (PlayerMove.instance.transform.position.x > transform.position.x + 6000)
        {
            DestroySelf();
        }
    }
    public void DestroySelf()                                           //Destroy previous obstacles after sometime
    {
        Destroy(gameObject);
    }
}
