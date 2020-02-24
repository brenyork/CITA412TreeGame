using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] public GameObject Score;
    [SerializeField] public GameObject HP;
    void Awake()
    {
        GameCanvas[] canvas = FindObjectsOfType<GameCanvas>();

        if (canvas.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
