using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public GameObject look;
    private Vector3 offset;
    private UnityEngine.Camera main_cam;

    private Vector3 default_pos;
    private Quaternion default_rot;
    private float default_zoom;

    // Start is called before the first frame update
    void Start()
    {
        //main_cam = GetComponent<UnityEngine.Camera>();
        //default_pos = transform.position;
        //default_rot = transform.rotation;
        //default_zoom = main_cam.fieldOfView;

        offset = this.transform.position - look.transform.position;
        //transform.forward = look.transform.position - transform.position;
        //transform.LookAt(look.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_loc = transform.position;
        new_loc.x = look.transform.position.x + offset.x;
        new_loc.z = look.transform.position.z + offset.z;
        transform.position = new_loc;
        //AdvancedUpdate();
    }

    void AdvancedUpdate()
    {
        MoveCamera();
        RotateCamera();
        ZoomCamera();
        InitCamera();
    }

    void MoveCamera()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Input.GetAxisRaw("Mouse X") / 10.0f,
            Input.GetAxisRaw("Mouse Y") / 10.0f,
            0.0f);
        }
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Input.GetAxisRaw("Mouse Y") * 10.0f,
                0.0f, 0.0f);

            transform.Rotate(0.0f,
                Input.GetAxisRaw("Mouse X") * 10.0f,
                0.0f);
        }
    }

    void ZoomCamera()
    {
        main_cam.fieldOfView += Input.GetAxis("Mouse ScrollWheel") * 20;
    }

    void InitCamera()
    {
        if (Input.GetMouseButton(2))
        {
            transform.position = default_pos;
            transform.rotation = default_rot;
            main_cam.fieldOfView = default_zoom;
        }
    }
}

