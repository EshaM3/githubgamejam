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
        musicPlayer.SetSFXVolume(newVolume);
    }

    public void SetMusicVolume(float newVolume){
        musicPlayer.GetComponent<AudioSource>().volume = newVolume;
    }
}
