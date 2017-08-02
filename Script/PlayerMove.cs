using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    public Vector3 targetPos;
    public int moveSpeed;
    public int levelChangeSpeed;
    public bool allowedToMove = false;
    public float[] lanePos;
    public int currentLane;
    public Rigidbody rb;
    Vector3 targetRot;
    float resetTime;
    public SpriteRenderer sR;
    public bool godBool;
    public float godModeTime;
    float timer;
    bool move;
    // Use this for initialization
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();
        StartCoroutine("ChangeLane");
        //if (transform.rotation.z == 0)
        //{
        //    StartCoroutine("rotate");
        //}

        
    }

    

    // Update is called once per frame
    void Update()
    {
        move=true;
        if (allowedToMove)                                    //Player Moves
        {

            rb.velocity = Vector3.right * moveSpeed;
            HelmetDestroy.score++;
            Score.instance.ScoreDisplay();
            
            if (Input.GetKeyDown(KeyCode.DownArrow))          //Player moves Down
            {
                currentLane--;
                if (currentLane < 0)
                {
                    currentLane = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))              //Player Moves Up
            {
                currentLane++;
                if (currentLane > lanePos.Length - 1)
                {
                    currentLane = lanePos.Length - 1;
                }
            }
        }
        else
        {
            PlayerStop();
            
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (LanesPrefab.instance.image4)
            {
                allowedToMove = false;
            }
            else
            {
                allowedToMove = true;   
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            allowedToMove = false;
        }

        if (godBool)
        {
            timer-=Time.deltaTime;
        }
        targetPos = transform.position;                         //Position to reach on movement
        targetPos.z = lanePos[currentLane];
        //pos= lanePos[currentLane];
    }

    public void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }
    public void GodMode()
    {                                                               //BlinkingEffect
        godBool = true;
        Color c = sR.color;
        c.a = 0.5f;
        sR.color = c;
        timer = godModeTime;
        StartCoroutine("ChangeColor");
    }
    IEnumerator ChangeColor()
    {
        while (true)
        {
            if (timer <= 0)
            {
                Color c = sR.color;
                c.a = 1;
                sR.color = c;
                godBool = false;
            }
            yield return 0;
        }
    }

    IEnumerator ChangeLane()
    {
        while (true)
        {

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * levelChangeSpeed);    //Player Moves left and right

            yield return 0;
        }
    }

    //public void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("SpeedBrake"))
    //    {
    //        StartCoroutine("RotateB");
    //    }
    //}

    //IEnumerator RotateB()
    //{
    //    resetTime = 0;
    //    while (true)
    //    {
    //        targetRot = transform.eulerAngles;
    //        if (resetTime == 0)                                     //Player rotates up
    //        {
    //            targetRot.z += moveSpeed * 0.06f * Time.deltaTime;

    //            if (targetRot.z > 20)
    //            {
    //                resetTime = 1;
    //            }
    //        }
    //        else if (resetTime == 1)                                //Player rotates down
    //        {
    //            targetRot.z -= moveSpeed * 0.06f * Time.deltaTime;

    //            if (targetRot.z < 350 && targetRot.z > 180)
    //            {
    //                resetTime = 2;
    //            }

    //        }
    //        else if (resetTime == 2)                                    //Player move straight
    //        {
    //            targetRot.z += moveSpeed * 0.06f * Time.deltaTime;

    //            if (targetRot.z > 0 && targetRot.z < 180)
    //            {
    //                resetTime = 3;
    //            }
    //        }

    //        transform.eulerAngles = targetRot;                          //Leave loop
    //        if(resetTime == 3)
    //        {
    //            yield break;
    //        }
    //        yield return 0;
    //    }
    //}

}

