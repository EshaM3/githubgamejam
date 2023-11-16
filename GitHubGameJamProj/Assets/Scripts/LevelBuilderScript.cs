using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class LevelBuilderScript : MonoBehaviour
{
    public int selectedMusicBox = 0;
    public GameObject[] musicBoxPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnMusicBox(){
        foreach (Transform child in transform) {
            GameObject.DestroyImmediate(child.gameObject);
        }

        if (selectedMusicBox < musicBoxPrefabs.Length){
            GameObject go = Instantiate<GameObject>(musicBoxPrefabs[selectedMusicBox], this.transform);
            go.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
