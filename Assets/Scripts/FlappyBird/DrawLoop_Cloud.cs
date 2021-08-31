using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLoop_Cloud : MonoBehaviour
{
    public float speed = 1.0f;
    private float speed_;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        speed_ = speed;
        origin = transform.position;
        transform.Translate(-50, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyBirdManager.Instance.state == FlyBirdManager.State.Fly)
        {
            transform.Translate(-speed_ * FlyBirdManager.Instance.global_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-speed_/10 * Time.deltaTime, 0, 0);
        }

        if (origin.x - transform.position.x > 20)
        {
            transform.position = origin;
            speed_ = speed + Random.Range(-0.5f, 0.5f);

            transform.Translate(0, speed_ * 2 - 1, 0);    // y change
            transform.Translate(0, 0, -speed_ / 2);    // y change
            transform.localScale = new Vector3(1, 1, 1);
            transform.localScale *= speed_ / 2;
        }
        
    }
}
