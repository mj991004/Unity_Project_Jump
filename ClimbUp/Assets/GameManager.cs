using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager _instance;
    
    float power;
    float charY=0f;

    public static GameManager Instance
    {
        get{
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("GameManager Error");
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null) _instance = this;

        else if (_instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Screen.SetResolution(1280, 800, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPower(float a) {  power = a; }
    public float getPower() { return power; }

    public void setCharY(float a) { charY = a; }
    public float getCharY() { return charY; }
}
