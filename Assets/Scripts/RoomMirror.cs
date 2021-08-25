using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMirror : MonoBehaviour
{
    private UnityEngine.Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<UnityEngine.Camera>();
    }

    private void OnPreCull()
    {
        cam.ResetProjectionMatrix();
        cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }

    private void OnPreRender()
    {
       GL.invertCulling = true;
    }

    private void OnPostRender()
    {
       GL.invertCulling = false;        
    }

    // Update is called once per frame
    void Update()
    {
    }


}
