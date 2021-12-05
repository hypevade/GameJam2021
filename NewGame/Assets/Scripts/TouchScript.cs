using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour
{
    public GameObject startButton;
    public GameObject gamePanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    public Animator StartPanelAnim;

    public bool gameIsStarted;
    public bool gameIsPaused;
    public bool gameIsOver;


    public void StartGame()
    {
        startButton.SetActive(false);
        StartPanelAnim.SetBool("GameStarted",true);
        gamePanel.SetActive(true);
        gameIsStarted = true;
    }

    public void StartPause()
    {
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
        gameIsPaused = true;
    }
    
    public void EndPause()
    {
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        gameIsPaused = false;
    }

    public void Turn(bool isRightTurn)
    {
        if (isRightTurn)
        {
            //поворот вправо
        }
        // поворот влево
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameIsOver = true;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
