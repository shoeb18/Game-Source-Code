using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float offSet;


    void Update()
    {
        // getting player transform.position and assign it camera position on z - axis
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerTransform.position.z + offSet;
        transform.position = cameraPos;
    }
}
