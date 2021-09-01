using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public GameObject player;
    /*void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }*/
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name.Contains("Enemy")&&!hitInfo.name.Contains("Shot"))
        {
            player.GetComponent<PlayerStats>().CurHealth -= 1;
            player.GetComponent<PlayerStats>().KillCount = 0;
            player.GetComponent<PlayerStats>().UpdateHUD();
        }
    }
}
