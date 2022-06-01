using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        if(!MainManager.instance)
        {
            Debug.Log("Reset Inventory");
            MainManager.instance.inventory.lives = 3;
            MainManager.instance.inventory.coins = 0;
        }
        SceneManager.LoadScene("GameScene1");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}
