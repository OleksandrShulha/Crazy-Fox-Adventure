using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool directionRight;
    Vector3 dir;


    void Start()
    {
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
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
