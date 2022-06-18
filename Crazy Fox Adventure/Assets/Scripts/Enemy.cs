using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public Playr playr;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //если касание обьекта з тегом
        if (collision.gameObject.tag == "Player" && (collision.gameObject.GetComponent<SpriteRenderer>().color.g == 1f))
        {

            collision.gameObject.GetComponent<Playr>().GetPlayrHealth(-damage);
            if (playr.GetComponent<Playr>().CurentPlayrHealth() > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
            }
            if (playr.GetComponent<Playr>().CurentPlayrHealth() <= 0)
                GetComponent<Collider2D>().enabled = false;

        }
    }
}