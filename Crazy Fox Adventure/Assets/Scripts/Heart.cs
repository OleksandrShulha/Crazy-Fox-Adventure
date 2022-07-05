using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Animator anim;
    Playr playr;

    void Start()
    {
        anim = GetComponent<Animator>();
        playr = FindObjectOfType<Playr>();
    }

    void TakeHeart()
    {
        AnimationHeart();
        Invoke("destroyHeart", 1f);
    }

    void AnimationHeart()
    {
        anim.SetInteger("state", 1);
    }

    void destroyHeart()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeHeart();
            playr.GetComponent<Playr>().SetPlayrHealth(1);
        }

    }
}

