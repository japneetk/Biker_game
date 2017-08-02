using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLife : MonoBehaviour
{
    public GameObject[] image;
    static int i;
    public static NextLife instance;
    public GameObject panelDisplay;
    public GameObject gameOver;
    public Text scoreText;
    int scores;
    //public Text txt;
    ////public Button[] btn;

    // Use this for initialization
    void Start()
    {
        i = 0;
        panelDisplay.SetActive(false);
        gameOver.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
         
    }

    // Update is called once per frame
    public void OtherLife()
    {
        if (i < 3)
        {
            print("Next life of Player...");
            image[i].SetActive(false);
            i++;
        }

        if(i == 3)
        {
            scores = HelmetDestroy.score;
            PlayerMove.instance.allowedToMove = false;
            scoreText.text = "Your Score is: " + scores;
            panelDisplay.SetActive(true);
            //Destroy(PlayerMove.instance.gameObject);
        }
    

    }
    public void restart()
    {
        for(int j = 0; j < 3; j++)
        {
            image[j].SetActive(true);
        }
        i = 0;
        HelmetDestroy.score = 0;
        panelDisplay.SetActive(false);
        Vector3 pos = PlayerMove.instance.transform.position;
        pos.x += 20;
        PlayerMove.instance.transform.position = pos;
    }

    public void quit()
    {
        gameOver.SetActive(true);
    }

}