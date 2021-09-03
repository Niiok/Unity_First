using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_Foot : MonoBehaviour
{
    [Range(0f, 1f)]
    public float right_pos_weight = 1f;
    [Range(0f, 1f)]
    public float right_rot_weight = 0f;
    [Range(0f, 1f)]
    public float left_pos_weight = 1f;
    [Range(0f, 1f)]
    public float left_rot_weight = 0f;

    public bool Ik_active= true;
    public Vector3 foot_offset;
    public LayerMask ray_mask;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    RaycastHit ray_hit;

    private void OnAnimatorIK(int layerIndex)
    {
        if (Ik_active && anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
        {
            // right
            Vector3 foot_pos = anim.GetIKPosition(AvatarIKGoal.RightFoot);

            if (Physics.Raycast(foot_pos + Vector3.up, Vector3.down, out ray_hit, 1.5f, ray_mask))
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, right_pos_weight);
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, right_rot_weight);
                anim.SetIKPosition(AvatarIKGoal.RightFoot, ray_hit.point + foot_offset);
                
                if (right_rot_weight > 0.0f)
                {
                    Quaternion footRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, ray_hit.normal), ray_hit.normal);
                    anim.SetIKRotation(AvatarIKGoal.RightFoot, footRotation);
                }
            }
            else    // no hit
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0.0f);
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0.0f);
            }


            // left
            foot_pos = anim.GetIKPosition(AvatarIKGoal.LeftFoot);

            if (Physics.Raycast(foot_pos + Vector3.up, Vector3.down, out ray_hit, 1.2f, ray_mask))
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, left_pos_weight);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, left_rot_weight);
                anim.SetIKPosition(AvatarIKGoal.LeftFoot, ray_hit.point + foot_offset);
                
                if (left_rot_weight > 0.0f)
                {
                    Quaternion footRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, ray_hit.normal), ray_hit.normal);
                    anim.SetIKRotation(AvatarIKGoal.LeftFoot, footRotation);
                }
            }
            else    // no hit
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0.0f);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0.0f);
            }
        }
        else    // IK is inactive or anim not running Idle
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0f);
        }

    }
}