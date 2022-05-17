using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int lives = 3;
    public int coins = 0;
    
    public Interface ui;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.instance != null)
        {
            MainManager.instance.inventory = this;
        }

        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<Interface>();
    }

    public void addLives(int value)
    {
        lives += value;
        ui.UpdateLives();
    }

    public void removeLives(int value)
    {
        lives -= value;
        ui.UpdateLives();
    }

    public void addCoins(int value)
    {
        coins += value;
        ui.UpdateCoins();
    }

    public void removeCoins(int value)
    {
        coins -= value;
        ui.UpdateCoins();
    }
}
