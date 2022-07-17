using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private CircleCollider2D sphereCollider;
    [SerializeField] private float range = 5;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem.ShapeModule ps = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().shape;
        ps.radius = range;

        sphereCollider = gameObject.GetComponent<CircleCollider2D>();
        sphereCollider.radius = range;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
