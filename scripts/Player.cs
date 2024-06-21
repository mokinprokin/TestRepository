
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 5f;
    public float _jumpForce = 10f;
   [HideInInspector] public int hp=3;
    public GameObject[] hearts;
    public Loader loader;
    public UiManager _UiManager;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (hp <= 0)
        {
            loader.Load(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * _speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A)) { transform.localScale = new Vector3(-1.5f, 1.5f, 1); }
        else if (Input.GetKeyDown(KeyCode.D)) { transform.localScale = new Vector3(1.5f, 1.5f, 1); }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
            isGrounded = false;
        }
    }

    public void TakeDamage(int damage)
    {
        hearts[hp-1].SetActive(false);
        hp -= damage;
    }

}
