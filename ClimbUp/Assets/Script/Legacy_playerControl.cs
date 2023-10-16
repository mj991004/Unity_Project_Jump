using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Legacy_playerControl : MonoBehaviour
{
    Rigidbody2D rb;
    const float speed = 10f;
    float power = 0;
    float powerTic = 0.005f;
    bool isPowerIncre = true;
    bool isCharging = false;
    bool isGround = true;
    bool isRight = true;
    bool isJumping = false;

    public PhysicsMaterial2D normalMat;
    public PhysicsMaterial2D fallingMat;
    public LayerMask groundMask;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isPowerIncre = true;
        isCharging = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapBox(new Vector2(rb.position.x, rb.position.y - 0.025f),
            new Vector2(0.2f, 0.05f), 0, groundMask);

        if (isGround)
        {
            rb.sharedMaterial = normalMat;
            if (Input.GetAxis("Horizontal") < 0) isRight = false;
            else if (Input.GetAxis("Horizontal") > 0) isRight = true;
            if(Mathf.Abs(rb.velocity.y) <= 1f) isJumping = false;
            if (!isJumping)
            {
                float xInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(xInput*4f, 0);
            }
            Debug.Log("G");
        }
        else
        {
            Debug.Log("NG");
            rb.sharedMaterial = fallingMat;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isCharging = true;
        }

        if (isCharging)
        {
            if (!isGround)
            {
                isCharging = false;
                power = 0;
                GameManager.Instance.setPower(power);
            }
            if (isPowerIncre)
            {
                power += powerTic;
                if (power > 1) isPowerIncre = false;
            }
            else
            {
                power -= powerTic;
                if (power < 0) isPowerIncre = true;
            }
            GameManager.Instance.setPower(power);
        }

        if (Input.GetKeyUp(KeyCode.Space) & isCharging)
        {
            isJumping = true;
            isCharging = false;
            float x = 4f;
            if (!isRight) x *= -1;
            Vector2 v = new Vector2(x, speed * (power + 0.2f));
            rb.velocity = v;
            power = 0;
            GameManager.Instance.setPower(power);
        }

        GameManager.Instance.setCharY(rb.transform.position.y);
    }
    public bool getIsGround() { return isGround; } 
    public bool getIsCharging() { return isCharging; } 
    public bool getIsRight() { return isRight; }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(rb.position.x, rb.position.y - 0.025f),
            new Vector2(0.2f, 0.05f));
    }

}
*/