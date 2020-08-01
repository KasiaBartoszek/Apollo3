using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public GameObject gameOverCanvas;
    public GameObject endOfLevelCanvas;
    public GameObject scoreText;

    private bool paused;
    private bool gameover;
    private bool levelFinished;

    private int BASICSCORE = 500;
    private int TURRETKILLSCORE = 50;
    private int OXYGENSCORE = 2;
    private int SHOTSCORE = 1;

    private int turretsKilled = 0;
    private int bulletsFired = 0;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        endOfLevelCanvas.SetActive(false);
        paused = false;
        gameover = false;
        levelFinished = false;
    }

    void Update()
    {
        if (gameover && paused && Input.anyKey) //l->r?
        {
            restartLevel();
        }

        if(levelFinished && paused && Input.anyKey)
        {
            launchNextLevel();
        }

        if(Input.GetMouseButtonDown(0))
        {
            bulletsFired += 1;
        }

    }
    public void gameOver()
    {
        displayGameOver();
        pauseGame();
        gameover = true;
    }

    public void endOfLevel()
    {
        displayEndOfLevel();
        pauseGame();
        levelFinished = true;

    }
    private void displayGameOver()
    {
        gameOverCanvas.SetActive(true);
 
    }

    private void displayEndOfLevel()
    {

        var Player = GameObject.FindWithTag("Player");
        var oxygen = Player.GetComponent<Oxygen>().actualOxygen;
        int oxygenScore = (int)(oxygen) * OXYGENSCORE;
        endOfLevelCanvas.SetActive(true);

        int score = BASICSCORE + turretsKilled * TURRETKILLSCORE + oxygenScore - (bulletsFired * SHOTSCORE);
        Text scoretxt = scoreText.GetComponent<Text>();
        scoretxt.text = "Score: " + score + "\n"
        + "Basic score: " + BASICSCORE + "\n" 
        + "Turrets killed: "+turretsKilled + " (+" + turretsKilled * TURRETKILLSCORE + ")" + "\n" 
        + "Oxygen left: " +(int)(oxygen) + " (+" + oxygenScore + ")" + "\n"
        + "Shots fired: " + bulletsFired  + " (-" + bulletsFired*SHOTSCORE + ")" +"\n";  
    }
    private void pauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
    }

    private void restartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void launchNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void turretKilled()
    {
        turretsKilled+=1;
    }

}
