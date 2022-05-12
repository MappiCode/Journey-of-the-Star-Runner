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

        Slider = gameObject.GetComponentInChildren<Slider>();

        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        updateLives();
        updateCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLives()
    {
        livesValueText.text = inventory.lives.ToString();
    }

    public void updateCoins()
    {
        coinsValueText.text = inventory.coins.ToString();
    }
}
