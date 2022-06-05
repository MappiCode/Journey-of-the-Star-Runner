using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public GameManager gm;
    public GameObject pointer;

    public Collider2D ownCollider;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ownCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(gm.levelInAction == false && (gm.enemiesSpawned == gm.enemiesKilled))
        {
            pointer.SetActive(true);
            ownCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.LoadNextLevel();
        }
    }
}
