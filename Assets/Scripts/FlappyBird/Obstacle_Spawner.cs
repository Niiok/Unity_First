using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float interval = 1.5f;
    public float range = 1.0f;
    private float time = 0;

    void Start()
    {
    }

    void Update()
    {
        if(FlyBirdManager.Instance.state == FlyBirdManager.State.Fly)
        {
            time += Time.deltaTime;

            if(time >= interval)
            {
                transform.position = new Vector3(transform.position.x,
                Random.Range(-range, range) + 0.5f,
                transform.position.z);

                Instantiate(obstaclePrefab, transform.position, transform.rotation);

                time = 0;
            }
        }
    }

}
