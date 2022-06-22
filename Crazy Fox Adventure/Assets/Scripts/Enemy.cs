using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    Playr playr;

    private void Start()
    {
        playr = FindObjectOfType<Playr>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && (collision.gameObject.GetComponent<SpriteRenderer>().color.g == 1f))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HammerBullet")
        {
            Destroy(gameObject);
        }
    }

    void offRBonPlayr()
    {
        playr.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
