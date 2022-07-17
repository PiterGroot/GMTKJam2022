using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Color buffColor;
    private SpriteRenderer spriteRenderer;
    private Vector3 movement;
    float startMoveSpeed;
    private Rigidbody2D rb2d;
    private Melee melee;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] float speedMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startMoveSpeed = moveSpeed;
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
            characterScale.x = 1;
        }
        if (movement.x < 0)
        {
            characterScale.x = -1;
        }
        transform.localScale = characterScale;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pathblocker"))
        {
            FindObjectOfType<GameManager>().canBuild = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Buff"))
        {
            melee.isBuffed = true;
            GetComponent<SpriteRenderer>().color = buffColor;
        }
        if (collision.CompareTag("Speed"))
        {
            moveSpeed = speedMoveSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Buff"))
        {
            melee.isBuffed = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (collision.CompareTag("Speed"))
        {
            moveSpeed = startMoveSpeed;
        }
        if (collision.CompareTag("Pathblocker"))
        {
            FindObjectOfType<GameManager>().canBuild = true;
        }
    }

    [SerializeField] private Image playerSprite;
    [SerializeField] private Text rolledNumText;
    [SerializeField] private Animator rollAnim;
    [SerializeField] private Sprite[] towers;
    [SerializeField] private Image towerImg;
    [SerializeField] private GameObject particle;
    [SerializeField] private GameObject[] towersPrefabs;
    private Vector2 pos;
    int num = 0;
    public void RandomSprite()
    {
        rollAnim.SetTrigger("roll");
        int randInt = Random.Range(1, sprites.Length);
        playerSprite.sprite = sprites[randInt];
        rolledNumText.text = randInt.ToString();
        towerImg.sprite = towers[randInt];
        Instantiate(particle, transform.position, Quaternion.identity);
        Invoke("PlaceTower", 2.5f);
        num = randInt;
        pos = transform.position;
    }

    void PlaceTower()
    {
        Instantiate(towersPrefabs[num], pos, Quaternion.identity);
    }
}
