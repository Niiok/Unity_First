using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanEnemy : MonoBehaviour
{
    public float walk_speed = 2.0f;
    Rigidbody rigid;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animation>();
        anim.wrapMode = WrapMode.Loop;
        GameManager_Spartan.Instance.enemy_count++;

        for (float i = GameManager_Spartan.Instance.score; i < 0; i -= 150)
            walk_speed *= 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager_Spartan.Instance.ground.transform.position + new Vector3(0,12.5f,0));
        if (transform.position.x > 1 || transform.position.x < -1 ||
        transform.position.z > 1 || transform.position.z < -1)
            rigid.AddForce(transform.forward * rigid.mass * walk_speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            GameManager_Spartan.Instance.score++;
            GameManager_Spartan.Instance.enemy_count--;
        }

        if (rigid.velocity.magnitude > 0.0)
        {
            if (anim.IsPlaying("idle"))
                anim.CrossFade("run", 0.3f);
        }
        else if (anim.IsPlaying("run"))
            anim.CrossFade("idle", 0.3f);
    }

  
}