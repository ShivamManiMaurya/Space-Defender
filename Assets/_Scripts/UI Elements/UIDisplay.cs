using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI textMeshPro;

    Health health;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        health = FindObjectOfType<Health>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthBar.maxValue = health.GetHealth();
    }

    public void UpdateHealth()
    {
        healthBar.value = health.GetHealth();
    }

    public void UpdateScore()
    {
        textMeshPro.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
