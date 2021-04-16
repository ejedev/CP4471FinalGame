using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Boolean backToMenu;

    public Boolean isQuit;
    
    private void OnMouseUp()
    {
        if (backToMenu)
        {
            SceneManager.LoadScene(0);
        }

        if (isQuit)
        {
            Application.Quit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TextMesh finalScore = GameObject.Find("ScoreTextValue").GetComponent<TextMesh>();
        finalScore.text = SpawnManager.finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
