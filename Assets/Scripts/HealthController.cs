using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public float health;
    public Slider hpSlider;
    public Image windScreen;
    public Image lostScreen;

    private void Update()
    {
        hpSlider.value = health;
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        if (gameObject.tag.Equals("PlayerCar"))
        {
            GameManager.Instance.isPlayerAlive = false;
            lostScreen.gameObject.SetActive(true);
        }

        else if (gameObject.tag.Equals("EnemyCar"))
        {
            GameManager.Instance.isEnemyAlive = false;
            windScreen.gameObject.SetActive(true);
        }
    
        Time.timeScale = 0;
    }
}
