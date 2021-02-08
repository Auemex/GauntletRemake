using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int dmg = 50;
    public int pSpeed = 1;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force * pSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Projectile Collision with " + other.gameObject);
        scr_Enemy1 e = other.collider.GetComponent<scr_Enemy1>();
        if (e != null)
        {
            e.TakeDamage(dmg);
        }

        scr_Enemy2 b = other.collider.GetComponent<scr_Enemy2>();
        if (b != null)
        {
            b.TakeDamage(dmg);
        }
        scr_spawner c = other.collider.GetComponent<scr_spawner>();
        if (c != null)
        {
            c.TakeDamage(dmg);
        }
    NoBullets();
}

void NoBullets()
{
    scr_PlayerController p = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>();
     if (p!=null)
     {
     p.CanShoott(1);
     }
    Destroy(gameObject);
}
}