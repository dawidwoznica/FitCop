using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Series : Skill {

    private const float shootsInterval = 0.1f;
    public override void Execute()
    {    
        StartCoroutine(SeriesShoot());
    }

    IEnumerator SeriesShoot()
    {
        for(int i = 0; i <= numberOfBullets; i++)
        {
            Instantiate(GameManager.Instance.enemyAmmunition[Random.Range(0, GameManager.Instance.enemyAmmunition.Length)], GameManager.Instance.enemyGunTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(shootsInterval);
        }

        Destroy(gameObject);
    }
}
