using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public InGameUI ui;
    
    public int levelTimer = 10;
    int levelTime;

    bool playerGotHit = false;

    bool GameIsPaused;
    GameObject pauseMenuUI;

    private void Start()
    {
        levelTime = levelTimer;

        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<InGameUI>();

        if (PauseMenu.instance != null)
        {
            PauseMenu.instance.gm = this;
            pauseMenuUI = PauseMenu.instance.PauseMenuUI;
        }

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
