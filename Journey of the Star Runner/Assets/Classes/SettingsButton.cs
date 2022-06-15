using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject[] menus;

    public void OnSelect(BaseEventData eventData)
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        menus[0].SetActive(true);
    }

    public void OnDeselect(BaseEventData eventDate)
    {
        
    }
}
