using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundElements : MonoBehaviour
{
    public GameObject[] possibleElements;
    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        int nameTotal = 0;
        foreach (char c in sceneName){
            nameTotal += c;
        }

        if (nameTotal % 2 == 0){
            possibleElements[0].SetActive(true);
        }
        if (nameTotal % 3 == 0){
            possibleElements[1].SetActive(true);
        }
        if (nameTotal % 5 == 0){
            possibleElements[2].SetActive(true);
        }
        if (nameTotal % 7 == 0){
            possibleElements[3].SetActive(true);
        }
        if (nameTotal % 9 == 0){
            possibleElements[4].SetActive(true);
        }
        if (nameTotal % 11 == 0){
            possibleElements[5].SetActive(true);
        }
        if (nameTotal % 13 == 0){
            possibleElements[6].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
