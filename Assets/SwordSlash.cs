using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    private Melee melee;
    // Start is called before the first frame update
    void Start()
    {
        melee = transform.parent.gameObject.GetComponent<Melee>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && melee.isAttacking)
        {
            print("jejeje");
            collision.gameObject.GetComponent<HealthComponent>().RemoveHealth(melee.damage);
        }
    }
  

    public void DisableAttacking()
    {
        melee.canAttack = true;
        melee.isAttacking = false;
    }
    public void EnableAttacking()
    {
        melee.isAttacking = true;
    }
}
