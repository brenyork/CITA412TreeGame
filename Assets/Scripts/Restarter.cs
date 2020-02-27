using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Restarter : MonoBehaviour
{
    public int Score;
    public int Money;
    public int playerHP;
    private GameCanvas gc;
    private ScoreKeep sk;
    private int loadMe;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        gc = FindObjectOfType<GameCanvas>();
        sk = FindObjectOfType<ScoreKeep>();
        Money = sk.GetMoney();
        Score = sk.GetScore();
        playerHP = sk.GetPlayerHP();
        loadMe = sk.lastLvl;
        Destroy(gc.gameObject);
        Destroy(sk.gameObject);
        gc = null;
        sk = null;
        SceneManager.LoadScene(loadMe);
    }
    private void Update()
    {
        if (FindObjectsOfType<ScoreKeep>().Length > 0)
        {
            sk = FindObjectOfType<ScoreKeep>();
            sk.SetMoney(Money);
            sk.SetScore(Score);
            sk.SetPlayerHP(playerHP);
            Destroy(this.gameObject);
        }
        if (FindObjectsOfType<FinalCanvas>().Length > 0)
        {
            FinalCanvas fc = FindObjectOfType<FinalCanvas>();
            fc.Score.GetComponent<TextMeshProUGUI>().text =""+Score;
            Destroy(this.gameObject);
        }
    }
}
