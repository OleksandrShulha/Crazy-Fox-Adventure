 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    float lenght, startPosition;
    public GameObject myCamera;
    public float parallaxEffect;

    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = myCamera.transform.position.x * (1 - parallaxEffect);
        float dist = myCamera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if (temp > startPosition + lenght)
            startPosition += lenght;
        else if (temp < startPosition - lenght)
            startPosition -= lenght;
    }
}
