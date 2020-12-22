using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public FirstPersonAIO controller;
    public GameObject player;
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


        controller.controllerPauseState = false;
    }

    private void Start()
    {
        transform.parent = null;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }



}


