using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanimPlayer : MonoBehaviour
{
    public float run_speed = 5.0f;
    public float rot_speed = 360.0f;

    CharacterController char_con;
    Vector3 direction;
    Animator anim;
    //Ray ray;
    //RaycastHit ray_hit_lf;
    //RaycastHit ray_hit_rf;

    public GameObject IKobject;

    // Start is called before the first frame update
    void Start()
    {
        char_con = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Jump");
        direction.z = Input.GetAxis("Vertical");

        CharacterControl_Slerp();

        char_con.SimpleMove(direction * run_speed);

        //IKraycast();

        anim.SetFloat("Speed", direction.magnitude);

        anim.SetFloat("Fire1", Input.GetAxis("Fire1"));
    }

    void CharacterControl_Slerp()
    {
        Vector3 limit;
        limit.x = direction.x;
        limit.y = 0;
        limit.z = direction.z;

        if (limit.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, limit,
                rot_speed * Time.deltaTime / Vector3.Angle(transform.forward, limit));

            transform.LookAt(transform.position + forward);
        }

    }

    //private void OnAnimatorIK(int layerIndex)
    //{
    //    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
    //    {
    //        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
    //        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);

    //        ray.origin = char_con.transform.position + char_con.transform.right / 6 + transform.up;
    //        ray.direction = -transform.up;

    //        Physics.Raycast(ray, out ray_hit_rf, transform.localScale.magnitude*4);

    //        anim.SetIKPosition(AvatarIKGoal.RightFoot, ray_hit_rf.point);
    //        //anim.SetIKPosition(AvatarIKGoal.RightFoot, IKobject.transform.position);


    //        ray.origin = char_con.transform.position - char_con.transform.right / 6 + transform.up;
    //        ray.direction = -transform.up;

    //        Physics.Raycast(ray, out ray_hit_lf, transform.localScale.magnitude*4);

    //        anim.SetIKPosition(AvatarIKGoal.LeftFoot, ray_hit_lf.point);
    //        //anim.SetIKPosition(AvatarIKGoal.LeftFoot, IKobject.transform.position);
    //    }
    //}

    //private void OnDrawGizmos()
    //{
        
    //    Gizmos.DrawLine(ray.origin + transform.right/3, ray_hit_rf.point);
    //    Gizmos.DrawLine(ray.origin, ray_hit_lf.point);
    //}


}
