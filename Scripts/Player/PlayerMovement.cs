using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed;
    Animator anim;
    Rigidbody rigid;
    //private CharacterController playerMov;



    private void Start()
    {
        movSpeed = 100f;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        //playerMov = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
     
        PlayerMove();
    }

    void PlayerMove()
    {
        if(Input.GetKey(KeyCode.D))
        {
            //Vector3 moveLeft = transform.TransformDirection(Vector3.forward);  // character controller move
            //playerMov.SimpleMove(moveLeft * movSpeed);

            rigid.velocity = transform.forward * movSpeed * Time.deltaTime;   // rigidbody move 

            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            anim.SetBool("joggingForward", true);
            Physics.gravity = new Vector3(0, -50, 0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            //Vector3 moveRight = transform.TransformDirection(Vector3.forward);   // character controller move
            //playerMov.SimpleMove(moveRight * movSpeed);

            rigid.velocity = transform.forward * movSpeed * Time.deltaTime;   // rigidbody move 

            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            anim.SetBool("joggingForward", true);
            Physics.gravity = new Vector3(0, -50, 0);
        }
        else
        {
            anim.SetBool("joggingForward", false);
        }

    }
}
