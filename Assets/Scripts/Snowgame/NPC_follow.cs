using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_follow : MonoBehaviour
{
    public GameObject smaller_target = null;
    public GameObject bigger_target = null;
    public float walk_speed = 5.0f;
    public float avoid_distance = 1.0f;

    UnityEngine.AI.NavMeshAgent nav_agent;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        nav_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav_agent.speed = walk_speed;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nav_agent != null)
        {
            if (smaller_target != null && smaller_target.activeSelf == true)
                nav_agent.SetDestination(smaller_target.transform.position);
            else
                smaller_target = FindSmaller();


            if (bigger_target != null && bigger_target.activeSelf == true)
                if ((bigger_target.transform.position - transform.position).magnitude < avoid_distance * bigger_target.transform.localScale.y)
                    nav_agent.SetDestination(transform.position*2 - bigger_target.transform.position);
            else
                bigger_target = FindBigger();

            rigid.velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        smaller_target = FindSmaller();
        bigger_target = FindBigger();

        //nav_agent.speed = walk_speed * 2 / transform.localScale.y;
    }

    GameObject FindSmaller()
    {
        GameObject closest = SnowBall_GameManager.Instance.snowballs[0];

        for(int i = 1;  i < SnowBall_GameManager.Instance.snowballs.Count; ++i)
        {
            if (SnowBall_GameManager.Instance.snowballs[i].transform.localScale.y * 2 < transform.localScale.y)
                if ((closest.transform.position - transform.position).sqrMagnitude >
                    (SnowBall_GameManager.Instance.snowballs[i].transform.position - transform.position).sqrMagnitude ||
                    closest.transform.localScale.y * 2 > transform.localScale.y)
                    closest = SnowBall_GameManager.Instance.snowballs[i];
        }

        if (closest == gameObject)
            return null;

        return closest;
    }

    GameObject FindBigger()
    {
        GameObject closest = SnowBall_GameManager.Instance.snowballs[0];

        for(int i = 1;  i < SnowBall_GameManager.Instance.snowballs.Count; ++i)
        {
            if (SnowBall_GameManager.Instance.snowballs[i].transform.localScale.y > transform.localScale.y * 2)
                if ((closest.transform.position - transform.position).sqrMagnitude >
                    (SnowBall_GameManager.Instance.snowballs[i].transform.position - transform.position).sqrMagnitude ||
                    closest.transform.localScale.y < transform.localScale.y * 2)
                    closest = SnowBall_GameManager.Instance.snowballs[i];
        }

        if (closest == gameObject)
            return null;

        return closest;
    }
}
