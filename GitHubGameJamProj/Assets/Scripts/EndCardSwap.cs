using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndCardSwap : MonoBehaviour
{
    public Sprite[] cards;
    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        LevelOrder lo = FindObjectOfType<LevelOrder>();
        if (lo != null){
            UnityEngine.UI.Image image = GetComponent<UnityEngine.UI.Image>();
            int totalCoins = lo.GetTotalCoins();
            int collected = lo.GetCollectedCoins();
            if (collected == 0){
                image.sprite = cards[0];
            } else if (collected <= totalCoins/2){
                image.sprite = cards[1];
            } else if (collected < totalCoins){
                image.sprite = cards[2];
            } else {
                image.sprite = cards[3];
            }
            int dollars = collected/100;
            string dollarText = "$" + dollars + ".";
            int cents = collected%100;
            if (cents < 10){
                dollarText += "" + cents + "0";
            } else {
                dollarText += "" + cents;
            }
            textMesh.text = dollarText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
