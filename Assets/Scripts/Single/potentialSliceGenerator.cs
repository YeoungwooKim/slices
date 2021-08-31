using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class potentialSliceGenerator : MonoBehaviour
{
    int length;
    int chooseSliceNum = 0;
    Vector2 potentialBasePos; public GameObject potentialSlice;
    public OptionController Option;
    // Use this for initialization
    void Start()
    {
        Option = GameObject.Find("Main Camera").GetComponent<OptionController>();
        potentialBasePos = GameObject.Find("potentialBase").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        length = GameObject.Find("potentialBase").GetComponent<potentialBaseController>().lengthOfPotentialSlice; //실행 코드 찾기
        if (length < 1) //potentialBase is clicked!
        {
            chooseSliceNum = GameObject.Find("potentialBase").GetComponent<potentialBaseController>().random; // 난수 확인      
            
            makePotentialSlice();
        }
    }

    void makePotentialSlice()
    {        
        for (int i = 0; i < 1; i++)
        {
            potentialSlice = Instantiate(Resources.Load("Prefabs/" + "potentialSlice" + chooseSliceNum + "Prefab")) as GameObject;
            potentialSlice.transform.position = potentialBasePos;
            
        }
    }   
}
