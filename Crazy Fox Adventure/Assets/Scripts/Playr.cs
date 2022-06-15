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

    private void FixedUpdate()
    {

            
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


        //if (Input.GetAxis("Horizontal") == 0 && (isGrounded))
        //    anim.SetInteger("State", 1);
        //else if (isGrounded)
        //    anim.SetInteger("State", 2);
        //else if (!isGrounded)
        //{
        //    anim.SetInteger("State", 3);
        //    //anim.SetInteger("State", 4);
        //}
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
            Debug.Log("Ded");
        }
    }



}
