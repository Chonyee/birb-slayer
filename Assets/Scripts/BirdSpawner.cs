using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Author: Tony Pham
 * Date: 12/6/2021
 * 
 * 3410 Final Project
 * 
 * Script for spawning birds during the game
 */

public class BirdSpawner : MonoBehaviour
{
    public static float timer = 1f;
    private float minY = -1.5f, maxY = 4.5f;
    public GameObject birdPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
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
}
