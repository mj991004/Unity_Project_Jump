using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlDot : MonoBehaviour
{

    bool isPowerIncre = true;
    bool isRight = true;
    bool isGround = true;
    bool isCharging = false;
    bool isJumping = false;
    bool isDrop = false;
    bool isBumping = false;
    bool isWalking = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    Vector2 externVelocity;
    Vector2 exVector;
    Vector2 exPlace;
    const float speed = 10f;
    float power = 0;
    float powerTic = 1f;
    float time = 0f;

    public PhysicsMaterial2D normalMat;
    public PhysicsMaterial2D fallingMat;
    public LayerMask groundMask;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPowerIncre = true;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        isGround = Physics2D.OverlapBox(transform.position, new Vector2(0.2f, 0.1f), 0, groundMask) && rb.sharedMaterial == normalMat;

        if (isGround && isJumping)
        {
            if(rb.velocity.y>0) isGround = false;
            else isJumping = false;
        }

        if (isDrop)
        {
            if(time > 2f && rb.velocity.magnitude < 0.2f) isDrop = false;
        }
        else if(isGround)
        {
            if (isBumping)
            {
                if (time > 3f || transform.position.y + 15f < exPlace.y) isDrop = true;
                time = 0f;
            }
            isJumping = false;
            isBumping = false;

            float xInput = Input.GetAxis("Horizontal");
            if (xInput < 0) isRight = false;
            else if (xInput > 0) isRight=true;

            spriteRenderer.flipX = !isRight;
            isWalking = (xInput!=0);
            rb.velocity = new Vector2(xInput*4f, rb.velocity.y)+externVelocity;
        }
        else
        {
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround && !isDrop)
        {
            isCharging = true;
        }

        if (isCharging)
        {
            rb.velocity = Vector2.zero+externVelocity;
            if (!isGround)
            {
                isCharging = false;
                power = 0;
                GameManager.Instance.setPower(power);
            }
            if (isPowerIncre)
            {
                power += powerTic*Time.deltaTime;
                if (power > 1) isPowerIncre = false;
            }
            else
            {
                power -= powerTic*Time.deltaTime;
                if (power < 0) isPowerIncre = true;
            }
            GameManager.Instance.setPower(power);
        }

        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            isJumping = true;
            isCharging = false;
            exPlace = transform.position;
            time = 0;

            float x = 4f;
            if (!isRight) x *= -1;
            Vector2 v = new Vector2(x, speed * (power + 0.2f));
            rb.velocity = v;
            power = 0;
            GameManager.Instance.setPower(power);
        }


        GameManager.Instance.setCharY(rb.transform.position.y);

        animator.SetBool("IsCharging", isCharging);
        animator.SetBool("IsGround", isGround);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsBumping", isBumping);
        animator.SetBool("IsDrop", isDrop);
        animator.SetFloat("FallingSpeed", rb.velocity.y);

        exVector = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        if (normal.y>0.8)
        {
            rb.sharedMaterial = normalMat;
            rb.velocity = Vector2.zero;
        }
        else if(!isGround)
        {
            isBumping = true;
            rb.sharedMaterial = fallingMat;
            Vector2 normalVector = exVector.normalized;
            rb.velocity = Vector2.Reflect(normalVector, normal) * (exVector.magnitude/3*2);
            Debug.Log(exVector + " / " + normal + " / " + normalVector + " / " + rb.velocity);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D cRb = collision.rigidbody;
        if (cRb != null)
        {
            externVelocity = cRb.velocity;
        }
        else externVelocity = Vector2.zero;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        externVelocity = Vector2.zero;
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector2(0.2f, 0.1f));
    }

}
