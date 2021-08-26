using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLoop : MonoBehaviour
{
    public float speed = 1.0f;
    private float speed_;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        speed_ = speed;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyBirdManager.Instance.state == FlyBirdManager.State.Fly)
        {
            transform.Translate(-speed_ * Time.deltaTime, 0, 0);

            if (origin.x - transform.position.x > 20)
                transform.position = origin;
        }
    }
}
