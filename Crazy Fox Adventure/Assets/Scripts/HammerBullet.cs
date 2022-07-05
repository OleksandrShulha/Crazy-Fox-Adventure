using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SetDisableBombs());

    }

    IEnumerator SetDisableBombs()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
