using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public Interface ui;
    
    public int levelTimer = 10;
    int levelTime;

    bool GameIsPaused;

    bool playerGotHit = false;


    private void Start()
    {
        GameIsPaused = false;

        levelTime = levelTimer;

        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<Interface>();
        
        StartCoroutine(LevelCountdownCo());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    IEnumerator LevelCountdownCo()
    {
        if (ui != null)
        {
            ui.Slider.value = 1;

            yield return new WaitForSeconds(1);

            while (levelTimer > 0)
            {
                yield return new WaitForSeconds(1);
                levelTimer -= 1;
                ui.Slider.value = (float)levelTimer / levelTime;
                //Debug.Log(ui.Slider.value);
            }
        }
    }

    public void PlayerDied()
    {
        if(playerGotHit != true)
        {
            playerGotHit = true;
            Debug.Log("Game Over");

            StopCoroutine(LevelCountdownCo());

            SceneManager.LoadScene("GameOverScreen");
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
}
