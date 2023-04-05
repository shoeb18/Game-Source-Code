using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // this destroy all objects that are moved out of screen
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}