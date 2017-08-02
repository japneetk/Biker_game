using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmetDestroy : MonoBehaviour
{
    public static HelmetDestroy instance;
    bool done;
    public static int score=0;
    //public Text scoreText;
    static int count=0;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if (!done)
        {
            if (col.gameObject.tag.Equals("Player"))
            {
                done = true;
                score=score+100;
                count++;
                if(GetComponent<HelmetType>().hlmts == HlmtType.goldenHelmet)
                {
                    if (PlayerMove.instance.godBool == false)
                    {
                        print("Score is: " + score);
                        Score.instance.ScoreDisplay();
                        //scoreText.text = "Score is: " + score;

                    }
                }
                
                else
                {
                    print("GodMode");
                    if (count < 3)
                    {
                        if(PlayerMove.instance.godBool == true)
                        {
                            print("Score is: " + score);
                            Score.instance.ScoreDisplay();
                            //scoreText.text = "Score is: " + score;
                        }
                        else
                        {
                            PlayerMove.instance.GodMode();
                        }
                        
                    }
                    else
                    {
                        print("Score is: " + score);
                        Score.instance.ScoreDisplay();
                        //scoreText.text = "Score is: " + score;
                    }
                }
            }
        }
    }
    public void Update()
    {
        
        if (PlayerMove.instance.transform.position.x > transform.position.x+10)
        { 
    
            DestroySelf();
        }
    }
    public void DestroySelf()                                           //Destroy previous Lanes after sometime
    {
        Destroy(gameObject);
    }


}
