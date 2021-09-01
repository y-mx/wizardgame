using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    public bool firing = true;
    System.Random rand = new System.Random();

    void Start()
    {
        //StartCoroutine(Wait(rand.Next(3)));
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            StartCoroutine(ShootBullet());
        }
    }
    IEnumerator ShootBullet()
    {
        //Debug.Log("shot");
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        firing = false;
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(FirePoint.right * BulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3);
        firing = true;
    }
    IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
        firing = true;
    }
}
