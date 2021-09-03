using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGlobal : MonoBehaviour
{
    private float speed = 0;
    public float accel = 15f;
    public float decel = 1;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        decel = Mathf.Clamp(decel, 0, 100);
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        Update_rigid();
    }

    void Update_transform()
    {
        bool WS_pressed = false;

        if (Input.GetKey(KeyCode.W))
        {
            speed += accel;
            WS_pressed = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed -= accel;
            WS_pressed = true;
        }

        print("accel = " + accel);
        print("speed = " + speed);

        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        speed *= ((float)(100 - decel) / 100);

        if (WS_pressed)
        {
            if (Input.GetKey(KeyCode.A))
                this.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);

            if (Input.GetKey(KeyCode.D))
                this.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
        }
    }



    void Update_rigid()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = transform.forward * rigid.velocity.magnitude;
            rigid.AddForce(transform.forward * accel * rigid.mass);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(-rigid.velocity);
            rigid.AddForce(-transform.forward * accel * rigid.mass);
        }

        

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0.0f, -180.0f * Time.deltaTime, 0.0f);
            rigid.AddTorque(-transform.up * rigid.mass);
            rigid.AddForce(transform.right * rigid.velocity.magnitude);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f);
            rigid.AddTorque(transform.up * rigid.mass);
            rigid.AddForce(-transform.right * rigid.velocity.magnitude);
        }

        //if (Input.GetKey(KeyCode.A))
        //    rigid.AddRelativeTorque(Vector3.up * rigid.mass * -2);
        //if (Input.GetKey(KeyCode.D))
        //    rigid.AddRelativeTorque(Vector3.up * rigid.mass * 2);

    }
}
