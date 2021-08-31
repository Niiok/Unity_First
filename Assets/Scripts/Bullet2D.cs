using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    public GameObject owner;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != owner && collision.rigidbody != null)
        {
            collision.rigidbody.bodyType = RigidbodyType2D.Dynamic;
            collision.rigidbody.AddTorque(180 * collision.rigidbody.mass*5);
            collision.rigidbody.AddForce(new Vector2(collision.rigidbody.mass*300*FlyBirdManager.Instance.global_speed, collision.rigidbody.mass*300));

            collision.collider.enabled = false;
            Destroy(collision.gameObject, 5.0f);
        }

            Destroy(gameObject);

    }

}
