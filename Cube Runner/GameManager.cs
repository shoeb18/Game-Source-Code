using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject tapToStartText;
    public GameObject scoreText;

    void Start()
    {
        gameOverPanel.SetActive(false);
        tapToStartText.SetActive(true);
        scoreText.SetActive(false);
        PauseGame();
    }

    void Update()
    {
        // if left mouse button is pressed game is started
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    // gameover method to display gameover panel
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
    }

    // restarting the scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // for quit the game
    public void Quit()
    {
        Application.Quit();
    }

    // pause game method
    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    // start game method
    void StartGame()
    {
        Time.timeScale = 1f;
        tapToStartText.SetActive(false);
        scoreText.SetActive(true);
    }
}
