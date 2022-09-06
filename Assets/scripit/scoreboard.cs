using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreboard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    void Start() {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "START";
    }
    public void IncreaseScore(int amttoIncrease){
        score += amttoIncrease;
        scoreText.text = score.ToString();
    }
}
