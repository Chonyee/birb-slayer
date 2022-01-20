using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Author: Tony Pham
 * Date: 12/6/2021
 * 
 * 3410 Final Project
 * 
 * Script for managing everything from score, text, timer, increasing difficulty, life hearts, sounds
 */

public class ManagerScript : MonoBehaviour
{
    public static AudioSource[] sounds;

    public GameObject mouse;

    public Text scoreText;
    public static int score;

    private float timer;
    private int seconds;
    public Text timerText;

    private bool paused;

    public GameObject gameoverText;
    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject menuButton;

    public static int removeHeart;

    public GameObject heart0;
    public GameObject heart1;
    public GameObject heart2;

    private bool isHeart0;
    private bool isHeart1;
    private bool isHeart2;

    // Start is called before the first frame update`
    void Start()
    {
        Time.timeScale = 1f;

        mouse.SetActive(true);
        gameoverText.SetActive(false);
        menuButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        paused = false;

        removeHeart = 0;
        sounds = GetComponents<AudioSource>();

        scoreText.text = "Score: " + score.ToString();
        timerText.text = "";
        score = 0;

        heart0.SetActive(true);
        heart1.SetActive(true);
        heart2.SetActive(true);

        isHeart0 = true;
        isHeart1 = true;
        isHeart2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;

        scoreText.text = "Score: " + score.ToString();
        timerText.text = seconds.ToString();

        loseHP();
        increaseDifficulty();
        pauseGame();
    }

    void loseHP()
    {
        if(removeHeart == 1)
        {
            heart0.SetActive(false);

            if (!sounds[1].isPlaying && isHeart0 == true)
            {
                sounds[1].Play();
                isHeart0 = false;
            }
        } 
        else if(removeHeart == 2)
        {
            heart1.SetActive(false);

            if (!sounds[1].isPlaying && isHeart1 == true)
            {
                sounds[1].Play();
                isHeart1 = false;
            }
        }
        else if(removeHeart == 3)
        {
            heart2.SetActive(false);

            if (!sounds[1].isPlaying && isHeart2 == true)
            {
                sounds[1].Play();
                isHeart2 = false;
                gameOver();
            }
        }
    }

    void increaseDifficulty()
    {
        if (timer >= 15f)
        {
            BirdSpawner.timer = .75f;
        }

        if (timer >= 30f)
        {
            BirdSpawner.timer = .5f;
        }

        if (timer >= 60f)
        {
            BirdSpawner.timer = .25f;
        }
    }

    void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 1f;
                mouse.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(false);
                menuButton.SetActive(false);
                exitButton.gameObject.SetActive(false);
                Cursor.visible = false;
                BirdScript.pause = 0;
                paused = false;
            }
            else
            {
                Time.timeScale = 0f;
                mouse.gameObject.SetActive(false);
                restartButton.gameObject.SetActive(true);
                menuButton.SetActive(true);
                exitButton.gameObject.SetActive(true);
                Cursor.visible = true;
                BirdScript.pause = 1;
                paused = true;
            }
        }
    }

    void gameOver()
    {
        gameoverText.SetActive(true);
        exitButton.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        mouse.SetActive(false);
        menuButton.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        exitButton.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
