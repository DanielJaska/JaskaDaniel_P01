using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;

    [SerializeField] Transform enemyParent;

    [SerializeField] Transform target;

    [SerializeField] float _spawnTimer;

    private bool hasSpawned = false;
    
    private void Update()
    {
        if(hasSpawned == false && PlayerShip.playerState == PlayerShip.PlayerState.PLAYING)
        {
            StartCoroutine(SpawnDelay());
        }
        
    }

    private void Spawn()
    {
        int random = Random.Range(1, transform.childCount);
        GameObject temp = Instantiate(enemyToSpawn, enemyParent);
        temp.transform.position = transform.GetChild(Random.Range(0, transform.childCount)).position;
        temp.GetComponent<EnemyController>().SetTarget(target);
    }

    IEnumerator SpawnDelay()
    {
        hasSpawned = true;

        Spawn();
        
        yield return new WaitForSeconds(_spawnTimer);

        hasSpawned = false;
    }
}
