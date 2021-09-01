using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int MaxHealth=3;
    public int CurHealth=3;
    public int Damage;
    public int CritChance = 2;
    public float FireDelay;
    public float MoveSpeed = 5f;
    public int CurExperience = 0;
    public int MaxExperience = 10;
    public int Level=1;
    public bool KillHeal = false;
    public int KillCount = 0;
    public bool FreezeEnable = false;
    public int EnemiesKilled = 0;

    public Text HealthText;
    public Text XPText;
    public Text LevelText;
    void Start()
     {
        LoadPlayer();
     }
    public void UpdateHUD()
    {
        if (KillCount >= 20&&CurHealth<MaxHealth)
        {
            CurHealth += 1;
            KillCount = 0;
        }
        HealthText.text = "Health: "+CurHealth+"/"+MaxHealth;
        if (CurHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        XPText.text = "Exp: " + CurExperience + "/" + MaxExperience;
        if (CurExperience >= MaxExperience)
        {
            CurExperience = 0;
            Level += 1;
            LevelUp(Level);
        }
        LevelText.text = "Level " + Level;
       
    }

    public void LoadPlayer()
    {
        MaxHealth = SaveData.Instance.MaxHealth;
        CurHealth = SaveData.Instance.CurHealth;
        Damage = SaveData.Instance.Damage;
        CritChance = SaveData.Instance.CritChance;
        FireDelay = SaveData.Instance.FireDelay;
        MoveSpeed = SaveData.Instance.MoveSpeed;
        CurExperience = SaveData.Instance.CurExperience;
        MaxExperience = SaveData.Instance.MaxExperience;
        Level = SaveData.Instance.Level;
        KillHeal = SaveData.Instance.KillHeal;
        FreezeEnable = SaveData.Instance.FreezeEnable;
    }
    public void SavePlayer()
    {
        SaveData.Instance.MaxHealth = MaxHealth;
        SaveData.Instance.CurHealth = CurHealth;
        SaveData.Instance.Damage = Damage;
        SaveData.Instance.CritChance = CritChance;
        SaveData.Instance.FireDelay = FireDelay;
        SaveData.Instance.MoveSpeed = MoveSpeed;
        SaveData.Instance.CurExperience = CurExperience;
        SaveData.Instance.MaxExperience = MaxExperience;
        SaveData.Instance.Level = Level;
        SaveData.Instance.KillHeal = KillHeal;
        SaveData.Instance.FreezeEnable = FreezeEnable;
    }
    void LevelUp(int lvl)
    {
        switch (lvl%5)
        {
            case 0:
                FireDelay -= 0.05f;
                if (FireDelay <= 0f)
                {
                    FireDelay = 0.05f;
                }
                break;
            case 1:
                MoveSpeed += 1f;
                break;
            case 3:
                Damage += 1;
                break;
            case 2:
                CritChance += 2;
                break;
            case 4:
                MaxHealth += 1;
                CurHealth += 1;
                break;
        }
        if (lvl == 10)
        {
            KillHeal = true;
        }
        if (lvl == 20)
        {
            FreezeEnable = true;
        }
        MaxExperience = (int)Math.Ceiling(10 * (Math.Pow(1.1, lvl)));
    }
}
