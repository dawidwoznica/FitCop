using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPacholki : MonoBehaviour {

    public GameObject pacholek;


    void Start()
    {
        StartCoroutine(SpawnPacholek());
    }


    IEnumerator SpawnPacholek()
    {
        yield return new WaitForSeconds(3);
        while (GameManager.Instance.isPlayerAlive)
        {
            Instantiate(pacholek, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(3,5));
        }
    }  
}
