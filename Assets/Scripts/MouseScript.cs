using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Tony Pham
 * Date: 12/6/2021
 * 
 * 3410 Final Project
 * 
 * Script for having the "scope" follow mouse
 */

public class MouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);
    }
}
