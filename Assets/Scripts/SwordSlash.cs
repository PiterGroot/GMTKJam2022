using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    private Collider2D hitbox;
    private Melee melee;
    
    // Start is called before the first frame update
    void Start()
    {
        hitbox = gameObject.GetComponent<Collider2D>();
        melee = transform.parent.gameObject.GetComponent<Melee>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && melee.isAttacking)
        {
            if(melee.isBuffed) collision.gameObject.GetComponent<HealthComponent>().RemoveHealth(melee.damage * 2, true);
            else collision.gameObject.GetComponent<HealthComponent>().RemoveHealth(melee.damage, true);
        }
    }
  

    public void DisableAttacking()
    {
        hitbox.enabled = false;
        melee.canAttack = true;
        melee.isAttacking = false;
    }
    public void EnableAttacking()
    {
        hitbox.enabled = true;
        melee.isAttacking = true;
    }
}
