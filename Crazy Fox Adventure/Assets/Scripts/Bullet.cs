using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool directionRight;
    Vector3 dir;
    public float weapons;
    [SerializeField] Vector3 distanceBullet;
    public Vector3 startPosotion;

    void Start()
    {
        startPosotion = transform.position;
        directionRight = FindObjectOfType<Playr>().GetComponent<Playr>().GetDirectionPlayr();
        dir = new Vector3(5.0f, 0.0f, 0.0f);
        if (!directionRight)
        {
            transform.localScale *= new Vector2(-1, 1);
            dir = new Vector3(-5.0f, 0.0f, 0.0f);
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * 10f);
        countDistanceBulet();
    }


    void countDistanceBulet()
    {
        if (transform.position.x >= startPosotion.x + distanceBullet.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Coin" && collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
