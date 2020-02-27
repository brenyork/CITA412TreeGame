using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] private float range = 150f;
    [SerializeField] private ParticleSystem Weapon;
    [SerializeField] private float WeaponFireRate = 0.5f;
    private GameObject Target = null;
    bool collided = false;
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void Start()
    {
        StartCoroutine(CheckForCollision());
        FindOldestTarget();
    }

    void OnTriggerEnter()
    {
        collided = true;
    }

    IEnumerator CheckForCollision()
    {
        yield return null;
        if (collided)
        {
            ScoreKeep sk = FindObjectOfType<ScoreKeep>();
            sk.SpendMoney(-300);
            Debug.Log("Can not place here");
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * -90 * Time.deltaTime);
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        */
        if (Target != null && Vector3.Distance(Target.transform.position, transform.position) <= range)
        {
            Weapon.emissionRate = WeaponFireRate;
            Vector3 targetPos = Target.transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos - transform.position);
        }
        else
        {
            Weapon.emissionRate = 0;
            FindOldestTarget();
        }
    }
    private void FindOldestTarget()
    {
        Bug[] targets = FindObjectsOfType<Bug>();
        if (targets.Length > 0)
        {
            int oldest = 0;
            for (int i = 1; i < targets.Length; i++)
            {
                if (targets[oldest].GetLife() < targets[i].GetLife())
                {
                    oldest = i;
                }
            }
            Target = targets[oldest].gameObject;
        }
        else
        {
            Target = null;
        }
    }
}
