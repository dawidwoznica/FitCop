using UnityEngine;

public class PlayerController : MonoBehaviour {

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    public float speed;
    public float tilt;
    public Boundary boundary;
    public SingleJoystick singleJoystick;

    Vector3 input01;
    private Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

   

    void FixedUpdate()
    {
        input01 = singleJoystick.GetInputDirection();

        float xMovementInput01 = input01.x;
        float zMovementInput01 = input01.y;

   

            float tempAngle = Mathf.Atan2(zMovementInput01, xMovementInput01);
            xMovementInput01 *= Mathf.Abs(Mathf.Cos(tempAngle));
            zMovementInput01 *= Mathf.Abs(Mathf.Sin(tempAngle));

            input01 = new Vector3(xMovementInput01, 0, zMovementInput01);
            input01 = transform.TransformDirection(input01);
            input01 *= speed;

            Vector3 temp = transform.position;
            temp.x += xMovementInput01;
            temp.z += zMovementInput01;
            Vector3 lookingVector = temp - transform.position;
          

            //rigidBody.transform.Translate(input01 * Time.fixedDeltaTime);



            //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xMovementInput01, 0.0f, zMovementInput01);
        rigidBody.velocity = movement * speed;

        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidBody.rotation = Quaternion.Euler(0.0f, rigidBody.velocity.x * tilt, rigidBody.velocity.x * tilt/2);
    }
}