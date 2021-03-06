﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    public float fallgravity = 2.5f;
    public float upgravity = 2f;
    public Player player;
    Rigidbody2D r2d;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        player = gameObject.GetComponentInParent<Player>();
    }

    void Update()
    {
        if (r2d.velocity.y < 0)
        {
            r2d.velocity += Vector2.up * Physics2D.gravity.y * (fallgravity - 1) * Time.deltaTime;
        }
        else if (r2d.velocity.y > 0 && player.jump==true)
        {
            r2d.velocity += Vector2.up * Physics2D.gravity.y * (upgravity - 1) * Time.deltaTime;
        }

    }
}
