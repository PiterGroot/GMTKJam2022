using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float range, rotateRange;
    [SerializeField] private float shootRate;
    [SerializeField] private float damage;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform[] shootPoints;
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
        //Quaternion e = transform.rotation  Quaternion.Euler(new Vector3(0, 15, 0));
        anim.SetTrigger("BalistaHor");
        GameObject centerArrow = Instantiate(arrowPrefab, shootPoints[0].transform.position, transform.rotation);
        GameObject leftArrow = Instantiate(arrowPrefab, shootPoints[1].transform.position, transform.rotation);
        GameObject rightArrow = Instantiate(arrowPrefab, shootPoints[2].transform.position, transform.rotation);

        centerArrow.GetComponent<Arrow>().damage = damage;
        leftArrow.GetComponent<Arrow>().damage = damage;
        rightArrow.GetComponent<Arrow>().damage = damage;

        centerArrow.GetComponent<Rigidbody2D>().AddForce(shootPoints[0].right * 20, ForceMode2D.Impulse);
        leftArrow.GetComponent<Rigidbody2D>().AddForce(shootPoints[1].right * 20, ForceMode2D.Impulse);
        rightArrow.GetComponent<Rigidbody2D>().AddForce(shootPoints[2].right * 20, ForceMode2D.Impulse);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
