using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject look;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - look.transform.position;
        transform.forward = look.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_loc = transform.position;
        new_loc.x = look.transform.position.x + offset.x;
        new_loc.z = look.transform.position.z + offset.z;
        transform.position = new_loc;
    }
}
