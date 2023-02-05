using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacholekController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = -transform.forward * 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("PlayerCar"))
        {
            other.gameObject.GetComponent<HealthController>().DealDamage(40);
        }
    }
}
