using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt1();   
    }

    void LookAt1()
    {
        Vector3 direction_to_target = target.transform.position - this.transform.position;
        this.transform.forward = direction_to_target;
    }
}
