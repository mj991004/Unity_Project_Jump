using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatformMove : MonoBehaviour
{
    public float speed;
    public float range;
    public float angle;

    float xMax, yMax;
    float xMin, yMin;
    float x, y;
    float xTick, yTick;

    bool isMovingPositive = true;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        angle = (angle % 180) - 90;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        xMax = range*Mathf.Cos(angle)+x;
        yMax = range*Mathf.Sin(angle)+y;
        xMin = -xMax+2*x;
        yMin = -yMax+2*y;
        xTick = speed * Mathf.Cos(angle);
        yTick = speed * Mathf.Sin(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingPositive)
        {
            rigidbody.velocity = new Vector2(xTick, yTick);
            
            if(Vector2.Distance(new Vector2(x, y), transform.position) >= range
                && Vector2.Distance(transform.position,new Vector2(xMax,yMax))<=range/2)
            {
                x = xMax;
                y = yMax;
                isMovingPositive = false;
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(-xTick, -yTick);

            if (Vector2.Distance(new Vector2(x, y), transform.position) >= range
                && Vector2.Distance(transform.position, new Vector2(xMin, yMin)) <= range/2)
            {
                x = xMin;
                y = yMin;
                isMovingPositive = true;
            }

        }
    }

}
