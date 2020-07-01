using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicAttack : MonoBehaviour
{
    //Variables
    public GameObject gruntEnemy;
    private Animator anim;
    private bool resetShoot; // bool resetting magic spell shot
    private float coolDownshoot;
    public GameObject _MagicShot;
    public GameObject castFrom;
    private float magicShootRate;



    // unity's start function
    public void Start()
    {
        anim = GetComponent<Animator>();
        resetShoot = true;
        coolDownshoot = 3f;
        magicShootRate = 30f;
    }


    // unity's update function
    public void Update()
    {
        if(Input.GetMouseButtonDown(1) && resetShoot)
        {
            MagicSpellAttack();
            Invoke("SpellAttackReset", coolDownshoot);
            resetShoot = false;
        }
    }


    // magic spell attack
    public void MagicSpellAttack()
    {
        anim.SetTrigger("canSpellAttack");
        GameObject magicBall = GameObject.Instantiate(_MagicShot, castFrom.transform.position, Quaternion.identity);
        magicBall.GetComponent<Rigidbody>().velocity = transform.forward * magicShootRate;
    }


    // player can only shoot every x seconds
    public void SpellAttackReset()
    {
        resetShoot = true;
    }




}
