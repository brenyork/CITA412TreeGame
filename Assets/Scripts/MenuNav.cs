using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    int ScoreAtLevel;
    int MoneyAtLevel;
    int HpAtLevel;
    [SerializeField] GameObject Restarter;
    void Start()
    {
        if (FindObjectOfType<ScoreKeep>() != null)
        {
            ScoreKeep sk = FindObjectOfType<ScoreKeep>();
            ScoreAtLevel = sk.GetScore();
            MoneyAtLevel = sk.GetMoney();
            HpAtLevel = sk.GetPlayerHP();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToTitleScreen()
    {
        SceneManager.LoadScene(0);
        if (FindObjectsOfType<ScoreKeep>().Length > 0)
        {
            GameCanvas gc = FindObjectOfType<GameCanvas>();
            ScoreKeep sk = FindObjectOfType<ScoreKeep>();
            Destroy(gc.gameObject);
            Destroy(sk.gameObject);
        }
    }
    public void ToFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void ToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ScoreKeep sk = FindObjectOfType<ScoreKeep>();
        sk.SetMoney(300);
        sk.lastLvl = currentSceneIndex + 1;
        Instantiate(Restarter);
    }
    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ScoreKeep sk = FindObjectOfType<ScoreKeep>();
        sk.SetPlayerHP(HpAtLevel);
        sk.SetScore(ScoreAtLevel);
        sk.SetMoney(MoneyAtLevel);
        sk.lastLvl = currentSceneIndex;
        Instantiate(Restarter);
    }
    public void ToHowTo()
    {
        SceneManager.LoadScene(1);
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene("LossScreen");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
