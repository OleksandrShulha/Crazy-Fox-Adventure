using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int damageEnemy = collision.gameObject.GetComponent<Playr>().CurentPlayrHealth();
            collision.gameObject.GetComponent<Playr>().GetPlayrHealth(-damageEnemy);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
