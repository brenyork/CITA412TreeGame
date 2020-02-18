using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{
    private int Score = 0;
    private int Money = 0;
    private int lastScore = 0;
    
    void Awake()
    {
        ScoreKeep[] navs = FindObjectsOfType<ScoreKeep>();

        if (navs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (lastScore != Score)
        {
            lastScore = Score;
            Debug.Log(this.gameObject.name + ": Score is " + Score + ".");
        }
    }
    // Update is called once per frame
    public void AddScore(int score)
    {
        Score += score;
        Money += score;
    }
    public int GetScore()
    {
        return Score;
    }
    public void SpendMoney(int amount)
    {
        Money -= amount;
    }
    public int GetMoney()
    {
        return Money;
    }
}
