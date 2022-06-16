using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject qm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (qm.activeSelf)
                qm.SetActive(false);
            else
                qm.SetActive(true);
        }
    }
}
