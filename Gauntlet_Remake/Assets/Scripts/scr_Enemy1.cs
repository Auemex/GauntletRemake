using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy1 : MonoBehaviour
{
    public int health = 100;
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    
    Rigidbody2D rgb2D;
    float timer;
    int direction = 1;

    // Enemy 1 Animation
    Animator animator;

    //private scr_PlayerController scr_playerController;
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D> ();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {

        Vector2 position = rgb2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
        position.x = position.x + Time.deltaTime * speed * direction;
        animator.SetFloat("Move X", direction);
        animator.SetFloat("Move Y", 0);
        }

        rgb2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        scr_PlayerController player = other.gameObject.GetComponent<scr_PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-25);
            Die();
        }
    }

        public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
        scr_ui u = GameObject.FindGameObjectWithTag("ui").GetComponent<scr_ui>();
        if (u!=null)
        {
        u.ChangeScore(1);
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
