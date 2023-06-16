using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    public GameObject deathEffect;
    private Transform target;

    private int wavepointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += value;
        Destroy(gameObject);
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
                EndPath();
                return;
            }

            wavepointIndex++;
            target = WayPoints.points[wavepointIndex];
        }

        void EndPath()
        {
            PlayerStats.Lives--;
            Destroy(gameObject);
            
        }

    }
}
