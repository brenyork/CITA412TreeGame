using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private int LifePerFrame = 2;
    private int Life;
    private float HP;
    [SerializeField] private float MaxSpeed = 2;
    private float Speed;
    private ScoreKeep ScoreKeeper;
    private Transform Target;
    private int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Target = Waypoints.waypoints[waypointIndex];
        Life = 0;
        HP = 100;
        Speed = MaxSpeed;
        ScoreKeeper = FindObjectOfType<ScoreKeep>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 0)
        {
            Life += LifePerFrame;
            Vector3 targetPos = Target.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos - transform.position);
            transform.position += transform.up * Speed * Time.deltaTime;
            if (Vector3.Distance(targetPos, transform.position) <= 1.8f)
            {
                GetNextWaypoint();
            }
        }
        else
        {
            Debug.Log(this.gameObject.name + " died. 100 score added.");
            ScoreKeeper.AddScore(100);
            Destroy(this.gameObject);
        }
    }

    private void GetNextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= Waypoints.waypoints.Length)
        {
            GoalReached();
            return;
        }
        Target = Waypoints.waypoints[waypointIndex];
    }

    private void GoalReached()
    {
        Debug.Log(this.gameObject.name + " reached the end. HP lost.");
        Destroy(this.gameObject);
    }

    public int GetLife()
    {
        return Life;
    }
    public void OnParticleCollision(GameObject other)
    {
        HP -= 50;
        Debug.Log("Name: " + this.gameObject.name + "   HP: " + HP + System.Environment.NewLine +
            "Collision: " + other.name);
    }
}
