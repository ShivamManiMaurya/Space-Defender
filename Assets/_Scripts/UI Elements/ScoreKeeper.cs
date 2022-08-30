using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;

    private static ScoreKeeper scoreKeeperInstance;

    private void Awake()
    {
        ScoreSingleton();
    }

    private void ScoreSingleton()
    {
        if (scoreKeeperInstance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreKeeperInstance = this;
            DontDestroyOnLoad(scoreKeeperInstance);
        }
    }


    public int GetScore()
    {
        return _score;
    }

    public void ModifyScore(int value)
    {
        _score += value;
        Mathf.Clamp(_score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
