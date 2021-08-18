using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheel : MonoBehaviour
{
    private float spin = 0;
    public float spin_per_second = 1;

    private float rolling = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0.0f, -rolling, 0.0f);
        this.transform.Rotate(-spin, 0.0f, 0.0f);
        //this.transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.forward);

        if (Input.GetKey(KeyCode.A))
            spin += 90*Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            spin -= 90*Time.deltaTime;
        //if (!Input.anyKey)
        //    spin = 0;

        spin = Mathf.Clamp(spin, -45.0f, 45.0f);

        rolling += -360.0f * spin_per_second * Time.deltaTime;
        if (rolling > 360)
            rolling -= 360;
        else if (rolling < -360)
            rolling += 360;

        spin *= 0.96f;

        this.transform.Rotate(spin, 0.0f, 0.0f);
        this.transform.Rotate(0.0f, rolling, 0.0f);

    }
}
