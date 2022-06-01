using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public Inventory inventory;
    public InGameUI ui;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        inventory = GetComponent<Inventory>();

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
