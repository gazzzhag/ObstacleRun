using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject particlePickupEffect;
    public GameObject coinPrefab;
    public GameObject player;
    public GameObject groundTile;
    

    Vector3 nextSpawnPointTile;
    Vector3 nextSpawnCoin;

    public void Awake()
    {
        Instantiate(coinPrefab, new Vector3(0,0,5), Quaternion.identity);
        nextSpawnPointTile = Vector3.zero;
    }


    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPointTile, Quaternion.identity);
        nextSpawnPointTile = temp.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }


    }

    public void SpawnCoin()
    {
        nextSpawnCoin += new Vector3(0, 0, 5);
        GameObject tempCoin = Instantiate(coinPrefab, nextSpawnCoin, Quaternion.identity);
    }
}
