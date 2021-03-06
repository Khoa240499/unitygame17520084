﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Player player;
    public movingplat mov;
    public movingupdown mov1;

    public Vector3 movep;

    // Use this for initialization
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("Movingplat").GetComponent<movingplat>();
        mov1 = GameObject.FindGameObjectWithTag("Movingup").GetComponent<movingupdown>();
        player = gameObject.GetComponentInParent<Player>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false )
            player.grounded = true;
        if (collision.isTrigger == false && collision.CompareTag("Movingplat"))
        {
            movep = player.transform.position;
            movep.x += mov.speed * 1.2f;
            player.transform.position = movep;
        }
        if (collision.isTrigger == false && collision.CompareTag("Movingup"))
        {
            movep = player.transform.position;
            movep.y += mov1.speed * 1.3f;
            player.transform.position = movep;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false )
            player.grounded = false;
    }
}