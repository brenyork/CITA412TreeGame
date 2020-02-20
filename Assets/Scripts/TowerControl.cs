using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    [SerializeField] private float range = 2f;
    [SerializeField] private ParticleSystem Weapon;
    [SerializeField] private float WeaponFireRate = 1f;
    private GameObject Target = null;
    // Start is called before the first frame update
    void Start()
    {
        FindOldestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * -90 * Time.deltaTime);
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        */
        if (Target != null)
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
