using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverCanvas;

    private bool paused;


    void Start()
    {
        gameOverCanvas.SetActive(false);
        paused = false;
    }

    void Update()
    {
        if (paused && Input.anyKey)
        {
            restartLevel();
        }
    }
    public void gameOver()
    {
        displayGameOver();
        pauseGame();
    }
    public void displayGameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
    }

    public void restartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
