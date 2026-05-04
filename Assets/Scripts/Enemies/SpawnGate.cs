using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject bomberPrefab;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnRoutine()); 
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(bomberPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
