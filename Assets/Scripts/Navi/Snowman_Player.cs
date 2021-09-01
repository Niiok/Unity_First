using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman_Player : MonoBehaviour
{
    [Range(0, 100)]
    public float melt_speed = 2.0f;
    public float walk_speed = 5.0f;
    public float rot_speed = 360.0f;

    CharacterController char_con;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        char_con = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        CharacterControl_Slerp();

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


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale -= transform.localScale * melt_speed / 100 * Time.deltaTime;
        char_con.SimpleMove(direction * walk_speed);

        if (transform.localScale.sqrMagnitude < 1e-1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "snow")
            return;

        if (other.transform.localScale.y * 2 < transform.localScale.y)
        {
            transform.localScale += other.transform.localScale;
        }
        else if (other.transform.localScale.y > transform.localScale.y * 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SnowBall_GameManager.Instance.snowballs.Add(gameObject);
    }

    private void OnDisable()
    {
        SnowBall_GameManager.Instance.snowballs.Remove(gameObject);
    }
}
