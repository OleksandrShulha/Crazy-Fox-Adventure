using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed = 3f;
    public Transform point1;
    public Transform point2;
    bool moveLeft = true;

    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        MoveToPoint();
    }


    private void MoveToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        if (transform.position == point1.position)
        {
            Transform rotatePoint = point1;
            point1 = point2;
            point2 = rotatePoint;
            if (moveLeft)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = true;
            }

            if (transform.position.x > point1.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

        }
    }
}
