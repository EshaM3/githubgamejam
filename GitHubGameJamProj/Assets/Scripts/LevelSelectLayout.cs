using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectLayout : MonoBehaviour
{
    public GameObject original;
    // Start is called before the first frame update
    void Start()
    {
        LevelOrder lo = FindObjectOfType<LevelOrder>();
        int levelCount = lo.levels.Length;
        float proportion = 16f/9f;

        int width = Mathf.RoundToInt(proportion*Mathf.Sqrt(levelCount/proportion));
        int height = levelCount/width;
        if (height*width < levelCount){
            height++;
        }

        for (int i = 0; i < lo.levels.Length; i++){
            int xPos = i%width;
            int yPos = i/width;

            GameObject go = Instantiate<GameObject>(original,this.transform);

            float yLow = 300;
            float yHigh = -400;
            float xLow = -750;
            float xHigh = 750;

            float xLevel = xLow + (xPos*(xHigh-xLow))/(width-1f);
            float yLevel = yLow + (yPos*(yHigh-yLow))/(height-1f);

            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(xLevel, yLevel);
            go.GetComponent<ButtonStartGame>().nextSceneName = lo.levels[i];
            go.GetComponentInChildren<TextMeshProUGUI>().text = ""+(i+1);

            if (!lo.IsCoinCollected(i)){
                Transform coinIcon = FindWithTag(go.transform,"Coin");
                if (coinIcon != null){
                    coinIcon.gameObject.SetActive(false);
                }
            }
        }
    }

    Transform FindWithTag(Transform root, string tag)
    {
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t.CompareTag(tag)) return t;
        }
        return null;
    }
}
