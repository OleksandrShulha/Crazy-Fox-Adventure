using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMorePoints : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] point;
    bool moveLeft = true;
    int pointToGo = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(point[0].position.x, point[0].position.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPoint();
    }


    private void MoveToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, point[pointToGo].position, speed * Time.deltaTime);
        if (transform.position == point[pointToGo].position)
        {
            if (pointToGo < point.Length - 1)
            {
                pointToGo++;
            }
                
            else
            {
                pointToGo = 0;
            }
                
        }

        if (transform.position.x > point[pointToGo].position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
