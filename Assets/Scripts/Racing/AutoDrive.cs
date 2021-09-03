using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoDrive : MonoBehaviour
{
    public float speed = 15.0f;
    public float speed_limit = 100.0f;
    public float handling = 180.0f;

    public float ray_distance = 10.0f;
    public float ray_angle = 45.0f;


    bool left_exist = false;
    bool right_exist = false;
    RaycastHit left_hit;
    RaycastHit right_hit;
    Ray ray;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray.origin = transform.position;

        Rotate_rigid(ChooseDirection());
        MoveFront_rigid();
    }

    int ChooseDirection()
    {
        // check left
        ray.origin = transform.position - transform.right/2;
        ray.direction = Quaternion.Euler(0, -ray_angle, 0) * transform.forward;
        left_exist = Physics.Raycast(ray, out left_hit, ray_distance);
        // check right
        ray.origin = transform.position + transform.right/2;
        ray.direction = Quaternion.Euler(0, ray_angle, 0) * transform.forward;
        right_exist = Physics.Raycast(ray, out right_hit, ray_distance);

        if (left_exist && right_exist)
        {
            if (left_hit.distance > right_hit.distance)
                if (right_hit.distance < ray_distance / 2)
                    return -2;
                else
                    return -1;
            else if (left_hit.distance < right_hit.distance)
                if (left_hit.distance < ray_distance / 2)
                    return 2;
                else
                    return 1;
            else
                return 0;
        }
        else if (left_exist)
            if (left_hit.distance < ray_distance / 2)
                return 2;
            else
                return 1;
        else if (right_exist)
            if (right_hit.distance < ray_distance / 2)
                return -2;
            else
                return -1;
        else
            return 0;
    }


    void MoveFront_rigid()
    {
        rigid.velocity = transform.forward * rigid.velocity.magnitude;

        if (rigid.velocity.magnitude < speed_limit)
            rigid.AddForce(transform.forward * speed * rigid.mass);
    }

    void Rotate_rigid(int direction)
    {
        //if(Mathf.Abs(direction) == 2)
        //        rigid.AddForce(-rigid.velocity);
        switch (direction)
        {
            case -2:
            case -1:
                this.transform.Rotate(0.0f, -handling * Time.deltaTime, 0.0f);
                rigid.AddTorque(-transform.up * rigid.mass);
                rigid.AddForce(-rigid.velocity);
                break;
            case 2:
            case 1:
                this.transform.Rotate(0.0f, handling * Time.deltaTime, 0.0f);
                rigid.AddTorque(transform.up * rigid.mass);
                rigid.AddForce(-rigid.velocity);
                break;
            case 0:
                rigid.AddForce(transform.forward * speed * rigid.mass);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        if (left_exist)
            Gizmos.DrawLine(transform.position - transform.right/2, left_hit.point);
        if (right_exist)
            Gizmos.DrawLine(ray.origin, right_hit.point);

    }




    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////
    /// </summary>
    [Obsolete]
    void MoveFront()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    [Obsolete]
    void Rotate(int direction)
    {
        if (direction == 1)
            this.transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        else if (direction == -1)
            this.transform.Rotate(Vector3.up * -30 * Time.deltaTime);

        return;
    }
}
