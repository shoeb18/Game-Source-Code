using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variables player movement
    float deltaX;
    float deltaY;
    float minX;
    float minY;
    float maxX;
    float maxY;
    float padding = 0.8f;
    public float movementSpeed = 10f;
    public GameObject playerDeadExplosion;
    public GameObject damageEffect;
    public GameController gameController;

    // player health system
    public PlayerHealthBar playerHealthBar;
    public CoinCounter coinCounter;
    public float health = 10f;
    float damage = 0;
    float barFillAmount = 1f;

    // audio system
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    void Start()
    {
        FindBorders();
        damage = barFillAmount / health;
    }

    // function that find the border of the camera at the time game starts
    void FindBorders()
    {
        Camera gameCamera = Camera.main;

        // find border using ViewportToWorldPoint()
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding ;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    void Update()
    {
        // getting user input for player movement using unity input manager 
        deltaX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        deltaY = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        // make new player position and clamp it between min and max position
        float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY,minY, maxY);

        // adds new position to player actual position
        transform.position = new Vector2(newXpos, newYpos);

    }

    // Destroy our player here!
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag == "EnemyBullet")
        {
            // damage player and destroy enemy bullet
            DamagePlayer();
            Destroy(other.gameObject);

            // play damage sound
            audioSource.PlayOneShot(damageSound, 0.5f);

            // spawn damage effect
            GameObject tempdamage = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
            Destroy(tempdamage, 0.05f);

            if (health <= 0){
                // Destroy player and spawn dead explostion animation and play explosion sound
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Destroy(this.gameObject);

                GameObject tempVFX = Instantiate(playerDeadExplosion, transform.position, Quaternion.identity);
                Destroy(tempVFX, 2f);
                gameController.GameOver();
            }
        }

        // collecting coin
        if (other.gameObject.tag == "Coin")
        {
            // play coin collect sound
            audioSource.PlayOneShot(coinSound, 0.5f);
            // destroy coin
            Destroy(other.gameObject);
            // adding the score
            coinCounter.AddScore();
        }
    }

    // Player damage using method
    void DamagePlayer(){

        if (health > 0){
            health -= 1;
            barFillAmount = barFillAmount - damage;
            playerHealthBar.SetFillAmount(barFillAmount);
        }
    }
}