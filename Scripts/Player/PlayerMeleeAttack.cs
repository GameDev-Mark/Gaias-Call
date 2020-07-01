using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMeleeAttack : MonoBehaviour
{
    //Varibales
    private Animator playerAnim;

    private bool canAttack;
    private float coolDown;

    public GameObject gruntEnemy;


    // unity start function
    public void Start()
    {
        playerAnim = GetComponent<Animator>();

        canAttack = true;
        coolDown = 1.5f;
    }


    // unity update function
    public void Update()
    {
        if (canAttack && Input.GetMouseButton(0))
        {
            MeleeAttack();
            canAttack = false;
            Invoke("CoolDownAttack", coolDown);
        }
    }


    public void MeleeAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetTrigger("canAttack"); // player melee animation trigger
            Invoke("EnemyTakesDamage", 0.5f); // Takes away health from the enenmy at the correct time , mixing with the animation
        }
        else
        {
            playerAnim.SetBool("attackReset", false); // resets player melee animation 
        }
    }


    // Accessing the grunt enemy health script to take away health from it
    public void EnemyTakesDamage()
    {
        gruntEnemy.GetComponent<GruntHealth>().PlayerMeleeDamage(); // enemy grunt health
    }


    //Reset of attack.. cooldown between attacks as to not attack constantly..
    public void CoolDownAttack()
    {
        canAttack = true; // cool down of attack
    }
}
