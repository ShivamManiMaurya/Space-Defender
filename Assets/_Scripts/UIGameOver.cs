using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        if (scoreKeeper != null)
        {
            scoreText.text = "You Scored\n" + scoreKeeper.GetScore().ToString("000000000");
        }
    }

    
    

}
