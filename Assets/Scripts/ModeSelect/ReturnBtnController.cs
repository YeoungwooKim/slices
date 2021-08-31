using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBtnController : MonoBehaviour
{
    GameObject panel;
    public void returnBtnController()
    {
        Debug.Log("return ");
        panel.SetActive(false);
    }
    
    void Start()
    {
        panel = GameObject.Find("Panel");
    }
}
