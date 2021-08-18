using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.UpArrow))
            this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            this.transform.Translate(0.0f, 0.0f, -speed * Time.deltaTime);
    }
}
