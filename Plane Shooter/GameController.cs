using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject lvlCompleteText;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        levelCompletePanel.SetActive(false);
        lvlCompleteText.SetActive(false);
    }

    void Update()
    {
        
    }

    // function for pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    
    // function for Resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    // function for restart the game
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // function for gameover 
    public void GameOver(){
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    // for quit game
    public void QuitGame(){
        Application.Quit();
    }

    // next level loader
    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // show level complete panel
    public IEnumerator LevelComplete(){

        yield return new WaitForSeconds(2f);
        lvlCompleteText.SetActive(true);
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        levelCompletePanel.SetActive(true);
    }
}