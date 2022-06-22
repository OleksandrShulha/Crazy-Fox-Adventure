using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBombs : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(SetDisableBombs());
    }

    IEnumerator SetDisableBombs()
    {
        yield return new WaitForSeconds(5f);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisableBombs());
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
