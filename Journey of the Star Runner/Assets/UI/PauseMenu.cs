using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public GameManager gm;
    public EventSystem es;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        es = GameObject.FindObjectOfType<EventSystem>().GetComponent<EventSystem>();

        es.firstSelectedGameObject = GetComponentInChildren<Button>(true).gameObject;
    }

    public void InvokeOnGameManager(string functionName)
    {
        if (gm == null)
            gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        gm.Invoke(functionName, 0);
    }
}
