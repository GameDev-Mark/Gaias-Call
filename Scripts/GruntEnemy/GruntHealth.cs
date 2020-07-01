using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GruntHealth : MonoBehaviour
{
    //Variables
    private float maxHealth;
    private float currentHealth;
    private float minHealthDeath;

    private float playerMeleeDamage;

    public GameObject healthBarScale;
    public Animator enemyAnim;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    private GruntMovement _gruntMov;   // accessing grunt movement script
    



    //unitys start function
    private void Start()
    {
        maxHealth = 50f;
        currentHealth = maxHealth;
        minHealthDeath = 0f;

        playerMeleeDamage = 25f;

        enemyAnim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        _gruntMov = GetComponent<GruntMovement>();
    }


    // unitys update function
    private void Update()
    {
        GruntDeath();
    }


    // How much damage the enemy takes from player
    public void PlayerMeleeDamage()
    {
        if(maxHealth <= currentHealth)
        {
            healthBarScale.transform.localScale -= new Vector3(7f, 0.0f, 0f);
            maxHealth -= currentHealth = playerMeleeDamage;

            enemyAnim.SetTrigger("enemyRecieveDamage");
            //enemyAnim.SetBool("enemyRecieveDamageReset", true);
            //rb.AddForce(800, 0, 0, ForceMode.Force);
        }
        if(healthBarScale.transform.localScale == new Vector3(0f, 0f, 0f) && maxHealth <= minHealthDeath)
        {
            GruntDeath();
        }
    }

    
    //Enenmy Death
    public void GruntDeath()
    {
        if(maxHealth <= minHealthDeath)
        {
            enemyAnim.SetTrigger("enemyDeath");
            Destroy(gameObject, 3f);
            _gruntMov.enabled = false;
            navMeshAgent.velocity = Vector3.zero;
        }
    }

}
