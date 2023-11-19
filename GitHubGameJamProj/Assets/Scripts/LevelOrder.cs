using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrder : MonoBehaviour
{
    public string[] levels;
    public string nextLevel(string currentLevel){
        for (int i = 0; i < levels.Length-1; i++){
            if (levels[i].Equals(currentLevel)){
                return levels[i+1];
            }
        }
        return "Title";
    }
}
