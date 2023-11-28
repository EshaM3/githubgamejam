using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOrder : MonoBehaviour
{
    public string[] levels;
    bool[] collectedCoins;
    public int[] coinDifficulty;
    void Start(){
        if (collectedCoins == null || collectedCoins.Length < levels.Length || collectedCoins.Length < coinDifficulty.Length){
            Debug.Log("building coin collection");
            collectedCoins = new bool[(int)Mathf.Max(levels.Length, coinDifficulty.Length)];
            Debug.Log("total coins: " + GetTotalCoins());
        }
    }
    public string nextLevel(string currentLevel){
        int index = LevelIndex(currentLevel);
        if (index > -1 && index < levels.Length-1){
            return levels[index+1];
        }
        return "Ending";
    }

    int LevelIndex(string currentLevel){
        for (int i = 0; i < levels.Length; i++){
            if (levels[i].Equals(currentLevel)){
                return i;
            }
        }
        return -1;
    }

    int LevelIndex(){
        return LevelIndex(SceneManager.GetActiveScene().name);
    }

    public int GetCoinDifficulty(){
        int index = LevelIndex();
        if (index > -1 && index < coinDifficulty.Length){
            return coinDifficulty[index];
        }
        return 0;
    }

    public bool CollectedCoin(){
        int index = LevelIndex();
        return IsCoinCollected(index);
    }

    public void SetCollectedCoin(){
        int index = LevelIndex();
        if (index > -1 && index < collectedCoins.Length){
            Debug.Log("setting collected coin");
            collectedCoins[index] = true;
        }
    }

    public bool IsCoinCollected(int index){
        if (index > -1 && index < collectedCoins.Length){
            return collectedCoins[index];
        }
        return false;
    }

    public int GetCoinValue(int i){
        if (i == 3){
            return 25;
        }
        if (i == 2){
            return 10;
        }
        if (i == 1){
            return 5;
        }
        return 1;
    }

    public int GetTotalCoins(){
        int sum = 0;
        foreach (int i in coinDifficulty){
            sum += GetCoinValue(i);
        }
        return sum;
    }

    public int GetCollectedCoins(){
        int sum = 0;
        for (int i = 0; i < coinDifficulty.Length && i < collectedCoins.Length; i++){
            if (collectedCoins[i]){
                sum += GetCoinValue(coinDifficulty[i]);
            }
        }
        return sum;
    }
}
