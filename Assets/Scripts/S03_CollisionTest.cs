using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03_CollisionTest : MonoBehaviour
{
    //float speedMove = 10.0f;
    //float speedRotate = 90.0f;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move_Rotate()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider : " + hitObject.name + " collide start");
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider : " + hitObject.name + " collide ing");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider : " + hitObject.name + " collide end");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger : " + hitObject.name + " trigger start");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger : " + hitObject.name + " trigger ing");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger : " + hitObject.name + " trigger end");
    }
}
