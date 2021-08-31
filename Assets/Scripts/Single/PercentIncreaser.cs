using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentIncreaser : MonoBehaviour {   
    public int temp;
    public int randt;
    public Button FlushButton;
    public int chance;
    void Start()
    {
        randt = Random.Range(1, 6);
        Debug.Log(temp + ",randt" + randt);
    }
    // Update is called once per frame
    void Update () {
        if (temp > 6)
        {
            temp = 0;
        }
        else
        {
            if (temp >= randt)
            {
                chance++;
                temp = 0;
                randt = Random.Range(1, 7);
            }
        }
    }
}
