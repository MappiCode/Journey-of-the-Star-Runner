using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    

    public GameObject PauseMenuUI;

    public GameManager gm;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InvokeOnGameManager(string functionName)
    {
        gm.Invoke(functionName, 0);
    }

    
}
