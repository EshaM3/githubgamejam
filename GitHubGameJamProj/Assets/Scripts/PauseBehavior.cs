using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{
    public GameObject panel;
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PauseGame(){
        Debug.Log("pausing");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    void Update(){
        if (Time.timeScale == 0){
            Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
        }
    }
    public void UnpauseGame(){
        Debug.Log("unpausing");
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
