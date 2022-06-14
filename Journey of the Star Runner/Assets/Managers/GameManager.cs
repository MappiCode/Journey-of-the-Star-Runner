using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public InGameUI inGameUI;

    public int levelTimer = 10;
    int levelTime;

    public int enemiesSpawned;
    public int enemiesKilled;

    public bool levelInAction = false;
    bool playerGotHit = false;
    bool GameIsPaused;
    public GameObject pauseMenuUI;

    private void Start()
    {
        levelTime = levelTimer;

        pauseMenuUI = GameObject.FindGameObjectWithTag("PauseMenuUI");
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        if(!inGameUI)
            inGameUI = GameObject.FindGameObjectWithTag("UI").GetComponent<InGameUI>();

        StartCoroutine(LevelCountdownCo());
    }

    private void Update()
    {
        //Pause Game when Escape Key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Not clean, Index higher than 2 should be the Levels 
            if (SceneManager.GetActiveScene().buildIndex > 2)
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
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    IEnumerator LevelCountdownCo()
    {
        levelInAction = true;
        if (inGameUI != null)
        {
            inGameUI.Slider.value = 1;

            yield return new WaitForSeconds(1);

            while (levelTimer > 0)
            {
                yield return new WaitForSeconds(1);
                levelTimer -= 1;
                inGameUI.Slider.value = (float)levelTimer / levelTime;
            }
            levelInAction = false;
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
