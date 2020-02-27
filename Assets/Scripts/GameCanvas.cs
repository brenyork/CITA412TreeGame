using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
