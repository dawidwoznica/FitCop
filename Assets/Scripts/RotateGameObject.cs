using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGameObject : MonoBehaviour {

    public float rot_speed_x = 0;
    public float rot_speed_y = 0;
    public float rot_speed_z = 0;
    public bool local = false;

    void Update()
    {
        if (local)
        {
            var rotation = transform.localEulerAngles;
            transform.localEulerAngles = new Vector3(
                rotation.x + rot_speed_x * Time.deltaTime,
                rotation.y + rot_speed_y * Time.deltaTime,
                rotation.z + rot_speed_z * Time.deltaTime);
        }
        else
        {
            var rotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(
                rotation.x + rot_speed_x * Time.deltaTime,
                rotation.y + rot_speed_y * Time.deltaTime,
                rotation.z + rot_speed_z * Time.deltaTime);
        }
    }
}
