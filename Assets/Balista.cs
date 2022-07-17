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
    [SerializeField] private Sprite shootSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("DamageArea", 0, shootRate);
    }
    bool rotation;
    private void DamageArea()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(transform.position, range);
        if (hitColliders == null) return;
        if (hitColliders.gameObject.CompareTag("Enemy"))
        {
            anim.SetTrigger("BalistaHor");
            ShootArrow();
        }
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < .5)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                rotation = !rotation;
                if (rotation) transform.localScale = new Vector3(-1.2f, 1.2f);
                else transform.localScale = new Vector3(1.2f, 1.2f);
            }
        }
    }

    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.transform.position, shootPoint.rotation);
        arrow.GetComponent<Rigidbody2D>().AddForce(shootPoint.up * 20, ForceMode2D.Impulse);
        arrow.GetComponent<Arrow>().damage = damage;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
