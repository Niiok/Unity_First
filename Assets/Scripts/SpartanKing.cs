using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanKing : MonoBehaviour
{
    Animation anim;
    Animation[] anims;

    void Start()
    {
        anim = GetComponentInChildren<Animation>();

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //    anim.Play(anims[0]);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            anim.Play("idle");
        if (Input.GetKeyDown(KeyCode.Alpha0))
            anim.Play("idle");
        if (Input.GetKeyDown(KeyCode.Alpha0))
            anim.Play("idle");
        if (Input.GetKeyDown(KeyCode.Alpha0))
            anim.Play("idle");
        if (Input.GetKeyDown(KeyCode.Alpha0))
            anim.Play("idle");
    }
}
