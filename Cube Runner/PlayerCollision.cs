using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Player playerScript;
    public Score score;
    public GameManager gameManager;
    public AudioSource coinSound;
    public AudioSource gameOverSound;

    // for player collecting objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectables")
        {
            // play coin sound
            coinSound.Play();
            // add score to the text
            score.AddScore(1);
            // destroy collectable object
            Destroy(other.gameObject);
        }
    }

    // for player gameover
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            // play gameover sound
            gameOverSound.Play();
            // disabled the player script for stop movement at gameover
            playerScript.enabled = false;
            gameManager.GameOver();
        }
    }
}
