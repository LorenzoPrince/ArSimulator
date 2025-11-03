using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] balloons;
    public GameObject arCamera;
    public float spawnRadius = 3f;

    public float initialInterval = 10f;   // Al inicio (más lento)
    public float minInterval = 3f;       // Velocidad máxima (más rápido)
    public int balloonsPerWave = 1;
    public float difficultyIncreaseRate = 0.98f; // cada ciclo, 5% más rápido

    private float currentInterval;



    void Start()
    {
        currentInterval = initialInterval;
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(3f); // espera inicial

        while (true)
        {
            for (int i = 0; i < balloonsPerWave; i++)
            {
                SpawnBalloon();
                yield return new WaitForSeconds(1.8f); // tiempo entre globos de la misma tanda
            }

            yield return new WaitForSeconds(currentInterval);

            // Hacerlo un poquito más rápido con cada tanda
            currentInterval = Mathf.Max(minInterval, currentInterval * difficultyIncreaseRate);
        }
    }

    void SpawnBalloon()
    {
        Vector3 randomDirection = UnityEngine.Random.onUnitSphere;
        randomDirection.y = 0f;

        Vector3 spawnPos = arCamera.transform.position + randomDirection * UnityEngine.Random.Range(1.5f, spawnRadius);
        spawnPos.y = arCamera.transform.position.y - UnityEngine.Random.Range(0.8f, 1.5f);

        Quaternion rot = Quaternion.Euler(0, UnityEngine.Random.Range(0f, 360f), 0);
        GameObject balloonPrefab = balloons[UnityEngine.Random.Range(0, balloons.Length)];
        Instantiate(balloonPrefab, spawnPos, rot);
    }
}