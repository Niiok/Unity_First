using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30 / speed); 
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyBirdManager.Instance.state == FlyBirdManager.State.Fly)
        {
            this.transform.Translate(-speed * FlyBirdManager.Instance.global_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            Destroy(gameObject, 0);
        }
    }
}
