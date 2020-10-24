﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class pausemenu : MonoBehaviour
{
    public FirstPersonAIO controller;
    public GameObject PauseMenuUI;

    public bool paused;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }


    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}


