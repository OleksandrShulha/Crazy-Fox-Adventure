using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    Playr playr;
    public int HP = 1;
    Animator anim;
    [SerializeField] int coinEnemy;

    private void Start()
    {
        playr = FindObjectOfType<Playr>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && (collision.gameObject.GetComponent<SpriteRenderer>().color.g == 1f) && HP>0)
        {
            collision.gameObject.GetComponent<Playr>().SetPlayrHealth(-damage);
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
            StartCoroutine(FlashingEnemyOnKick());
            if (HP <= 0)
            {
                AnimationEnemy(1);
                DestroyEnemy();
            }
        }
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "FreezBullet")
        {
            HP -= 1;
            if (HP <= 0)
            {
                AnimationEnemy(2);
                DestroyEnemy();
            }
            else
                StartCoroutine(FlashingEnemyOnKick());
        }

        if (collision.gameObject.tag == "Rocket")
        {
            AnimationEnemy(2);
            DestroyEnemy();
        }
    }

    public void AnimationEnemy(int stateAnimatiom)
    {
        anim.SetInteger("state", stateAnimatiom);
    }


    IEnumerator FlashingEnemyOnKick()
    {
        int i = 1;
        GetComponent<Collider2D>().enabled = false;
        while (i <= 4)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
        GetComponent<Collider2D>().enabled = true;
    }

    public int GetHP()
    {
        return HP;
    }


    void DestroyEnemy()
    {
        GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<PatrolMorePoints>().SetSpeed(0);
        Destroy(gameObject, 1f);
        playr.GetComponent<Playr>().SetCoin(coinEnemy);
    }

}
