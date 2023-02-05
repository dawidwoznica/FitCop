using System.Collections;
using UnityEngine;

public class CitySpawn : MonoBehaviour {

    public GameObject[] prefabs;
    public float prefabSpawnWaitFrom;
    public float prefabSpawnWaitTo;
    public float fromPositionX;
    public float toPositionX;
    public float fromPositionZ;
    public float toPositionZ;

    private void Start()
    {
        StartCoroutine(SpawnPrefabs());
    }

    IEnumerator SpawnPrefabs()
    {
        while (GameManager.Instance.isPlayerAlive)
        {
            Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)], GetSpawnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(UnityEngine.Random.Range(prefabSpawnWaitFrom, prefabSpawnWaitTo));
        }
    }

    Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(fromPositionX, toPositionX), 0, (Random.Range(fromPositionZ, toPositionZ)));
    }
}
