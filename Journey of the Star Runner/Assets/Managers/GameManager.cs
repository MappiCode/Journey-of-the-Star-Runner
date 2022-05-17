using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int levelTimer = 10;
    int levelTime;

    bool playerGotHit = false;

    Interface ui;

    private IEnumerator Start()
    {
        levelTime = levelTimer;

        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<Interface>();

        yield return new WaitForSeconds(1);
        
        StartCoroutine(LevelCountdownCo());
    }

    IEnumerator LevelCountdownCo()
    {
        ui.Slider.value = 1;

        while (levelTimer > 0)
        {
            yield return new WaitForSeconds(1);
            levelTimer -= 1;
            ui.Slider.value = (float) levelTimer / levelTime;
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
