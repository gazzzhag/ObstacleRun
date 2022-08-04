using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpawnManager spawnManager;

    public void Initialize(SpawnManager spawnManager)
    {
        this.spawnManager = spawnManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnManager.SpawnCoin();
            Destroy(gameObject);
        }
        
    }
}
