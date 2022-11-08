using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> entityPrefab;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] float spawnDelay = 1f;
    [SerializeField] float spawnRadius = 0.33f;

    void Start()
    {
        StartCoroutine(SpawnEntity());
    }

    IEnumerator SpawnEntity()
    {
        while (true)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                int randomEntityIndex = Random.Range(0, entityPrefab.Count);
                Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
                Factory.Create(entityPrefab[randomEntityIndex], spawnPosition);
            }

            yield return new WaitForSeconds(spawnDelay * Random.Range(0.85f, 1.15f));
        }
    }
}
