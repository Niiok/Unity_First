using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    public float interval = 3.0f;
    public GameObject snows;
    public float range = 20.0f;
    private float term = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        term -= Time.deltaTime;

        if (term < 0)
            
        {
            transform.position = new Vector3(
                Random.Range(-range/2, range/2),
                transform.position.y,
                Random.Range(-range/2, range/2));

            Instantiate(snows, transform.position, transform.rotation);

            term = interval * GameManager.Instance.global_speed * (1 + GameManager.Instance.time_scale);
        }
    }
}
