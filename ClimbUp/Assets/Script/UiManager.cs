using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public int stage;
    public Text timeText;
    private float clearTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        clearTime = 0;
        PlayerPrefs.SetInt("PlayingStage",stage);
    }

    // Update is called once per frame
    void Update()
    {
        clearTime += Time.deltaTime;
        timeText.text = string.Format("Time : {0:F2}", clearTime);

    }
    public void EndGame()
    {
        string s = string.Format("Result_" + stage.ToString());
        PlayerPrefs.SetFloat(s, clearTime);
        SceneManager.LoadScene("ResultScene");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
            EndGame();
    }
}
