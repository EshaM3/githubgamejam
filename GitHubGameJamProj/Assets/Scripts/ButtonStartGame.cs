using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStartGame : MonoBehaviour
{
    public string nextSceneName;
    public bool restartScene = false;

    public void StartGame(){
        Time.timeScale = 1f;
        if (restartScene){
            nextSceneName = SceneManager.GetActiveScene().name;
        }

        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if (mp != null){
            mp.PlayMenuClick();
        }

        SceneManager.LoadScene(nextSceneName);
    }

    public void HoverButton(){
        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if (mp != null){
            mp.PlayMenuHover();
        }
    }
}
