using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    float y=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y=GameManager.Instance.getCharY();
        if(y<0) y=0;

        gameObject.transform.position=new Vector3(0,y,-10);
    }
}
