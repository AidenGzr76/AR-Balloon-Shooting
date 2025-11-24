using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] balloonPrefabs;
    [SerializeField] private float delayBetweenWaves = 4f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBetweenWaves);

            foreach (Transform spawnPoint in spawnPoints)
            {
                // از بین بالن‌ها یکی رو رندوم انتخاب کن
                GameObject prefab = balloonPrefabs[Random.Range(0, balloonPrefabs.Length)];
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
