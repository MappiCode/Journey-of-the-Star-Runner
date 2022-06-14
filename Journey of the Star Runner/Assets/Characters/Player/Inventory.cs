using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int lives = 3;
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.instance != null)
        {
            if (MainManager.instance.inventory == null)
                MainManager.instance.inventory = this;
        }
    }

    public void addLives(int value)
    {
        lives += value;
        MainManager.instance.ui.UpdateLives();
    }

    public void removeLives(int value)
    {
        lives -= value;
        MainManager.instance.ui.UpdateLives();
    }

    public void addCoins(int value)
    {
        coins += value;
        MainManager.instance.ui.UpdateCoins();
    }

    public void removeCoins(int value)
    {
        coins -= value;
        MainManager.instance.ui.UpdateCoins();
    }
}
