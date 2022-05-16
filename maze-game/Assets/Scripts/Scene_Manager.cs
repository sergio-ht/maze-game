using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadGameEasy()
    {
        SceneManager.LoadScene("GameEasy");
    }
    
    public void LoadGameMedium()
    {
        SceneManager.LoadScene("GameMedium");
    }
    public void LoadGameHard()
    {
        SceneManager.LoadScene("GameHard");
    }
}
