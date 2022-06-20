using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    float speedCamera = 3f;
    public Transform targetCamera;
    Playr playr;

    // Start is called before the first frame update
    void Start()
    {
        playr = FindObjectOfType<Playr>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(playr.GetComponent<Playr>().CurentPlayrHealth() > 0)
            MoveCameraOnPlayr();
    }


    private void MoveCameraOnPlayr()
    {
        Vector3 position = targetCamera.position;
        position.z = transform.position.z;
        position.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, position, speedCamera * Time.deltaTime);
    }
}
