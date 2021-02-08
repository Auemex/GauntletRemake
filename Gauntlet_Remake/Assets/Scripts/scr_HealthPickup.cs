using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HealthPickup : MonoBehaviour
{
  //public AudioClip collectedClip;
  void OnTriggerEnter2D(Collider2D other)
    {
       scr_PlayerController controller = other.GetComponent<scr_PlayerController>();
       
       if (controller != null)
       {
           if (controller.health < controller.maxHealth)
           {
           controller.ChangeHealth(1);
           Destroy (gameObject);

           //controller.PlaySound(collectedClip);
           }
       }
    }
}
