using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanKing : MonoBehaviour
{
    public float walk_speed = 1.0f;
    public float rot_speed = 900.0f;
    public GameObject weapon;

    Animation anim;
    Animation[] anims;
    CharacterController char_con;
    Vector3 velocity;

    void Start()
    {
        anim = GetComponentInChildren<Animation>();
        char_con = GetComponent<CharacterController>();

        anim.wrapMode = WrapMode.Loop;
        anim.Play("idle");
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //    anim.Play(anims[0]);
        if (Input.GetAxis("Fire1") > 0)
        {
            if (!anim.IsPlaying("attack"))
                StartCoroutine(CrossFade_FromTo("attack", "idle"));
        }

        ControllerUpdate();

        if (transform.position.y < -9)
            Destroy(gameObject);

    }

    void AnimUpdate()
    {

    }

    void ControllerUpdate()
    {
        if (!anim.IsPlaying("attack") && anim.IsPlaying("idle") || anim.IsPlaying("run"))
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"),
                                    0,
                                    Input.GetAxis("Vertical"));

            Vector3 limited = Vector3.Slerp(transform.forward,
                velocity,
                rot_speed * Time.deltaTime / Vector3.Angle(transform.forward, velocity));

            transform.LookAt(limited + transform.position);

            velocity *= walk_speed;

            char_con.SimpleMove(velocity);

            if (velocity.magnitude == 0)
            {
                if (anim.IsPlaying("run"))
                    anim.CrossFade("idle", 0.3f);
            }
            else if (anim.IsPlaying("idle"))
                anim.CrossFade("run", 0.3f);
        }
        else
        {
            char_con.SimpleMove(new Vector3(0,0,0));
        }

        return;
    }

    IEnumerator CrossFade_FromTo(string from, string to)
    {
        if (anim.IsPlaying(from) == true) yield break;

        weapon.SetActive(true);
        anim.wrapMode = WrapMode.Once;
        anim.CrossFade(from);

        float delay = anim.GetClip(from).length - 0.3f;

        yield return new WaitForSeconds(delay);

        anim.wrapMode = WrapMode.Loop;
        anim.CrossFade(to, 0.3f);
        weapon.SetActive(false);

    }
}
