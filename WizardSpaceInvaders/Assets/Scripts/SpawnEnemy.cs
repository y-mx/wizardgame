using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject EnemyPrefab;
    public GameObject Row3Prefab;
    public GameObject Row5Prefab;
    public GameObject ToughWallPrefab;
    public GameObject ShootingRowPrefab;
    public Text LevelEndText;
    int KillsNeeded = 20;
    bool spawning = true;
    System.Random rand = new System.Random();
    public float SpawnRate = 2f;
    PlayerStats ps;
    void Start()
    {
        ps = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnRate = Math.Max(2f-(0.01f * (float)Math.Floor(Math.Pow(1.1f, ps.Level / 2))), 0.5f);
        if (ps.EnemiesKilled >= KillsNeeded)
        {
            StartCoroutine(EndLevel());
        }
        if (spawning)
        {
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        /*int type = rand.Next(6);
        switch (type)
        {
            case 0:
                Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
                break;
            case 1:
                if (ps.Level > 2)
                {
                    Instantiate(Row3Prefab, SpawnPoint.position, SpawnPoint.rotation);
                }
                else
                {
                    Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation); ;
                }
                break;
            case 2:
                if (ps.Level > 3)
                {
                    Instantiate(Row5Prefab, SpawnPoint.position, SpawnPoint.rotation);
                }
                else
                {
                    Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation); ;
                }
                break;
            case 3:
                break;
            case 4:
                if (ps.Level > 5)
                {
                    Instantiate(ToughWallPrefab, SpawnPoint.position, SpawnPoint.rotation);
                }
                break;
            case 5:
                if (ps.Level > 7)
                {
                    Instantiate(ShootingRowPrefab, SpawnPoint.position, SpawnPoint.rotation);
                }
                break;
        }*/
        int type = rand.Next(6);
        if (type < 5)
        {
            Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        }
        spawning = false;
        yield return new WaitForSeconds(SpawnRate);
        spawning = true;
    }
    IEnumerator EndLevel()
    {
        LevelEndText.gameObject.SetActive(true);
        ps.SavePlayer();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
