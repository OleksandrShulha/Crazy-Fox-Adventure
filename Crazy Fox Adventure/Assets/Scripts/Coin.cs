using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinCost;
    Animator anim;
    Playr playr;


    void Start()
    {
        anim = GetComponent<Animator>();
        playr = FindObjectOfType<Playr>();
    }

    public int GetCoinCost()
    {
        return coinCost;
    }

    void TakeCoin()
    {
        AnimationCoin();
        Invoke("destroyCoin", 1f);
    }

    void AnimationCoin()
    {
        anim.SetInteger("state", 1);
    }

    void destroyCoin()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeCoin();
            playr.GetComponent<Playr>().SetCoin(coinCost);
        }
            
    }

}
