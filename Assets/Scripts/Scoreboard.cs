using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Scoreboard : MonoBehaviour
{
       [SerializeField] TMP_Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
    
    }


    public void SumScore(){
        score++;
        scoreText.text = "Collectibles: " + score.ToString();
    }
}
