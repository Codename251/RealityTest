using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public VideoPlayer videoPlayer;

    public GameObject videoObject;
    public GameObject startMenu;
    public GameObject QcmMenu;


    void Awake()
    {

        videoPlayer.loopPointReached += OnMovieFinished; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                
                Play();
            }

            else
            {
                
                Pause();
            }
        }

        

    }

    public void Play()
    {
        videoPlayer.Play();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        videoPlayer.Pause();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void StartVideo()
    {
        videoObject.SetActive(true);
        startMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        videoObject.SetActive(false);
        startMenu.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

    public void QuitPlayer()
    {
        Application.Quit();
    }

    void OnMovieFinished(VideoPlayer player)
    {
      
        videoPlayer.Stop();
        QcmMenu.SetActive(true);
    }
}
