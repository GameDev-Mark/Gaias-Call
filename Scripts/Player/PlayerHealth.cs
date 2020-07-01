using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Variables
    private int playerCurrentHealth;
    private int maxPlayerHealth;
    private int minHealth_Death;

    private int gruntDamage;

    private Animator anim;
    public Slider healthBar;
    private Rigidbody rigid;

    private PlayerMovement playerMov;
    private PlayerJump playerJump;

    // unitys start function
    public void Start()
    {
        maxPlayerHealth = 100;
        playerCurrentHealth = maxPlayerHealth;
        minHealth_Death = 0;

        gruntDamage = 25; // enemy damage

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

        playerMov = GetComponent<PlayerMovement>();  // playermovement script accessed 
        playerJump = GetComponent<PlayerJump>();  // playerjump script accessed
    }


    // player takes damage from enemy, depletes health bar
    public void PlayerTakesDamage()
    {
            if(maxPlayerHealth <= playerCurrentHealth)
            {
            anim.SetTrigger("playerOnHit");
            playerCurrentHealth -= maxPlayerHealth = gruntDamage;
            healthBar.value = playerCurrentHealth;


            if (playerCurrentHealth <= minHealth_Death) // play death function if at 0 or below
            {
                PlayerDeath();
            }
        }
       
    }


    // Player death function.. if at 0 = dead
    private void PlayerDeath()
    {
        anim.SetTrigger("isDead");
        playerMov.enabled = false;
        playerJump.enabled = false;

        Debug.Log("--------DEAD------");  // trigger death scene
    }

}
