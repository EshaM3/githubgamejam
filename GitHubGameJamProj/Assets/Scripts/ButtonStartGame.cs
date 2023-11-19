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
        SceneManager.LoadScene(nextSceneName);
    }
}
