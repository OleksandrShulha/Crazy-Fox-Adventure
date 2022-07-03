using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanzerEnemy : MonoBehaviour
{
    float curentSpeed;
    int enemyHp;
    int currentHP;

    private void Start()
    {
        curentSpeed = gameObject.GetComponent<PatrolMorePoints>().GetSpeed();
        enemyHp = gameObject.GetComponent<Enemy>().GetHP();
        currentHP = enemyHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        currentHP = gameObject.GetComponent<Enemy>().GetHP();
        if (collision.gameObject.tag == "HammerBullet" && currentHP + 1 == enemyHp)
        {
            gameObject.GetComponent<PatrolMorePoints>().SetSpeed(curentSpeed * 2);
            gameObject.GetComponent<Enemy>().AnimationEnemy(4);
        }
    }



}
