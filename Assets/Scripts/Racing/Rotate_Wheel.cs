using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Wheel : MonoBehaviour
{
    public float spin_per_second = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, -360.0f * spin_per_second * Time.deltaTime, 0.0f);
    }
}
