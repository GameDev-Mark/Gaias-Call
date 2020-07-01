using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntMeleeAttack : MonoBehaviour
{
    //Variables
    private Animator anim;
    public GameObject player;
    public float distanceToAttack;


    // unitys start function
    private void Start()
    {
        anim = GetComponent<Animator>();
        distanceToAttack = 1.0f;
        InvokeRepeating("MeleeAttack", 2, 2);
    }



    // Enemy moves towards player and attacks when within range 
    void MeleeAttack()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (player && dist <= distanceToAttack)
        {
            player.GetComponent<PlayerHealth>().PlayerTakesDamage();  // access to player health script to damage the player

            anim.SetTrigger("canAttackIdle");
            //transform.LookAt(player.transform.position);
        }
        else if (player && dist > distanceToAttack)
        {
            anim.SetBool("canAttackReset", false);
        }
    }
}
