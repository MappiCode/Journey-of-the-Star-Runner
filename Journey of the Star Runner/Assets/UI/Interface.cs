using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interface : MonoBehaviour
{
    public TextMeshProUGUI coinsValueText;
    
    Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCoins()
    {
        coinsValueText.text = inventory.coins.ToString();
    }
}
