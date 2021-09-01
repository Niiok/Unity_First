using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMelt : MonoBehaviour
{
    [Range(0, 100)]
    public float melt_speed = 2.0f;

    Light light_comp;

    // Start is called before the first frame update
    void Start()
    {
        light_comp = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale -= transform.localScale * melt_speed/100 * Time.deltaTime;
        if (light_comp != null)
            light_comp.range = transform.localScale.magnitude;

        if (transform.localScale.sqrMagnitude < 1e-1)
        {
            Destroy(gameObject);
        }
    }
}
