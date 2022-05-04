using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool playerGotHit = false;

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
