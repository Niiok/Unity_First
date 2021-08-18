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
        Rotate1();
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
}
