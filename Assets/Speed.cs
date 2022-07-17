using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
