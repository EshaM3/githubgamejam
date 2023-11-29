using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    MusicPlayer musicPlayer;
    public Slider sfxSlider, musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer != null){
            sfxSlider.value = MusicPlayer.SFX_Volume;
            musicSlider.value = musicPlayer.GetComponent<AudioSource>().volume;
        }
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
