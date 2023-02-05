using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    public float speed;
    public float damage;
    public float lifetime;
    private Rigidbody rb;
    private float elapsedTime = 0;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        rb.velocity = -transform.forward * speed;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= lifetime)
            Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PlayerCar"))
        {
            Instantiate(GameManager.Instance.vegetableParticle, transform.position, Quaternion.identity);
            other.GetComponent<HealthController>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}