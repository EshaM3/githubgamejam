using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStarter : MonoBehaviour
{
    public GameObject[] walls;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject wall in walls){
            wall.SetActive(true);
        }
    }
}
