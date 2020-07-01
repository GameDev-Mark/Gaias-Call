using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool isOnGround;

    private float jumpPressure;
    [SerializeField] private float minJump;
    [SerializeField] private float maxJump;

    private Rigidbody rbody;
    private Animator anim;


    // Unity Start //
    void Start()
    {
        isOnGround = true;
        jumpPressure = 0f;
        minJump = 10f;
        maxJump = 13f;

        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //Physics.gravity = new Vector3(0, -50, 0);
        
    }


    // Unity Update //
    void Update()
    {
        if (isOnGround)
        {
            //holding jump button//
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJump)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJump;
                    anim.SetBool("canJumpReset", false);
                }
            }
            else
            {
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rbody.velocity = new Vector3(jumpPressure / 10f, jumpPressure, 0f);
                    jumpPressure = 0f;
                    isOnGround = false;
                    anim.SetTrigger("canJump");
                }
            }
        }
    }

    private void AnimationsDuringJump()
    {
    }

    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
