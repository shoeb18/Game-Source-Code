using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // bar sprite
    public Transform bar;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // it sets the new bar size
    public void SetBarSize(float size){
        bar.localScale = new Vector2(size, 1f);
    }
}