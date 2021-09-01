using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject player;
    public GameObject HitEffect;
    void Start()
    {
        rb.velocity = transform.right * speed;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(player.GetComponent<PlayerStats>().Damage*2);
        }
        if (hitInfo.name != "DamageZone")
        {
            GameObject effect = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
