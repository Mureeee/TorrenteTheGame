using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{

    public GameObject coinPrefab; // Asigna el prefab de moneda en el inspector
    public float spawnInterval = 20f; // Intervalo entre spawns
    public float minX = -1.8f, maxX = 1.8f; // Límites en el eje X
    public float spawnY = 5f; // Altura donde se generan las monedas

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", 10f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
