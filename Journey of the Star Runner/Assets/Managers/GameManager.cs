using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int levelTimer = 10;

    bool playerGotHit = false;

    Interface ui;

    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<Interface>();
        StartCoroutine(LevelCountdown());
    }

    IEnumerator LevelCountdown()
    {
        ui.Timer.text = levelTimer.ToString();
        while (levelTimer > 0)
        {
            yield return new WaitForSeconds(1);
            levelTimer -= 1;
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
