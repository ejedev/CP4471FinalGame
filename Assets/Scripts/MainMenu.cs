using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Boolean isStart;

    public Boolean isQuit;

    private void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1);
        }

        if (isQuit)
        {
            Application.Quit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
