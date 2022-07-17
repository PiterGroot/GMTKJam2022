using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Color buffColor;
    private SpriteRenderer spriteRenderer;
    private Vector3 movement;
    private Rigidbody2D rb2d;
    private Melee melee;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        melee = gameObject.GetComponent<Melee>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 characterScale = transform.localScale;
        if (movement.x > 0)
        {
            characterScale.x = -1;
        }
        if (movement.x < 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Buff"))
        {
            melee.isBuffed = true;
            GetComponent<SpriteRenderer>().color = buffColor;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Buff"))
        {
            melee.isBuffed = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
