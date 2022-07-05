using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Animator anim;
    Playr playr;
    [SerializeField] GameObject drop;

    void Start()
    {
        anim = GetComponent<Animator>();
        playr = FindObjectOfType<Playr>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "HammerBullet" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "FreezBullet" || collision.gameObject.tag == "Rocket")
        {
            TakeBox();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HammerBullet")
            TakeBox();
    }

    void TakeBox()
    {
        AnimationBox();
        Invoke("destroyBox", 1f);
    }

    void AnimationBox()
    {
        anim.SetInteger("state", 1);
    }

    void destroyBox()
    {
        if (drop != null)
            Instantiate(drop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}