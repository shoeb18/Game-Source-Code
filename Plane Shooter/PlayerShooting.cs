using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // sounds
    public AudioSource audioSource;

    // bullet components
    public GameObject playerBullet;
    public GameObject flash;
    public Transform gun1;
    public Transform gun2;
    public float bulletSpawnTime = 1f;

    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shooting());
    }

    // player shooting automatically using coroutines 
    IEnumerator Shooting()
    {

        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }

    void Fire()
    {
        // spawn player bullet and play shoot sound
        Instantiate(playerBullet, gun1.position, Quaternion.identity);
        Instantiate(playerBullet, gun2.position, Quaternion.identity);
        // sound
        audioSource.Play();
    }
}