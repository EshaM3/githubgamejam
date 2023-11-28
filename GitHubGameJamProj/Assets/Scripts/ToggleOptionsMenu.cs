using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOptionsMenu : MonoBehaviour
{
    public GameObject menuToggle;
    public void ToggleMenu(){

        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if (mp != null){
            mp.PlayMenuClick();
        }
        
        menuToggle.SetActive(!menuToggle.activeInHierarchy);
    }

    public void HoverButton(){
        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if (mp != null){
            mp.PlayMenuHover();
        }
    }
}
