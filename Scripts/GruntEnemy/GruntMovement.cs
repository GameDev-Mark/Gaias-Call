using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GruntMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed;
    public float distanceToAttack;
    public float moveToPlayer;

    private Animator anim;
    private Rigidbody rb;

    public GameObject player;



    // start function in unity
    public void Start()
    {
        moveSpeed = 100f;
        distanceToAttack = 0.5f;
        moveToPlayer = 3.0f;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    // fixed update function in unity
    public void FixedUpdate()
    {
        AttackPlayer();
    }


    public void AttackPlayer()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (player && dist < moveToPlayer && dist >= distanceToAttack)
        {
            anim.SetBool("isWalking", true);

            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;

            Vector3 lookToPlayer = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            this.transform.LookAt(lookToPlayer);
        }
        else if (player && dist >= moveToPlayer || player && dist <= distanceToAttack)
        {
            transform.Translate(0, 0, 0);
            anim.SetBool("isWalking", false);
        }
    }
}
