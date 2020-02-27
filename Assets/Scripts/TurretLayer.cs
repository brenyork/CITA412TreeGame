using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLayer : MonoBehaviour
{
    private ScoreKeep ScoreKeeper;
    [SerializeField] private GameObject[] Turrets;
    private int selectedTurret = -1;
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
        if (selectedTurret >= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Placing tower");
                PlaceTurret();
            }
        }
    }
    public void PlaceTurret()
    {
        if (money >= 300)
        {
            GameObject tempTurret = Instantiate(Turrets[selectedTurret]);
            tempTurret.transform.position = Input.mousePosition;
            tempTurret.transform.parent = this.transform;
            ScoreKeeper.SpendMoney(300);
            Debug.Log("Tower placed");
            selectedTurret = -1;
        }
        else
        {
            Debug.Log("Need more money");
        }
    }
    public void SetTurret(int i)
    {
        selectedTurret = i;
    }
}
