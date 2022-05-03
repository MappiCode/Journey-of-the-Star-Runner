using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins = 0;
    
    public Interface ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<Interface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoins(int value)
    {
        coins += value;
        ui.updateCoins();
    }

    public void removeCoins(int value)
    {
        coins -= value;
        ui.updateCoins();
    }
}
