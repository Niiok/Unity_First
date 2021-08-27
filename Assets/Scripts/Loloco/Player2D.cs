using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    Rigidbody2D rigid;
    float max_speed = 2500.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move_2D();
    }

    void Move_2D()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //RigidAddForce(x, y);
        RigidMovePosition(x, y);
    }

    void RigidMovePosition(float x, float y)
    {
        Vector3 position = transform.position;
        position.x += x * max_speed * Time.deltaTime;
        position.y += y * max_speed * Time.deltaTime;

        rigid.MovePosition(position);
    }

    void RigidAddForce(float x, float y)
    {
        rigid.AddForce(new Vector2(x * Time.deltaTime * max_speed, y * Time.deltaTime * max_speed));
    }
}

