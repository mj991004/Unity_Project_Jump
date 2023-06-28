using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatformBlink : MonoBehaviour
{
    public float ActiveTime=1f;
    public float NotActiveTime=1f;

    BoxCollider2D bc2;
    SpriteRenderer sr;

    float time;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        bc2 = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        isActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isActive)
        {
            if (time >= ActiveTime) { 
                bc2.enabled = false;
                sr.enabled = false; 
                time = 0;
                isActive = false; 
            }
        }
        else
        {
            if (time >= NotActiveTime)
            {
                bc2.enabled = true;
                sr.enabled = true;
                time = 0;
                isActive = true;
            }
        }
    }
}
