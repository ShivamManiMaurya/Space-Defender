using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
   

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _sceneLoadDelay = 2f;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
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
