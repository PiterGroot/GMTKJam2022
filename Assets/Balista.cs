using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float range, rotateRange;
    [SerializeField] private Animator anim;
    [SerializeField] private float shootRate;
    [SerializeField] private float damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("UpdateTarget", 0, shootRate);
    }
    bool rotation;
    
    private Transform Target;
    void UpdateTarget()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
            ShootArrow();
        }
        else
        {
            Target = null;
        }

    }
    void Update()
    {
        if (Target == null)
            return;

        Vector2 dir = Target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 15 * Time.deltaTime);
    }

    private void ShootArrow()
    {
        anim.SetTrigger("BalistaHor");
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.transform.position, transform.rotation);
        arrow.GetComponent<Rigidbody2D>().AddForce(shootPoint.right * 20, ForceMode2D.Impulse);
        arrow.GetComponent<Arrow>().damage = damage;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
