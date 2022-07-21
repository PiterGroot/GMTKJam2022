using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthComponent>().RemoveHealth(damage);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Arrow") && !collision.CompareTag("Pathblocker")
            && !collision.CompareTag("Speed") && !collision.CompareTag("Slow") && !collision.CompareTag("Buff"))
        {
            Destroy(gameObject);
        }
    }

}
