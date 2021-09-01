using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMerge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "snow")
            return;

        if (collision.transform.localScale.y * 2 < transform.localScale.y)
        {
            transform.localScale += collision.transform.localScale;
        }
        else if(collision.transform.localScale.y > transform.localScale.y * 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "snow")
            return;

        if (other.transform.localScale.y * 2 < transform.localScale.y)
        {
            transform.localScale += other.transform.localScale;
        }
        else if(other.transform.localScale.y > transform.localScale.y * 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SnowBall_GameManager.Instance.snowballs.Add(gameObject);        
    }

    private void OnDisable()
    {
        SnowBall_GameManager.Instance.snowballs.Remove(gameObject);
    }
}
