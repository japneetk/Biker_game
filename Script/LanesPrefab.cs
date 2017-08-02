using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesPrefab : MonoBehaviour
{
    public static LanesPrefab instance;
    public  float lastPos;
    public float lanesPrefabSize;
    public GameObject[] Lanes;
    public int startingPrefabNo;
    public float pos;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
   public  bool img;

    // Use this for initialization
    private void Awake()
    {       
       
        if (instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        img = true;
        for (int i = 0; i <startingPrefabNo; i++)
        {
            
            LanesInstantiate();
            
        }
    }
    public void Update()
    {
        if (img)
        {
            image1.SetActive(true);
            Destroy(image1, 1f);
            image2.SetActive(true);
            Destroy(image2, 2f);
            image3.SetActive(true);
            Destroy(image3, 3f);
            image4.SetActive(true);
            Destroy(image4, 4f);
            img = false;
        }  
    }

    public void LanesInstantiate()
    {

        GameObject temp = GameObject.Instantiate(Lanes[Random.Range(0, Lanes.Length)]);                 //Lanes instantiate
        temp.transform.SetParent(transform, false);

        
        temp.transform.position = new Vector3(lastPos-7000,0,0);

        //pos = lastPos;
        

        if (temp.GetComponent<Land>().landType == LandType.withoutObst)                                 //for land with or without obstacles
        {
            ObstaclesGenerating.instance.GenerateObstacle(lastPos + (lanesPrefabSize / 2), 0); //zebraCrossing
        }
        else
        {
            ObstaclesGenerating.instance.GenerateObstacle(lastPos + (lanesPrefabSize / 2), 1);  //potHoles
        }

        
         HelmetGenerate.instance.HelmetsGenerate(lastPos + (lanesPrefabSize / 6));
        //lanes positioned
        lastPos += lanesPrefabSize;
    }
}