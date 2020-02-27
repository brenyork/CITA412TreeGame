using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawnables;
    [SerializeField] private int MaxSpawned = 4;
    private GameObject ScoreKeeper;
    private int Money = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreKeep temp = FindObjectOfType<ScoreKeep>();
        ScoreKeeper = temp.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Money += 2;
        if (transform.childCount < MaxSpawned && Money > 400)
        {
            Money -= 400;
            GameObject tempBug = Instantiate(Spawnables[0]);
            tempBug.transform.position = this.transform.position;
            tempBug.transform.parent = this.transform;
        }
    }
}
