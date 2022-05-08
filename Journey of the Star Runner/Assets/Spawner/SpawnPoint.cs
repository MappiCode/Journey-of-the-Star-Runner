using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnDelay = 3f;

    GameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        
        StartCoroutine(SpawnEnemyCO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyCO()
    {
        while (manager.levelTimer > 0)
        {
            for (int i = 0; i < Random.Range(0, 3); i++)
            Instantiate(EnemyPrefab, gameObject.transform);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
