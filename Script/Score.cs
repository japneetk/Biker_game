using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public static Score instance;
    int scores;
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void ScoreDisplay() {
        scores = HelmetDestroy.score;
        scoreText.text = "Score is: " + scores;
    }
}
