using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HelmetGenerate : MonoBehaviour
{
    public static HelmetGenerate instance;
    float Helmetpos;
    GameObject temp;
    public GameObject[] helmet;
   
    int i;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }


    public void HelmetsGenerate(float posX)
    {

        
        GameObject g = ChooseObject();
        Helmetpos = PlayerMove.instance.lanePos[Random.Range(0, PlayerMove.instance.lanePos.Length)];

        if(g.GetComponent<HelmetType>().hlmts == HlmtType.redHelmet)
        {
            g.transform.position = new Vector3(posX*4, 50, Helmetpos);
        }
        else
        {
            g.transform.position = new Vector3(posX , 50, Helmetpos);
        }

       
       
    }

    public GameObject ChooseObject()
    {
        
        temp = GameObject.Instantiate(helmet[Random.Range(0, helmet.Length)]);
        return temp;
    }
}