using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    Animator anim;
    Weapons weapons;
    [SerializeField] int typeWeapons;
    [SerializeField] float timeSpownBulet;

    void Start()
    {
        anim = GetComponent<Animator>();
        weapons = FindObjectOfType<Weapons>();
    }

    void TakeGun()
    {
        AnimationGun();
        Invoke("destroyGun", 1f);
    }

    void AnimationGun()
    {
        anim.SetInteger("state", 1);
    }

    void destroyGun()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeGun();
            weapons.GetComponent<Weapons>().pickUpWeapon(typeWeapons, timeSpownBulet);
        }

    }

}
