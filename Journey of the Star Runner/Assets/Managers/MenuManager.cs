using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        if (MainManager.instance != null)
        {
            if (MainManager.instance.activeSceneName != null)
                MainManager.instance.lastSceneName = MainManager.instance.activeSceneName;
            MainManager.instance.activeSceneName = SceneManager.GetActiveScene().name;
        }
    }

    public void StartGame()
    {
        if(MainManager.instance)
        {
            Debug.Log("Reset Inventory");
            MainManager.instance.inventory.lives = 3;
            MainManager.instance.inventory.coins = 0;
        }
        SceneManager.LoadScene("GameScene1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            if (activeSceneName.StartsWith("GameScene"))
                return;
            else
                LoadLastScene();
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLastScene()
    {
        SceneManager.LoadScene(MainManager.instance.lastSceneName);
    }

    public void EndApplication()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
