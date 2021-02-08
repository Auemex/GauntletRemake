using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ui : MonoBehaviour
{
    public Transform target;
    public Text scoreText; 
    public Text healthText;
    public Text livesText;


    public static int uiScore;
    public int maxScore = 999999;

    public static int healthT;
    public static int livesT;

    public int healthTe;
    public int livesTe;

    // Start is called before the first frame update
    void Awake()
    {
        SetCountText();
        healthTe = healthT;
        livesTe = livesT;
    }

    void Start()
    {
            //target = GameObject.FindGameObjectWithTag("Player").transform;
            healthT = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>().currentHealth;
            livesT = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>().lives;
    }

    // Update is called once per frame
    void Update()
    {
            //target = GameObject.FindGameObjectWithTag("Player").transform;
            healthT = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>().currentHealth;
            livesT = GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>().lives;
            SetCountText();
    }

    public void ChangeScore (int scoreAmount)
    {
        uiScore = Mathf.Clamp(uiScore + scoreAmount, 0, maxScore);
        SetCountText();
    }
     
        public void SetCountText ()
    {
        scoreText.text = "Score: " + uiScore.ToString();
        healthText.text = "Health: " + healthT.ToString();
        livesText.text = "Lives: " + livesT.ToString ();
    }
}
