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
        yield return new WaitForSeconds(1);
        levelTime = levelTimer;
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<Interface>();
        StartCoroutine(LevelCountdown());
    }

    IEnumerator LevelCountdown()
    {
        ui.Slider.value = 1;
        ui.Timer.text = levelTimer.ToString();

        while (levelTimer > 0)
        {
            yield return new WaitForSeconds(1);
            levelTimer -= 1;
            ui.Slider.value = (float) levelTimer / levelTime;
            ui.Timer.text = levelTimer.ToString();
        }
    }

    public void PlayerDied()
    {
        if(playerGotHit != true)
        {
            playerGotHit = true;
            Debug.Log("Game Over");

            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
