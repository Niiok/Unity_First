using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S02_RaycastEx : MonoBehaviour
{

    [Range(0, 50)]
    public float distance = 10.0f;
    private RaycastHit rayHit;
    private RaycastHit[] rayHits;
    private Ray ray;

    private Transform otherTrans = null;

    private void Awake()
    {
        //otherTrans = GameObject.Find("Other").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        Ray_3();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color32(255, 255, 0, 255);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        DrawGizmos();
    }

    private void DrawGizmos()
    {
        if(rayHits != null)
        {
            for (int i = 0; i < this.rayHits.Length; ++i)
            {
                if (this.rayHits[i].collider != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);
                }

                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayHits[i].distance);

                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(rayHits[i].point, rayHits[i].point + rayHits[i].normal);

                Gizmos.color = new Color(1.0f, 0.0f, 1.0f);
                Vector3 reflect = Vector3.Reflect(this.transform.forward, rayHits[i].normal);
                Gizmos.DrawLine(rayHits[i].point, rayHits[i].point + reflect);
            }

        }
    }

    void Ray_1()
    {
        if(Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }

    void Ray_2()
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for (int i = 0; i < rayHits.Length; ++i)
        {
            Debug.Log(rayHits[i].collider.gameObject.name + "hit!");
        }
    }

    void Ray_3()
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for (int i = 0; i < rayHits.Length; ++i)
        {
            Debug.Log(rayHits[i].collider.gameObject.name + "hit!");


            //if(rayHits[i].collider.gameObject.tag == "Box")
            //    Debug.Log
        }
    }

    void Ray_FindObj()
    {
        Vector3 dir = otherTrans.position - this.transform.position;
        dir.Normalize();

        float dist = Vector3.Distance(otherTrans.transform.position, this.transform.position);
        Debug.DrawRay(ray.origin, dir * dist, Color.red);
    }
}
