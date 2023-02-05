using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volley : Skill {

    private const float shootsAngle = 90;
    public override void Execute()
    {
        VolleyShoot();
    }

    void VolleyShoot()
    {
        float angleStep = shootsAngle / numberOfBullets;
        float angle = -shootsAngle / 2;
        while (angle < shootsAngle / 2)
        {
            Instantiate(GameManager.Instance.enemyAmmunition[Random.Range(0, GameManager.Instance.enemyAmmunition.Length)], GameManager.Instance.enemyGunTransform.position, Quaternion.Euler(0, angle, 0));
            angle += angleStep;
        }
        Destroy(gameObject);
    }
}