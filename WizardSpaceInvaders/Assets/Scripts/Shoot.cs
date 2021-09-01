using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Security.Cryptography;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public GameObject CritBulletPrefab;
    public PlayerStats ps;
    public bool firing = true;
    System.Random rand = new System.Random();
    
    void Start()
    {
        ps = gameObject.GetComponent<PlayerStats>();
        ps.UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&firing)
        {
            StartCoroutine(ShootBullet());
        }
        if (Input.GetKeyDown("space")&&ps.FreezeEnable)
        {
            StartCoroutine(FreezeEnemies());
        }
    }
    IEnumerator ShootBullet()
    {
        int type = rand.Next(100);
        if (type < ps.CritChance)
        {
            GameObject bullet = Instantiate(CritBulletPrefab, FirePoint.position, FirePoint.rotation);
        }
        else
        {
            GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        }
        firing = false;
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(FirePoint.right * BulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(ps.FireDelay);
        firing = true;
    }
    IEnumerator FreezeEnemies()
    {
        Debug.Log("Freeze");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            e.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        yield return new WaitForSeconds(5);
        foreach (GameObject e in enemies)
        {
            if (e != null)
            {
                e.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                e.GetComponent<Rigidbody2D>().velocity = new Vector2(-e.GetComponent<Enemy>().horspeed, e.GetComponent<Enemy>().dir * e.GetComponent<Enemy>().verspeed);
            }
        }
    }
}
