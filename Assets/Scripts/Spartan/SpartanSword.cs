using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanSword : MonoBehaviour
{
    private Collider owner_col;
    private Rigidbody sword_rigid;

    // Start is called before the first frame update
    void Start()
    {
        owner_col = GetComponentInParent<Collider>();
        sword_rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != owner_col)
        {
            collision.rigidbody.AddForce(sword_rigid.mass * transform.forward);
        }
    }
}
