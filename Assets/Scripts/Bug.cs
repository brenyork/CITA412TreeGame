using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private int LifePerFrame = 2;
    private int Life;
    // Start is called before the first frame update
    void Start()
    {
        Life = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Life += LifePerFrame;
    }
    public int GetLife()
    {
        return Life;
    }
}
