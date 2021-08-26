using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDrive : MonoBehaviour
{
    public float speed = 3.0f;
    public float speed_limit = 100.0f;
    public float ray_distance = 10.0f;
    private bool left_exist = false;
    private bool right_exist = false;
    private RaycastHit left_hit;
    private RaycastHit right_hit;
    private Ray ray;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;

        Rotate_rigid(ChooseDirection());
        MoveFront_rigid();
    }

    private void OnDrawGizmos()
    {
        if (left_exist)
            Gizmos.DrawLine(ray.origin, left_hit.point);
        if (right_exist)
            Gizmos.DrawLine(ray.origin, right_hit.point);

    }

    int ChooseDirection()
    {
        // check left
        ray.direction = this.transform.forward - transform.right;
        left_exist = Physics.Raycast(ray, out left_hit, ray_distance);
        // check right
        ray.direction = this.transform.forward + transform.right;
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

    void MoveFront()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Rotate(int direction)
    {
        if (direction == 1)
            this.transform.Rotate(Vector3.up * 30 * Time.deltaTime);
        else if (direction == -1)
            this.transform.Rotate(Vector3.up * -30 * Time.deltaTime);

        return;
    }

    void MoveFront_rigid()
    {
        rigid.velocity = transform.forward * rigid.velocity.magnitude;

        if (rigid.velocity.magnitude < speed_limit)
            rigid.AddForce(transform.forward * speed / 2 * rigid.mass);
    }

    void Rotate_rigid(int direction)
    {
        //if(Mathf.Abs(direction) == 2)
        //        rigid.AddForce(-rigid.velocity);
        switch (direction)
        {
            case -2:
            case -1:
                this.transform.Rotate(0.0f, -180.0f * Time.deltaTime, 0.0f);
                rigid.AddTorque(-transform.up * rigid.mass);
                rigid.AddForce(-rigid.velocity);
                break;
            case 2:
            case 1:
                this.transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f);
                rigid.AddTorque(transform.up * rigid.mass);
                rigid.AddForce(-rigid.velocity);
                break;
            case 0:
                rigid.AddForce(transform.forward * speed / 2 * rigid.mass);
                break;
        }
    }
}
