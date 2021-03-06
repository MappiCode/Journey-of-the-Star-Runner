using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI coinsValueText;
    public TextMeshProUGUI livesValueText;
    public TextMeshProUGUI Timer;
    public Slider Slider;
    
    Inventory inventory;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        TextMeshProUGUI[] textChildren = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        coinsValueText = textChildren[0];
        livesValueText = textChildren[1];

        coinsValueText = GetComponentInChildren<TextMeshProUGUI>();

        Slider = gameObject.GetComponentInChildren<Slider>();

        if (MainManager.instance != null)
        {
            inventory = MainManager.instance.inventory;
            MainManager.instance.ui = this;
        }
        else
        {
            Debug.Log("In-Game UI couldn't find a MainManager");
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }


        UpdateLives();
        UpdateCoins();
    }

    private void Update()
    {
        if (gm.levelInAction == false && (gm.enemiesSpawned == gm.enemiesKilled))
        {
            Slider.gameObject.SetActive(false);
        }
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
