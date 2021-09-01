using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    public int MaxHealth = 3;
    public int CurHealth = 3;
    public int Damage = 1;
    public int CritChance = 2;
    public float FireDelay = 0.5f;
    public float MoveSpeed = 5f;
    public int CurExperience = 0;
    public int MaxExperience = 10;
    public int Level = 1;
    public bool KillHeal = false;
    public bool FreezeEnable = false;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
