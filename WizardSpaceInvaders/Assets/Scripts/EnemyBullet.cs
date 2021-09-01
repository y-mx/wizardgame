using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    //public GameObject player;
    //public GameObject HitEffect;
    void Start()
    {
        //Debug.Log("spawn");
        rb.velocity = -1*transform.right * speed;
        //player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStats ps = hitInfo.GetComponent<PlayerStats>();
        if (ps != null)
        {
            ps.CurHealth -= 1;
            ps.UpdateHUD();
        }
        if (!hitInfo.name.Contains("Enemy")&&hitInfo.name!="DamageZone")
        {
            //GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
