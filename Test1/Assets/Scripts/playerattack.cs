﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false,attack=false;

    public Animator anim;

    public Collider2D trigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }

    public void Attack(bool Battack)
    {
        attack = Battack;
    }
    // Update is called once per frame
    void Update()
    {
        if (((attack == true)||(Input.GetKeyDown(KeyCode.Z))) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.8f;
        }

        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);
    }
}
