using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* Author: Tony Pham
 * Date: 12/6/2021
 * 
 * 3410 Final Project
 * 
 * Script for main menu's play and exit button along with birds in the background
 */

public class MenuBirbSpawn : MonoBehaviour
{
    public static float timer = .01f;
    private float minY = -1.5f, maxY = 4.5f;
    public GameObject birdPrefab;

    private float clock;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        timer = .01f;
        Invoke("SpawnBird", timer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBird()
    {
        float Ypos = Random.Range(minY, maxY);
        Vector2 temp = transform.position;
        temp.y = Ypos;

        Instantiate(birdPrefab, temp, Quaternion.identity);

        Invoke("SpawnBird", timer);
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
