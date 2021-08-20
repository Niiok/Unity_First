using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float move_speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        this.transform.Translate(new Vector3(0.0f, 3.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Rotate3();
        Move3();
    }

    void Move1()
    {
        this.transform.Translate(new Vector3(0.0f, move_speed * Time.deltaTime, 0.0f));
    }

    void Rotate1()
    {
        //this.transform.rotation *= Quaternion.EulerAngles();
        this.transform.Rotate(Vector3.up * 45.0f * Time.deltaTime);
    }

    void Move3()
    {
        float z = Input.GetAxis("Vertical");
        z = z * move_speed * Time.deltaTime;
        gameObject.transform.Translate(0, 0, z);
    }

    void Rotate3()
    {
        float y = Input.GetAxis("Horizontal");
        y = y * 90 * Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(0, y, 0));
    }

    void Rotate4()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Vector3 dir = new Vector3(10, 0, 0) - transform.position;
            Vector3 dirXZ = new Vector3(dir.x, 0.0f, dir.z);

            if(dirXZ != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(dirXZ);
                Quaternion frameRot = Quaternion.RotateTowards(transform.rotation,
                    targetRot, move_speed * Time.deltaTime);
                transform.rotation = frameRot;
            }
        }
    }
}
