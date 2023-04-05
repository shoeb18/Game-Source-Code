using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 10f;


    void Update()
    {
        // simply bullet movement using Translate()
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
}