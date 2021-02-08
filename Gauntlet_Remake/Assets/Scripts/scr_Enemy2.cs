using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy2 : MonoBehaviour
{
    public int health = 100;
    public float speed;
    public float stoppingDistance;
    public float oldXPosition;
    public float oldYPosition;
    Rigidbody2D rgb2D;
    bool vertical;
    int direction = 1;

    bool inRange = false;
    public Transform player; 
    Animator animator;

    void Awake()
    {
        oldXPosition = transform.position.x;
        oldYPosition = transform.position.y;
    }
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D> ();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPositionX = new Vector2(player.position.x, transform.position.y);
        Vector2 targetPositionY = new Vector2(transform.position.x, player.position.y);

            if ((inRange == true) && (Vector2.Distance(transform.position, player.position) > stoppingDistance))
        {
            transform.position = Vector2.MoveTowards(currentPosition, targetPositionX, speed * Time.deltaTime);
            vertical = true;

            if (Vector2.Distance(currentPosition,targetPositionX) == stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(currentPosition, targetPositionY, speed * Time.deltaTime);
                vertical = false;
            }
        }
        if (currentPosition.x > oldXPosition)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        if (currentPosition.y > oldYPosition)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
        void FixedUpdate()
    {
        
        if (vertical)
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        else
        {
        animator.SetFloat("Move X", 0);
        animator.SetFloat("Move Y", direction);
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

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <=0)
        {
        scr_ui u = GameObject.FindGameObjectWithTag("ui").GetComponent<scr_ui>();
        if (u!=null)
        {
        u.ChangeScore(1);
        }
            Die();
        }
        
    }
        void OnCollisionEnter2D(Collision2D other)
    {
        scr_PlayerController player = other.gameObject.GetComponent<scr_PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-50);
            Die();
        }
    }
    void Die()
    {
        // Instantiate (deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
