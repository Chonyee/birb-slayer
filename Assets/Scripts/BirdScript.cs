using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Author: Tony Pham
 * Date: 12/6/2021
 * 
 * 3410 Final Project
 * 
 * Script for making bird fall and die and blood particles
 */

public class BirdScript : MonoBehaviour
{
    private bool rotate;
    private bool isClickable;
    public static float speed = 5f;
    public GameObject birdPrefab;

    public static bool didLoseHP;

    ParticleSystem bloodParticle;

    private Rigidbody2D rb2d;

    public static int pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = 0;
        bloodParticle = GetComponent<ParticleSystem>();
        rb2d = GetComponent<Rigidbody2D>();

        speed = 5f;

        rotate = false;
        isClickable = true;
        didLoseHP = false;
    }

    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (pause == 0)
        {
            amIDead();

            if (sceneName == "Game")
            {
                whatDaBirdDoing();
            }
            else
            {
                menuBirds();
            }
        }
    }

    private void OnMouseDown()
    {
        if (pause == 0)
        {
            if (isClickable)
            {
                rb2d.gravityScale = 2;
                ManagerScript.sounds[0].Play();
                ManagerScript.score++;
                bloodParticle.Play();

                isClickable = false;
                rotate = true;
            }
        }
    }

    void amIDead()
    {
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * 10);
        }
    }

    void whatDaBirdDoing()
    {
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y < -5.5)
        {
            Destroy(gameObject);
        }

        if (temp.x < -9.5f)
        {
            if (isClickable)
            {
                ManagerScript.removeHeart++;
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }

    void menuBirds()
    {
        isClickable = false;
        Vector2 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y < -5.5 || temp.x < -9.5f)
        {
            Destroy(gameObject);
        }
    }
}
