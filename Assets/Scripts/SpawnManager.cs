using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject particlePickupEffect;
    public Coin coinPrefab;
    public GameObject player;
    public GameObject groundTile;

    private Vector3 nextSpawnPointTile;
    private Vector3 nextSpawnCoin;

    public void Awake()
    {
        SpawnCoin();
        nextSpawnPointTile = Vector3.zero;
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPointTile, Quaternion.identity);
        nextSpawnPointTile = temp.transform.GetChild(1).transform.position;
    }

    public void SpawnCoin()
    {
        int randomPosX = Random.Range(-5, 5);
        nextSpawnCoin += new Vector3(randomPosX, 0, 5);

        Coin coin = Instantiate(coinPrefab, new Vector3(randomPosX,0, nextSpawnCoin.z), Quaternion.identity);
        coin.Initialize(this);
    }
}
