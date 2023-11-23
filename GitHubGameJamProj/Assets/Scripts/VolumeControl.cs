using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    MusicPlayer musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    public void SetSFXVolume(float newVolume){
        if (musicPlayer != null){
            musicPlayer.SetSFXVolume(newVolume);
        }
    }

    public void SetMusicVolume(float newVolume){
        if (musicPlayer != null){
            musicPlayer.GetComponent<AudioSource>().volume = newVolume;
        }
    }
}
