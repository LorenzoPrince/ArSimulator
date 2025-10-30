using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] ballons;
    void Start()
    {
        StartCoroutine(StarSpawning());
    }

    IEnumerator StarSpawning()
    {
        yield return new WaitForSeconds(4);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(ballons[i], spawnPoints[i].position, quaternion.identity);
        }
        yield return new WaitForSeconds(4);
        StartCoroutine(StarSpawning());
    }
}
