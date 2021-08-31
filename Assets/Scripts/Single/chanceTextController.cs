using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chanceTextController : MonoBehaviour {
    public Text chanceTxt;
    public GameObject GameOverPanel;
	// Update is called once per frame
	void Update () {        
        chanceTxt.text = "기회 : " + GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().chance;
        if(GameOverPanel.activeSelf == true)
        {
            chanceTxt.text = "";
        }
    }
}
