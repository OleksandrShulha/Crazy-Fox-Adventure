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
    Main main;
    public bool onAtakc = false;

    void Start()
    {
        main = FindObjectOfType<Main>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curentPlayrHp = maxPlayrHp;
    }

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
        anim.SetBool("onAtack", onAtakc);
        anim.SetInteger("HP", curentPlayrHp);
    }

    private void MovePlayr()
    {

        if (curentPlayrHp > 0)
        {
            moveVector.x = Input.GetAxis("Horizontal");
            if (!onAtakc)
                rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !onAtakc)
            {
                //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                onAtakc = true;
                rb.velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                onAtakc = false;
            }
        }
        else
            rb.velocity = new Vector2(0,rb.velocity.y);
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
            OnHit();
        }
    }

    IEnumerator ChangeColorOnHit()
    {
        yield return new WaitForSeconds(0.02f);
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
