using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    private int myScore = 0;

    void Update()
    {
        // updating the score text
        scoreText.text = myScore.ToString();
        // assign the final score
        finalScoreText.text = "Score : " + myScore.ToString();
    }

    // simple AddScore method it increments the score
    public void AddScore(int score){
        myScore += score;
    }
}
