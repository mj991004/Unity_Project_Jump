using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecordManager : MonoBehaviour
{
    public Text text1;
    public Text text2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("BestResult_1"));
        Debug.Log(PlayerPrefs.GetFloat("BestResult_2"));
        if (PlayerPrefs.GetFloat("BestResult_1") == 0)
            text1.text = string.Format("Stage 1 : -");
        else
            text1.text = string.Format("Stage 1 : "+ PlayerPrefs.GetFloat("BestResult_1").ToString("F2"));

        if (PlayerPrefs.GetFloat("BestResult_2") == 0)
            text2.text = string.Format("Stage 2 : -");
        else
            text2.text = string.Format("Stage 2 : "+ PlayerPrefs.GetFloat("BestResult_2").ToString("F2"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
