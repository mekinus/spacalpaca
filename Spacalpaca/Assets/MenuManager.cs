﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private bool manualIsOpen = false;

    public GameObject manual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()

    {
        Application.Quit();
    }

    public void ToggleManual()

    {
        if (!manualIsOpen)
        {
            manualIsOpen = true;
            manual.SetActive(true);
        }
        
        else
        {
            manualIsOpen = false;
            manual.SetActive(false);
        }
        
    }


   
}
