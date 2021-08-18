using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGlobal : MonoBehaviour
{
    private float speed = 0;
    public float accel = 0.1f;
    public float decel = 1;

    // Start is called before the first frame update
    void Start()
    {
        Mathf.Clamp(decel, 0, 100);
    }

    // Update is called once per frame
    void Update()
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

        this.transform.Translate(0.0f, 0.0f, speed*Time.deltaTime);
        speed *= ((float)(100 - decel) / 100);

        if(WS_pressed)
        {
            if (Input.GetKey(KeyCode.A))
                this.transform.Rotate(0.0f, -90.0f*Time.deltaTime, 0.0f);
            if (Input.GetKey(KeyCode.D))
                this.transform.Rotate(0.0f, 90.0f*Time.deltaTime, 0.0f);
        }
    }
}
