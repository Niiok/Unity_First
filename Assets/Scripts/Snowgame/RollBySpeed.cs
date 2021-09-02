using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBySpeed : MonoBehaviour
{
    Rigidbody rigid;
    UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponentInParent<Rigidbody>();
        nav = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (nav.destination != rigid.transform.position)
            //transform.Rotate(rigid.velocity.z * 10000, 0, rigid.velocity.x * 10000);
    }
}
