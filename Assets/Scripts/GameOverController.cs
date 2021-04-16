using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    bool paused = false;
    public AudioSource pauseMusic;
    public AudioSource mainLoop;
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            paused = togglePause();
    }
     
    void OnGUI()
    {
        if(paused)
        {
            if (mainLoop.isPlaying)
            {
                mainLoop.Pause();
            }
            if (!pauseMusic.isPlaying)
            {
                pauseMusic.Play();
            }
            GUILayout.Label("Game is paused!", GUILayout.Height(100), GUILayout.Width(200));
            if (GUILayout.Button("Click me to unpause"))
            {
                pauseMusic.Stop();
                mainLoop.UnPause();
                paused = togglePause();
            }

            if (GUILayout.Button("Exit to main menu"))
            {
                pauseMusic.Stop();
                SceneManager.LoadScene(0);
            }

            if (GUILayout.Button("Exit to desktop"))
            {
                pauseMusic.Stop();
                Application.Quit();
            }
        }
    }
     
    bool togglePause()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return(false);
        }
        else
        {
            Time.timeScale = 0f;
            return(true);    
        }
    }
}
