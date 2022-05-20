using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interface : MonoBehaviour
{
    public TextMeshProUGUI coinsValueText;
    public TextMeshProUGUI livesValueText;
    public TextMeshProUGUI Timer;
    public Slider Slider;
    
    Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI[] textChildren = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        coinsValueText = textChildren[0];
        livesValueText = textChildren[1];
        Timer = textChildren[2];

        coinsValueText = GetComponentInChildren<TextMeshProUGUI>();

        Slider = gameObject.GetComponentInChildren<Slider>();

        if (MainManager.instance != null)
        {
            inventory = MainManager.instance.inventory;
            MainManager.instance.ui = this;
        }
        else
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        UpdateLives();
        UpdateCoins();
    }

    public void UpdateLives()
    {
        livesValueText.text = inventory.lives.ToString();
    }

    public void UpdateCoins()
    {
        coinsValueText.text = inventory.coins.ToString();
    }
}
