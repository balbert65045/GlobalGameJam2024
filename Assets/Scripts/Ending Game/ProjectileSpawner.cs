using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject prefab;
    int[,] startPos = { {0, 6, 0, -1}, {10, 0, -1, 0}, {0, -6, 0, 1}, {-10, 0, 1, 0} };
    Random random = new Random();
    float spawnInterval = 2f;
    float nextInterval = 0.0f;
    
    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextInterval)
        {
            int index = random.Next(0, 5);
            nextInterval = Time.time + spawnInterval;
            Vector2 position = new Vector2((float)startPos[index, 0], (float)startPos[index, 1]);
            GameObject clone = Instantiate(prefab, position, Quaternion.identity);

        }
    }
}
