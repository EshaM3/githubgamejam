using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
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
    }
}
