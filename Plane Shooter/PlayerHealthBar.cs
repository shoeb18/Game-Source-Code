using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image bar;
    // bar image sprite

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // it sets the fill Amount of bar
    public void SetFillAmount(float amount){
        bar.fillAmount = amount;
    }
}