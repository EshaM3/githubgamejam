using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetLevelText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    LevelOrder levelOrder;
    // Update is called once per frame
    void Update()
    {
        if (levelOrder == null){
            levelOrder = FindObjectOfType<LevelOrder>();
        }
        if (levelOrder != null){
            textMeshPro.text = "" + (levelOrder.LevelIndex()+1);
        }
    }
}
