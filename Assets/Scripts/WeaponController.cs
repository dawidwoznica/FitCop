using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject[] ammunition;
    private Coroutine shootingCoroutine;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //   Shoot();      
    }

    public void Shoot()
    {
        Instantiate(ammunition[Random.Range(0, ammunition.Length)], GameManager.Instance.playerGunTransform.position, GameManager.Instance.playerGunTransform.rotation);
    }

    private void FixedUpdate()
    {
        //transform.LookAt(GameManager.Instance.mousePositionObject.transform);
    }
}
