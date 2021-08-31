using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBtnController : MonoBehaviour {
    GameObject panel;

	public void multiBtnController()
    {
        Debug.Log("hi multi");
        panel.SetActive(true);
    }

    void Start()
    {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
    }
}
