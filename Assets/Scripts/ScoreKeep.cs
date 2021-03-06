﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeep : MonoBehaviour
{
    private int Score = 0;
    private int Money = 300;
    private int lastScore = 0;
    private int playerHP = 10;
    private int LevelScore = 0;
    private GameCanvas gameCanvas;
    private GameObject score;
    private GameObject hp;
    public int lastLvl;
    void Awake()
    {
        ScoreKeep[] navs = FindObjectsOfType<ScoreKeep>();

        if (navs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>();
        score = gameCanvas.Score;
        score.GetComponent<TextMeshProUGUI>().text = "Money: 0";
        hp = gameCanvas.HP;
        hp.GetComponent<TextMeshProUGUI>().text = "HP: 10";
    }
    void Update()
    {
        if (LevelScore >= 10000)
        {
            MenuNav mn = FindObjectOfType<MenuNav>();
            mn.ToNextLevel();
        }
        if (playerHP <= 0)
        {
            MenuNav mn = FindObjectOfType<MenuNav>();
            mn.ToNextLevel();
        }
        score.GetComponent<TextMeshProUGUI>().text = "Money: " + Money;
        if (lastScore != Score)
        {
            lastScore = Score;
            Debug.Log(this.gameObject.name + ": Score is " + Score + "." + System.Environment.NewLine + "Money is " + Money + ".");
        }
        hp.GetComponent<TextMeshProUGUI>().text = "HP: " + playerHP;
    }
    // Update is called once per frame
    public void AddScore(int score)
    {
        Score += score;
        Money += score;
        LevelScore += score;
    }
    public int GetScore()
    {
        return Score;
    }
    public void SetScore(int a)
    {
        Score = a;
    }
    public void SpendMoney(int amount)
    {
        Money -= amount;
    }
    public int GetMoney()
    {
        return Money;
    }
    public void SetMoney(int a)
    {
        Money = a;
    }
    public int GetPlayerHP()
    {
        return playerHP;
    }
    public void DamagePlayer(int a)
    {
        playerHP -= a;
    }
    public void HealPlayer(int a)
    {
        playerHP += a;
    }
    public void SetPlayerHP(int a)
    {
        playerHP = a;
    }
}
