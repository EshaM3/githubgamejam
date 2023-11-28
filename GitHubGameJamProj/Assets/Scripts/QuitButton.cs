using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void ExitGame() {

        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if (mp != null){
            mp.PlayMenuClick();
        }
        
        Application.Quit();
    }

    public void HoverButton(){
        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if (mp != null){
            mp.PlayMenuHover();
        }
    }
}
