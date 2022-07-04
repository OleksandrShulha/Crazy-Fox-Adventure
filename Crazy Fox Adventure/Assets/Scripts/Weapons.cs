using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    Playr playr;
    [SerializeField] Sprite[] weaponSprite;
    float timeSpownBulet = 0f;

    void Start()
    {
        playr = FindObjectOfType<Playr>();
    }

    void Update()
    {
        ChooseWeapons();
    }


    public void ChooseWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(0);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[0];
            timeSpownBulet = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(1);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[1];
            timeSpownBulet = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(2);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[2];
            timeSpownBulet = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(3);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[1];
            timeSpownBulet = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(4);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[4];
            timeSpownBulet = 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(5);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[5];
            timeSpownBulet = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            playr.GetComponent<Playr>().SetTypeWeapons(6);
            GetComponent<SpriteRenderer>().sprite = weaponSprite[6];
            timeSpownBulet = 2f;
        }
    }


    public float GetTimeSpowmBullet()
    {
        return timeSpownBulet;
    }
}
