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
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void InvokeOnGameManager(string functionName)
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        gm.Invoke(functionName, 0);
    }
}
