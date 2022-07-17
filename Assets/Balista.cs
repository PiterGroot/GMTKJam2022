using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float range;
    [SerializeField] private Animator anim;
    [SerializeField] private float shootRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DamageArea", 0, shootRate);
    }

    private void DamageArea()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D obj in hitColliders)
        {
            if (obj.gameObject.CompareTag("Enemy"))
            {
                ShootArrow();
            }
        }
    }

    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.transform.position, shootPoint.rotation);
        arrow.GetComponent<Rigidbody2D>().AddForce(shootPoint.up * 20, ForceMode2D.Impulse);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
