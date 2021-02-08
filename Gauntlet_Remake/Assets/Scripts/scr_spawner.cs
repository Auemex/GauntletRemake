using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawner : MonoBehaviour
{
    public int health = 100;

    public GameObject EnemyPrefab;

    public float timeBetweenSpawn = 2.0f;

    bool inRange = false;
    bool isNotSpawning;
    float spawnCountdown;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        isNotSpawning = true;
        spawnCountdown = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
            if (spawnCountdown <= 0 && inRange == true)
        {
            Spawn();
            spawnCountdown = timeBetweenSpawn;
        }
        else
        {
            spawnCountdown -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        scr_EnemyAware controller = other.GetComponent<scr_EnemyAware>();
        if (controller != null)
        {
            inRange = true;
        }
    }

        void OnTriggerExit2D(Collider2D other)
    {
        scr_EnemyAware controller = other.GetComponent<scr_EnemyAware>();
        if (controller != null)
        {
            inRange = false;
        }
    }

    void Spawn()
    {
    // Debug.Log("an enemy has spawned!");    
    Instantiate(EnemyPrefab, rigidbody2d.position + Vector2.up * -1.0f, Quaternion.identity);
    isNotSpawning = false;
    }
        public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
        scr_ui u = GameObject.FindGameObjectWithTag("ui").GetComponent<scr_ui>();
        if (u!=null)
        {
        u.ChangeScore(10);
        }
            Die();
        }
    }

        void Die()
    {
        // Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
