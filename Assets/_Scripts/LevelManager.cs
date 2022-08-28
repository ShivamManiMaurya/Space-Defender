using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
   

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _sceneLoadDelay = 2f;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Game_Over", _sceneLoadDelay));
    }

    public void ExitGame()
    {
        Debug.Log("Quiting the game..");
        Application.Quit();
    }


    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


}
