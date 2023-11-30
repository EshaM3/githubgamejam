using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetLevelText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Image panel;
    LevelOrder levelOrder;
    float timer;
    // Update is called once per frame
    void Update()
    {
        if (levelOrder == null){
            levelOrder = FindObjectOfType<LevelOrder>();
        }
        if (levelOrder != null){
            textMeshPro.text = "Level " + (levelOrder.LevelIndex()+1);
        }

        timer += Time.deltaTime;
        if (timer > 5f){
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a-Time.deltaTime);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, textMeshPro.color.a-Time.deltaTime);
        }
    }
}
