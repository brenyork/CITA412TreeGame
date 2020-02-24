using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLayer : MonoBehaviour
{
    private ScoreKeep ScoreKeeper;
    private GameObject[] Turrets;
    private GameObject gameCanvas;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
        gameCanvas = FindObjectOfType<GameCanvas>().gameObject;
        ScoreKeeper = FindObjectOfType<ScoreKeep>();
    }

    // Update is called once per frame
    void Update()
    {
        money = ScoreKeeper.GetMoney();
    }
}
