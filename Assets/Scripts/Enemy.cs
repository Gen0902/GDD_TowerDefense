using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 target;
    int wayPointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        target = NodeManager.Instance.wayPoints[0];


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.fixedDeltaTime);
        Vector3 dir = (Vector3)target - transform.position;

        transform.rotation = Quaternion.LookRotation(Vector2.Lerp(transform.right, dir, Time.fixedDeltaTime));

        //transform.rotation = Quaternion.LookRotation(dir.normalized * speed * Time.deltaTime,-Vector3.forward);

        if (transform.position == (Vector3)target && wayPointIndex < NodeManager.Instance.wayPoints.Count - 1)
        {
            target = NodeManager.Instance.wayPoints[++wayPointIndex];
        }
    }
}
