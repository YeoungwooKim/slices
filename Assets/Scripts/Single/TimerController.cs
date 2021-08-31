using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
    public Text timerTxt;
    float time;
    int time2;
    float savedTime = 30;
    Vector3 targetPos;

    void Start () {
        targetPos = GameObject.Find("TimerBg").transform.position;
     }

    private void Update()
    {
        //timerTxt.transform.position = new Vector3(targetPos.x, targetPos.y, timerTxt.transform.position.z);        
        if(savedTime >= 0 && GameObject.Find("Text").GetComponent<ScoreController>().deactivate == false)
        {            
            time += Time.deltaTime;

            timerTxt.text = string.Format("{0:N1}", savedTime);
            savedTime -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<StageController>().activatePanel();
            timerTxt.text = "";
        }
    }
}
