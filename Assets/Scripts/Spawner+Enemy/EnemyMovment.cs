using UnityEngine;
using UnityEngine.UI;

public class EnemyMovment : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed = 10f;

    public int startHealth = 100;
    private float health;

    public int value = 50;
    private bool isDead = false;

    public GameObject deathEffect;
    private Transform target;

    public Image healthBar;
    private int wavepointIndex = 0;

    void Start()
    {
        speed = startSpeed;
        target = WayPoints.points[0];
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        PlayerStats.moneyCount += PlayerStats.Money;
        PlayerStats.kils++;
        PlayerStats.Money += value;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
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
            PlayerStats.gamesCount++;
            PlayerStats.Lives--;
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
            
        }

    }
}
