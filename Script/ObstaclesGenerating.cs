using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerating : MonoBehaviour
{
    public static ObstaclesGenerating instance;
    GameObject temp;
    float pitPos, pitPos1, pitPos3;
    int i;
    float timer;
    public GameObject[] WithObstacles;
    public GameObject WithoutObstacles;
    //public GameObject busObstacle;
    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    
    // Update is called once per frame
    public void GenerateObstacle(float pos, int type)       //type 1= withObstacle, 0= withoutObstacle          //withoutObstcl= ZebraCrossing
    {
        GameObject g = ChooseObject(type);
        
        //GameObject temp2 = ChooseBus(type);
        if (g.GetComponent<LaneType>().obstType == ObstracleType.singleLane )
        {
            GameObject temp1 = ChooseObject(type);
            if (temp1.GetComponent<LaneType>().obstType == ObstracleType.singleLane)        //position the singleline obstacle
            {
                pitPos = PlayerMove.instance.lanePos[Random.Range(0, PlayerMove.instance.lanePos.Length)];
                pitPos1 = PlayerMove.instance.lanePos[Random.Range(0, PlayerMove.instance.lanePos.Length)];
                pitPos3 = PlayerMove.instance.lanePos[Random.Range(0, PlayerMove.instance.lanePos.Length)];
                if (pitPos != pitPos1)
                {
                    temp1.transform.position = new Vector3(pos, -43, pitPos1);
                }
                else
                {
                    pitPos1 = PlayerMove.instance.lanePos[Random.Range(0, PlayerMove.instance.lanePos.Length)];
                    if (pitPos != pitPos1)
                    {
                        temp1.transform.position = new Vector3(pos, -43, pitPos1);
                    }
                }
                g.transform.position = new Vector3(pos, -43, pitPos);
                //temp2.transform.position = new Vector3(pos * 6, 130, pitPos3);
            }
            //else
            //{
            //    temp1.transform.position = new Vector3(pos, -42, 3150);
            //}
        }
       
        else
        {
            g.transform.position = new Vector3(pos, -42, 3150);     //position the multiline obstacles
        }
       
        
    }

    public GameObject ChooseObject(int typeObs)
    {
        
        if (typeObs == 0)
        {
            temp = GameObject.Instantiate(WithoutObstacles);          //instantiating zebraCrossing
        }
        else
        {
            temp = GameObject.Instantiate(WithObstacles[Random.Range(0, WithObstacles.Length)]);                //instantiating pitholes
        }
                               
        return temp;
    }
    //public GameObject ChooseBus(int typeObs)
    //{
    //    if(typeObs == 1)
    //    {
    //        temp = GameObject.Instantiate(busObstacle);                //instantiating bus
    //    }

    //    return temp;
    //}
}
