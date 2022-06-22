using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    Playr playr;
    public int HP = 1;
    Animator anim;
    int stateAnimatiom = 0;

    private void Start()
    {
        playr = FindObjectOfType<Playr>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimationEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && (collision.gameObject.GetComponent<SpriteRenderer>().color.g == 1f) && HP>0)
        {
            collision.gameObject.GetComponent<Playr>().GetPlayrHealth(-damage);
            if (playr.GetComponent<Playr>().CurentPlayrHealth() > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
            }
            if (playr.GetComponent<Playr>().CurentPlayrHealth() <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                Invoke("offRBonPlayr", 1f);
            }     
        }
    }

    void offRBonPlayr()
    {
        playr.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "HammerBullet")
        {
            HP -= 1;
            if (HP <= 0)
            {
                stateAnimatiom = 1;
                GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<PatrolMorePoints>().SetSpeed(0);
                Destroy(gameObject, 1f);
            }
        }
    }


    void AnimationEnemy()
    {
        anim.SetInteger("state", stateAnimatiom);
    }
}
