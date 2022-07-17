using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETower : MonoBehaviour
{
    private string enemyTag = "Enemy";
    [SerializeField]private Vector3 rangeOffset;
    [SerializeField] private float damageAmount;
    [SerializeField] private float damageTickRate;
    [SerializeField] private float range;

    private void Start()
    {
        ParticleSystem.ShapeModule ps = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().shape;
        ps.radius = range;
        InvokeRepeating("DamageArea", 0, damageTickRate);
        transform.GetChild(0).Translate(rangeOffset);
    }
    private void DamageArea()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position + rangeOffset, range);
        foreach (Collider2D obj in hitColliders)
        {
            if (obj.gameObject.CompareTag(enemyTag))
            {
                obj.GetComponent<HealthComponent>().RemoveHealth(damageAmount);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + rangeOffset, range);
    }
}
