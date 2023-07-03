using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public int countEnemy = 10;
    public GameObject[] obj;

    private void Start()
    {
        StartCoroutine(SpawnWithTimeOut());
    }

    private void Create()
    {
        Instantiate(obj[UnityEngine.Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
    }

    IEnumerator SpawnWithTimeOut()
    {
        for (int i = 0; i < countEnemy; i++)
        {
            Create();
            yield return new WaitForSeconds(1);
        }
    }
}