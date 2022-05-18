using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    public int value = 1;


    Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inventory;
    }

    void Collected()
    {
        playerInventory.addCoins(value);
    }
}
