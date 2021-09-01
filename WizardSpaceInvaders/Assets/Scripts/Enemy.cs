using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int Level=1;
    public Rigidbody2D rb;
    public float horspeed;
    public float verspeed;
    public GameObject player;
    public int XPValue=1;
    public int dir = 1;
    PlayerStats ps;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        ps = player.GetComponent<PlayerStats>();
        Health = Health * Level;
        horspeed = 0.2f*Level;
        verspeed = 0.4f*Level;
        if (horspeed > 2)
        {
            horspeed = 2;
        }
        if (verspeed > 3)
        {
            verspeed = 3;
        }
        rb.velocity = new Vector2(-horspeed, dir*verspeed);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            ps.CurExperience += XPValue;
            if (ps.KillHeal)
            {
                ps.KillCount += 1;
            }
            ps.EnemiesKilled += 1;
            ps.UpdateHUD();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name.Contains("Wall"))
        {
            dir *= -1;
            rb.velocity = new Vector2(-horspeed, dir * verspeed);
        }else if (hitInfo.name == "DamageZone")
        {
            Destroy(gameObject);
        }
      
    }
}
