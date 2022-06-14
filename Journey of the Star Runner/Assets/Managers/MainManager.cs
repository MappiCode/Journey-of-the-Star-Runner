using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public Inventory inventory;
    public InGameUI ui;

    public string activeSceneName;
    public string lastSceneName;


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
