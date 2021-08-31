using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public Text ScriptTxt;
    public string clickedBaseName;
    public string potentialSliceName;
    public int[,] score = { { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0 } };
    public int sum1, sum2, sum3;
    public float count = 0;
    bool goNotGo = true;
    public bool deactivate = false;
    
    public void textScoreShow(string clickedBaseName, string potentialSliceName)
    {
        scoreDefine(int.Parse(clickedBaseName.Substring(14, 1)) - 1, int.Parse(potentialSliceName.Substring(14, 1)) - 1);
        ScriptTxt.text = "score : " + count;
        PlayerPrefs.SetInt("userScore", (int)count*10);
    }

    void scoreDefine(int clickedBaseNum, int potentialSliceNum)
    {        
        score[clickedBaseNum, potentialSliceNum]++;
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 6; k++)
            {
                //Debug.Log(i + ":" + k+":"+score[i,k]);
                if (score[i, k] > 1)
                {
                    Debug.Log("you lose. score[" + (i + 1) + "," + (k + 1) + "] = " + score[i, k]);
                    goNotGo = false;
                    GameObject.Find("Main Camera").GetComponent<StageController>().activatePanel();
                    deactivate = true;
                    Debug.Log("id : " + PlayerPrefs.GetString("userName"));
                    Debug.Log(" score : " + PlayerPrefs.GetString("userScore"));
                    GameObject.Find("serverConnect").GetComponent<ServerManager>().Call_Login(PlayerPrefs.GetString("userName"), PlayerPrefs.GetInt("userScore"));
                }
            }
        }
        scoreUpDown(clickedBaseNum, potentialSliceNum);
    }

    void scoreUpDown(int clickedBaseNum, int potentialSliceNum)
    {
        sum1 = score[0, 0] + score[0, 1] + score[0, 2] + score[0, 3] + score[0, 4] + score[0, 5];
        sum2 = score[1, 0] + score[1, 1] + score[1, 2] + score[1, 3] + score[1, 4] + score[1, 5];
        sum3 = score[2, 0] + score[2, 1] + score[2, 2] + score[2, 3] + score[2, 4] + score[2, 5];

        if (sum1 == 6)
        {
            count++;
            Debug.Log("score : " + count);
            sum1 = 0;
            for (int i = 0; i < 6; i++)
            {
                score[0, i] = 0;
            }
        }
        else if (sum2 == 6)
        {
            count++;
            Debug.Log("score : " + count);
            sum2 = 0;
            for (int i = 0; i < 6; i++)
            {
                score[1, i] = 0;
            }
        }
        else if (sum3 == 6)
        {
            count++;
            Debug.Log("score : " + count);
            sum3 = 0;
            for (int i = 0; i < 6; i++)
            {
                score[2, i] = 0;
            }
        }
        ScriptTxt.text = "score : " + count;
    }

    void selTxt(bool tf)
    {
        if (tf == true)
        {
            ScriptTxt.text = "score : " + count;
        }
        else
        {
            ScriptTxt.text = "you lose";
        }
    }
    void Update()
    {
        selTxt(goNotGo);
        StartCoroutine("destroyer");
    }
    GameObject[] pspb1;
    GameObject[] pspb2;
    GameObject[] pspb3;
    IEnumerator destroyer()
    {
        pspb1 = GameObject.FindGameObjectsWithTag("pb1");
        pspb2 = GameObject.FindGameObjectsWithTag("pb2");
        pspb3 = GameObject.FindGameObjectsWithTag("pb3");

        if (pspb1.GetLength(0)==6)
        {
            foreach (GameObject data in pspb1)
            {
                Destroy(data);
            }
        }
        else if (pspb2.GetLength(0) == 6)
        {
            foreach (GameObject data in pspb2)
            {
                Destroy(data);
            }
        }
        else if (pspb3.GetLength(0) == 6)
        {
            foreach (GameObject data in pspb3)
            {
                Destroy(data);
            }
        }
        yield return new WaitForSeconds(0.3f);
    }

}