using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playr : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed;
    public float jumpHeight;
    public Transform groundChek;
    bool isGrounded;
    Animator anim;
    public bool faceRight = true;
    public int maxPlayrHp = 3;
    public int curentPlayrHp;
    public bool isHit = false;
    public Main main;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curentPlayrHp = maxPlayrHp;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        AnimationPlayr();
        MovePlayr();
        Reflect();
    }

    private void Reflect()
    {
        if((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundChek.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }

    void AnimationPlayr()
    {
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        anim.SetBool("onGround", isGrounded);
        anim.SetInteger("HP", curentPlayrHp);
    }

    private void MovePlayr()
    {

        if (curentPlayrHp > 0)
        {
            moveVector.x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
            //rb.AddForce(Vector2.up * 0);

        }


    }

    public int CurentPlayrHealth()
    {
        return curentPlayrHp;
    }

    public void GetPlayrHealth(int deltaHp)
    {
     
        if (curentPlayrHp > 0)
            curentPlayrHp += deltaHp;

        if (curentPlayrHp <= 0)
        {
            Invoke("Lose", 3f);
        }
        if (deltaHp < 0 && (GetComponent<SpriteRenderer>().color.g == 1f))
        {
            isHit = true;
            //StartCoroutine(ChangeColorOnHit());
            OnHit();
        }
    }

    IEnumerator ChangeColorOnHit()
    {
        yield return new WaitForSeconds(0.02f);
        Debug.Log("test");
        OnHit();
    }


    private void OnHit()
    {
        if (isHit)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g - 0.04f, GetComponent<SpriteRenderer>().color.b - 0.04f);
            if (GetComponent<SpriteRenderer>().color.g <= 0)
            {
                isHit = false;
            }
            StartCoroutine(ChangeColorOnHit());

        }

        while (!isHit && (GetComponent<SpriteRenderer>().color.g < 1f))
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, GetComponent<SpriteRenderer>().color.g + 0.04f, GetComponent<SpriteRenderer>().color.b + 0.04f);
            if (GetComponent<SpriteRenderer>().color.g >= 1f || (curentPlayrHp <= 0))
            {
                break;
            }
            StartCoroutine(ChangeColorOnHit());
        }
    }


    void Lose()
    {
        main.GetComponent<Main>().Lose();
    }

}
