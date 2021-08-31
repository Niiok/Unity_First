using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : MonoBehaviour
{
    public float speed = 5.0f;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30 / speed);
        audio = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.Play();
    }
}
