using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jump_power = 10.0f;
    private Rigidbody2D rigid = null;
    private SpriteRenderer sprite_renderer;
    private Animator animator;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        FlyBirdManager.Instance.score = 0;
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        animator.Play("Base Layer.bird_idle");
        animator.speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (FlyBirdManager.Instance.state)
        {
            case FlyBirdManager.State.Sleep:
                Update_Sleep();
                break;

            case FlyBirdManager.State.Fly:
                Update_Fly();
                break;

            case FlyBirdManager.State.Ko:
                Update_Ko();
                break;

            default:
                break;
        }



    }

    void Update_Sleep()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {


            animator.Play("Base Layer.bird_fly");
            animator.speed = 1;
            rigid.AddForce(jump_power * Vector2.up * rigid.mass * 2);
            FlyBirdManager.Instance.state = FlyBirdManager.State.Fly;
        }
    }

    void Update_Fly()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            rigid.AddForce(jump_power * Vector2.up * rigid.mass);
        }

        transform.rotation = Quaternion.AngleAxis(rigid.velocity.y / rigid.mass * 5, transform.forward);
    }

    void Update_Ko()
    {
        if (rigid.velocity.y == 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            sprite_renderer.sprite = sprites[8];


            if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                rigid.AddForce(jump_power * Vector2.up * rigid.mass * 0.5f);

                animator.enabled = true;
                animator.Play("Base Layer.bird_idle");
                animator.speed = 0.2f;
                FlyBirdManager.Instance.state = FlyBirdManager.State.Sleep;
                FlyBirdManager.Instance.score = 0;
            }
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (FlyBirdManager.Instance.state)
        {
            //case FlyBirdManager.State.Sleep:
            //    Update_Sleep();
            //    break;

            case FlyBirdManager.State.Fly:
                CollisionEnter_Fly();
                break;

            //case FlyBirdManager.State.Ko:
            //    Update_Ko();
            //    break;

            default:
                break;
        }
    }

    void CollisionEnter_Fly()
    {
        animator.enabled = false;
        sprite_renderer.sprite = sprites[3];

        FlyBirdManager.Instance.state = FlyBirdManager.State.Ko;
    }

    //void CollisionEnter_()
    //{
    //    animator.enabled = false;
    //    sprite_renderer.sprite = sprites[3];
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlyBirdManager.Instance.score += 1;
    }

    private void OnGUI()
    {
        float width = Screen.width;
        float height = Screen.height;

        if (FlyBirdManager.Instance.state == FlyBirdManager.State.Fly)
        {
            GUI.Box(new Rect(width / 2 - width / 20, height / 20, width / 10, height / 10), "\n" + FlyBirdManager.Instance.score.ToString());
        }
        else if (FlyBirdManager.Instance.state == FlyBirdManager.State.Ko)
        {
            GUI.Box(new Rect(width / 2 - width / 10, height / 10, width / 5, height / 5), "Your \nScore \nis \n\n" + FlyBirdManager.Instance.score.ToString());
        }
        else if (FlyBirdManager.Instance.state == FlyBirdManager.State.Sleep)
        {
            GUI.Box(new Rect(width / 2 - width / 10, height / 2 - height / 10, width / 5, height / 5), "\nPress \nto \nStart!");
        }
    }
}
