using UnityEngine;

public class MCScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    private Animator animator;

    public float speed = 5f;//horizontal speed
    float horizontalInput;
    bool isFacingRight = false;
    float jumpPower = 4f;
    bool isGrounded = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if(Input.GetButtonDown("Jump") &&  isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocityY);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("yVelocity", rb.linearVelocityY);
    }

    void FlipSprite()
    {
        if(isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}
