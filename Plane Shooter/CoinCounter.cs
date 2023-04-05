using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text CoinScoreText;
    public Text finalCoinText;
    private int counter = 0;


    void Update()
    {
        // updating the scoretext
        CoinScoreText.text = counter.ToString();
        // assigning the final score
        finalCoinText.text = "Coins : " + counter.ToString();
    }

    // updating the score by 1
    public void AddScore(){
        counter++;
    }
}