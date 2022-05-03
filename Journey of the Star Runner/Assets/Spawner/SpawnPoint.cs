using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject EnemyPrefab;

    bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        StartCoroutine(SpawnEnemyCO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyCO()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(5);
            for (int i = 0; i < Random.Range(0, 3); i++)
            Instantiate(EnemyPrefab, gameObject.transform);
        }
    }
}
