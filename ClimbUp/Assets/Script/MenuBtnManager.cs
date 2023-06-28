using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuBtnManager : MonoBehaviour
{
    public int stage;
    public void ClickStage()
    {
        string s = string.Format("StageScene_" + stage.ToString());
        SceneManager.LoadScene(s);
    }

    public void ClickRecord()
    {
        SceneManager.LoadScene("RecordScene");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
