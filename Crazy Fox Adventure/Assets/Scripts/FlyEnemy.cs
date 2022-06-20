using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public GameObject bomb;
    public float timeShoot;
    public Transform positionSpawn;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        timeShoot = Random.Range(1, 5);
        yield return new WaitForSeconds(timeShoot);
        Instantiate(bomb, positionSpawn.transform.position, positionSpawn.transform.rotation);
        StartCoroutine(Shooting());
    }
}
