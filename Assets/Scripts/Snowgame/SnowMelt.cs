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
    void Update()
    {
        for (float i = GameManager.Instance.time_scale; i > 0; i--)
            transform.localScale -= transform.localScale * melt_speed / 100 * Time.deltaTime * (0.5f + GameManager.Instance.time_scale);

        if (light_comp != null)
            light_comp.range = transform.localScale.magnitude;

        if (transform.localScale.sqrMagnitude < 1e-1)
        {
            Destroy(gameObject);
        }
    }
}
