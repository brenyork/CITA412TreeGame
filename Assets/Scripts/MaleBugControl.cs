using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleBugControl : MonoBehaviour
{
    private float HP;
    private const float MaxSpeed = 2;
    private float Speed;
    private ScoreKeep ScoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        Speed = MaxSpeed;
        ScoreKeeper = FindObjectOfType<ScoreKeep>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 0)
        {
            transform.position += transform.right * -Speed * Time.deltaTime;
            transform.Rotate(Vector3.forward * -90 * Time.deltaTime);
        }
        else
        {
            Debug.Log(this.gameObject.name + " died. 100 score added.");
            ScoreKeeper.AddScore(100);
            Destroy(this.gameObject);
        }
        
    }
    public void OnParticleCollision(GameObject other)
    {
        HP -= 50;
        Debug.Log("Name: " + this.gameObject.name + "   HP: " + HP + System.Environment.NewLine + 
            "Collision: " + other.name);
    }
}
