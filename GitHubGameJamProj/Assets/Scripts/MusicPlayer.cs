using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public static float SFX_Volume = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        MusicPlayer[] objs = FindObjectsOfType<MusicPlayer>();

        foreach(MusicPlayer mp in objs){
            if (mp.GetComponent<AudioSource>().time > GetComponent<AudioSource>().time){
                Destroy(this.gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);
        SetSFXVolume(SFX_Volume);
    }
    void Start()
    {
        SetSFXVolume(SFX_Volume);
    }

    public void SetSFXVolume(float newVolume){
        SFX_Volume = newVolume;

        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource aud in audio){
            if (aud.GetComponent<MusicPlayer>() == null){
                aud.volume = SFX_Volume;
            }
        }
    }
}
