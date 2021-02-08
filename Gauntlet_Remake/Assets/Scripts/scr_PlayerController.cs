using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scr_PlayerController : MonoBehaviour
{
    // movement
    float horizontal; 
    float vertical;
    public float speed = 3.0f;

    // health variables

    public int maxHealth = 500;
    public int health {get {return currentHealth; }}
    public int currentHealth;
    public int lives;

    // variables for being immune after taking damage
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    
    // key
    public int key; 

    Rigidbody2D rigidbody2d;

    public GameObject ProjectilePrefab;
    public int canShoot;
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    static int level = 1;
    
    // Start is called before the first frame update

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        key = 0;
        canShoot = 1;

        if (level == 1)
        {
            currentHealth = maxHealth;
            lives = 3;
        }
        else if (level == 2)
        {
            currentHealth = GameObject.FindGameObjectWithTag("ui").GetComponent<scr_ui>().healthTe;
            lives = GameObject.FindGameObjectWithTag("ui").GetComponent<scr_ui>().livesTe;
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

         if (!Mathf.Approximately(move.x,0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


                if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            isInvincible = false;
        }
            if (canShoot == 1)
        {
            if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f,LayerMask.GetMask("Door"));
            if (hit.collider !=null)
            {
                scr_door door = hit.collider.GetComponent<scr_door>();
                if (door !=null)
                {
                    if (key >= 1)
                    {
                          door.OpenDoor();
                          key --;                    
                    }
                }
            }
        }

        if (currentHealth <= 0)
        {
            if (lives == 0)
            {
                 SceneManager.LoadScene(sceneName: "Lose");    
            }
            currentHealth = maxHealth;
            SceneReload();
        }
        if (canShoot >= 1)
        {
            canShoot = 1;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth (int amount)
    {

    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    Debug.Log(currentHealth + "/" + maxHealth);

           if (amount < 0)
        {
            if (isInvincible)
            return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            //animator.SetTrigger("Hit");
            //PlaySound(hitSound);
        }

    }
    public void CanShoott (int bulletgone)
    {
        canShoot = canShoot + bulletgone;
        Debug.Log ("bullets on hand: " + canShoot);
    }

    void Launch()
    {
    GameObject projectileObject = Instantiate(ProjectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

    scr_Projectile projectile = projectileObject.GetComponent<scr_Projectile>();
    projectile.Launch(lookDirection, 300);
    canShoot = 0;
    animator.SetTrigger("Launch");
    Debug.Log ("bullets on hand: " + canShoot);
    }

    
    /*PlaySound(throwSound);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }*/
        public void OnCollisionEnter2D (Collision2D collision)
{
        if (collision.collider.tag == "Key")
        {
            key += 1;
            Destroy(collision.collider.gameObject);
            //Debug.Log ("number of keys on hand " + key);
        }
        if (collision.collider.tag == "Chest")
        {
            Destroy(collision.collider.gameObject);
        scr_ui u = GameObject.FindGameObjectWithTag("ui").GetComponent<scr_ui>();
        if (u!=null)
        {
        u.ChangeScore(100);
        }
           //PlaySound(chestPickup);
        }
        if (collision.collider.tag == "Exit")
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        level ++;
        }
}
        void SceneReload()
        {
            Rigidbody2D start_Rigidbody = GameObject.FindGameObjectWithTag("ui").GetComponent<Rigidbody2D>();
            transform.position = new Vector2 (start_Rigidbody.position.x, start_Rigidbody.position.y);
            lives --;
        }
}
