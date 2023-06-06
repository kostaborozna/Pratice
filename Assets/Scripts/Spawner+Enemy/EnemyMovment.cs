using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;

    private int wavepointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {

            if(wavepointIndex >= WayPoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex++;
            target = WayPoints.points[wavepointIndex];
        }

    }
}
