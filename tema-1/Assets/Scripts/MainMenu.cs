﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IrAlJuego();
        //if (Input.anyKeyDown) //si se pulsa cualquier tecla
        //{
        //    SceneManager.LoadScene("MainGame");
        //}
    }
    public void IrAlJuego()
    {
        if (Input.anyKeyDown) //si se pulsa cualquier tecla
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
