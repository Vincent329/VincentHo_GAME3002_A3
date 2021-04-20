using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void QuitGame()
    {
        Application.Quit(); // only works in a standalone build, not in the editor
    }
}
