using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playr : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Main main;
    Weapons weapons;


    public Vector2 moveVector;
    public float speed;
    public float jumpHeight;
    public Transform groundChek;
    bool isGrounded;
    bool faceRight = true;
    public int maxPlayrHp = 3;
    public int curentPlayrHp;
    bool isHit = false;
    bool onAtakc = false;
    public bool onClimp = false;
    bool lvlComplete = false;
    public int typeOfWeapons=0;

    public GameObject hammerBullet;
    public Transform pointHammerBullet;
    public GameObject[] bullet;
    public Transform pointBullet;
    public bool isBulletCreate=false;
    public int coinLVL = 0;
    

    Coroutine shot;

    void Start()
    {
        main = FindObjectOfType<Main>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapons = FindObjectOfType<Weapons>();
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

    public bool GetDirectionPlayr()
    {
        return faceRight;
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
        anim.SetBool("onClimp", onClimp);
        anim.SetBool("LVLCompleted", lvlComplete);
    }

    private void MovePlayr()
    {

        if (curentPlayrHp > 0 && lvlComplete == false)
        {
            moveVector.x = Input.GetAxis("Horizontal");
            if (!onAtakc)
                rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !onAtakc)
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                //rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            if (Input.GetKey(KeyCode.Z) && isGrounded && typeOfWeapons==0)
            {
                //rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                onAtakc = true;
                rb.velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.Z) && typeOfWeapons==0)
            {
                onAtakc = false;
            }
            if (Input.GetKey(KeyCode.Z) && typeOfWeapons > 0 && isBulletCreate==false)
            {
                isBulletCreate = true;
                shot = StartCoroutine(CreateBullet());
            }
        }
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (transform.position.y <= -11f)
        {
            Invoke("Lose", 3f);
        }
    }

    public int CurentPlayrHealth()
    {
        return curentPlayrHp;
    }

    public int GetMaxPlayrHealth()
    {
        return maxPlayrHp;
    }





    public void SetPlayrHealth(int deltaHp)
    {
     
        if (curentPlayrHp > 0 && deltaHp < 0)
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

        if (curentPlayrHp > 0 && deltaHp > 0)
        {
            if (curentPlayrHp < maxPlayrHp)
                curentPlayrHp += deltaHp;
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


    public void CreateHammerBullet()
    {
        Instantiate(hammerBullet, pointHammerBullet.transform.position, pointHammerBullet.transform.rotation);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ladder") { }
        {
            if (Input.GetAxis("Vertical") !=0)
            {
                onClimp = true;
                rb.bodyType = RigidbodyType2D.Kinematic;
                transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * 0.5f * Time.deltaTime);
            }
            else
            {
                onClimp = false;
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder") { }
        {
            onClimp = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            StartCoroutine(EnableActivitePlayr());
        }
    }

    public void SetCoin(int coinCost)
    {
        coinLVL += coinCost;
        main.GetComponent<Main>().SetCoinTextOnGameUI(coinLVL);
    }

    public int GetCoin()
    {
        return coinLVL;
    }
    

    

    IEnumerator EnableActivitePlayr()
    {
        yield return new WaitForSeconds(0.3f);
        lvlComplete = true;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        FindObjectOfType<Door>().GetComponent<Door>().AnimationState(2);
    }

    public void SetTypeWeapons(int typeOfWeapons)
    {
        this.typeOfWeapons = typeOfWeapons;
    }

    public int GetTypeWeapons()
    {
        return typeOfWeapons;
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet[GetTypeWeapons()], pointBullet.transform.position, pointBullet.transform.rotation);
        yield return new WaitForSeconds(weapons.GetComponent<Weapons>().GetTimeSpowmBullet());
        isBulletCreate = false;
    }
}
