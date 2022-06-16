using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //если касание обьекта з тегом
        if (collision.gameObject.tag == "Player")
        {
            int damageEnemy = collision.gameObject.GetComponent<Playr>().CurentPlayrHealth();
            collision.gameObject.GetComponent<Playr>().GetPlayrHealth(-damageEnemy);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
