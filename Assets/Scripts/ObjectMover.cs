using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    //variables
    public float speed = 5f;

    private Vector3 dir = Vector3.left;

    private bool movingLeft;

    void Start()
    {
        movingLeft = true;
    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x <= -6)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= 6)
        {
            dir = Vector3.left;
        }
    }
}
