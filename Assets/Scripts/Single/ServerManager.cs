using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEditor;
using System;
using System.IO;

public class ServerManager : MonoBehaviour
{
    public String MyName;
    public int Score;
    void Start()
    {
        Debug.Log(MyIP());
        MyName = "";
        Debug.Log(SystemInfo.deviceUniqueIdentifier.Substring(0, 10));
    }
    public void Call_Login(String MyName, int Score)
    {
        this.MyName ="";
        this.Score = 0;
        this.MyName = MyName;
        this.Score = Score;
        StartCoroutine("RankCo");

        Debug.Log(MyIP());
    }



    IEnumerator RankCo()
    {
        WWWForm RankForm = new WWWForm();
        RankForm.AddField("PostState", "PizzaRankInsert");
        RankForm.AddField("User_Name", MyName);
        RankForm.AddField("Score", Score);
        UnityWebRequest www = UnityWebRequest.Post("setinte.com/web.js", RankForm);
        yield return www.SendWebRequest();


        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }

    }
    public string MyIP()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        string myip = host.AddressList[0].ToString();
        return myip;
    }

}