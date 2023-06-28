using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text resultText, bestText, infoText;

    private bool isDelete = false;
    int stage;
    string BestResult;
    string PlayResult;
    // Start is called before the first frame update
    void Start()
    {
        stage = PlayerPrefs.GetInt("PlayingStage");
        BestResult = string.Format("BestResult_" + stage.ToString());
        PlayResult = string.Format("Result_" + stage.ToString());

        Debug.Log("DD");
        Debug.Log(PlayerPrefs.GetFloat(BestResult));
        float best;
        float result;

        result = PlayerPrefs.GetFloat(PlayResult);

        if (!PlayerPrefs.HasKey(BestResult)||PlayerPrefs.GetFloat(BestResult)==0f)
        {
            PlayerPrefs.SetFloat(BestResult, result);
            best = result;
        }
        else
        {
            best = PlayerPrefs.GetFloat(BestResult);
            if (result < best)
            {
                PlayerPrefs.SetFloat(BestResult, result);
                best = result;
            }
        }
        resultText.text = string.Format("Result : {0:F2}", result);
        bestText.text = string.Format("Best record : {0:F2}", best);
        infoText.text = string.Format("Press R to Restart\r\nPress X to Erase Data\r\nPress Q to Return to Main\r\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(string.Format("StageScene_"+stage.ToString()));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            infoText.text = string.Format("Press R to Restart\r\nAre you sure you want to delete All Data?(press y/n)\r\nPress Q to Return to Main\r\n");
            isDelete = true;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (isDelete)
            {
                PlayerPrefs.DeleteKey(BestResult);
                isDelete = false;
                resultText.text = string.Format("Result : -");
                bestText.text = string.Format("Best record : -");
                infoText.text = string.Format("Press R to Restart\r\n Press X to Erase Data\r\nPress Q to Return to Main\r\n");
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            isDelete = false;
            infoText.text = string.Format("Press R to Restart\r\n Press X to Erase Data\r\nPress Q to Return to Main\r\n");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
