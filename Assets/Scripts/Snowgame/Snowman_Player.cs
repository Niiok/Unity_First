using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman_Player : MonoBehaviour
{
    [Range(0, 100)]
    public float melt_speed = 6.0f;
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

        //CharacterControl_Slerp();
        SpinWithKey();

        if (transform.localScale.sqrMagnitude > GameManager.Instance.score)
            GameManager.Instance.score = (int)transform.localScale.sqrMagnitude;

        for (float i = GameManager.Instance.time_scale; i > 0; i--)
            transform.localScale -= transform.localScale * melt_speed / 100 * Time.deltaTime * (0.5f + GameManager.Instance.time_scale);

        if (transform.localScale.sqrMagnitude < 1e-1)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 mov = Vector3.zero;
        mov += transform.forward * Input.GetAxis("Vertical");
        mov += transform.right * Input.GetAxis("Horizontal");

        char_con.SimpleMove(mov * walk_speed);

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

    void SpinWithKey()
    {
        float spin = 0;
        if (Input.GetKey(KeyCode.Q))
            spin--;
        if (Input.GetKey(KeyCode.E))
            spin++;

        transform.Rotate(0, rot_speed * Time.deltaTime * spin, 0);
    }

}
