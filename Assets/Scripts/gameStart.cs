﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ## Chance the scene to the main one ##
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainGame");
            // ##
        }
    }
}
