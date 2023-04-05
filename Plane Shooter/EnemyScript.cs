using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // shooting
    public GameObject enemyBullet;
    public GameObject enemyExplosion;
    public GameObject flash;
    public GameObject damageEffect;
    public GameObject Coin;
    public Transform[] gunPoint;
    public float enemyBulletSpawnTime = 2f;
    public float movementSpeed = 1f;

    // health system
    public HealthBar healthBar;
    public float health = 10f;
    float damage = 0;
    float barSize = 1f;

    // audio
    public AudioSource audioSource;
    public AudioClip bulletSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;

    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shooting());
        damage = (barSize / health);
    }

    void Update()
    {
        // enemy downward movement
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
    }

    // Detect collision and destroy enemy
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "PlayerBullet")
        {
            // damage enemy health and destroy player bullet
            DamageEnemy();
            Destroy(other.gameObject);

            // spawn damage effect and play damage sound
            AudioSource.PlayClipAtPoint(damageSound, this.transform.position, 0.5f);
            GameObject tempdamage = Instantiate(damageEffect, other.transform.position, Quaternion.identity);
            Destroy(tempdamage, 0.05f);


            // destroy enemy
            if (health <= 0)
            {
                // play explosion sound
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);

                // destroy enemy here
                Destroy(this.gameObject);
                GameObject tempExp = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                Destroy(tempExp, 0.4f);

                // spawn Coin here
                Instantiate(Coin, transform.position, Quaternion.identity);
            }
        }
    }

    // damage enemy when it collides playerbullet
    void DamageEnemy()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.SetBarSize(barSize);
        }
    }

    // shooting bullets of enemy automatically using coroutines
    IEnumerator Shooting()
    {

        while (true)
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            Fire();
            // bullet sound
            audioSource.PlayOneShot(bulletSound, 0.5f);

            // spawn flash
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);
        }
    }

    void Fire()
    {
        for (int i = 0; i < gunPoint.Length; i++)
        {
            // spawn bullets on gunpoint positions
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
        }
    }
}