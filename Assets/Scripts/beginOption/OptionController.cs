using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public GameObject SelectSlicePanel;
    public GameObject SelectModePanel;
    public int code = 2;
    public object[] potTemp;
    public object[] proTemp;
        
    public void cancelPanel()
    {
        SelectSlicePanel.SetActive(false);
    }

    public void letGetIt()
    {
        SelectModePanel.SetActive(true);
    }
    public void showChangePanel()
    {
        SelectSlicePanel.SetActive(true);
    }
    public void changeApple()
    {
        code = 1;
        switchCode(code);
        SelectSlicePanel.SetActive(false);       
    }
    public void changeDnut()
    {
        code = 2;
        switchCode(code);
        SelectSlicePanel.SetActive(false);        
    }
    public void changePizza()
    {
        code = 3;
        switchCode(code);
        SelectSlicePanel.SetActive(false);        
    }
    public void changeWmelon()
    {
        code = 4;
        switchCode(code);
        SelectSlicePanel.SetActive(false);       
    }
    public void switchCode(int code)
    {
        switch (code)
        {
            case 1: //사과                
                potTemp = Resources.LoadAll("Images/potApple");
                proTemp = Resources.LoadAll("Images/proApple");
                for (int i = 1; i <= 6; i++)
                {
                    (Resources.Load("Prefabs/potentialSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = potTemp[i] as Sprite;
                    (Resources.Load("Prefabs/processingSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = proTemp[i] as Sprite;
                }
                Debug.Log("사과로 변경");
                break;
            case 2: //도넛               
                potTemp = Resources.LoadAll("Images/potDoughnut");
                proTemp = Resources.LoadAll("Images/proDoughnut");
                for (int i = 1; i <= 6; i++)
                {
                    (Resources.Load("Prefabs/potentialSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = potTemp[i] as Sprite;
                    (Resources.Load("Prefabs/processingSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = proTemp[i] as Sprite;
                }
                Debug.Log("도넛으로 변경");
                break;
            case 3: //피자
                potTemp = Resources.LoadAll("Images/potPizza");
                proTemp = Resources.LoadAll("Images/proPizza");
                for (int i = 1; i <= 6; i++)
                {
                    (Resources.Load("Prefabs/potentialSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = potTemp[i] as Sprite;
                    (Resources.Load("Prefabs/processingSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = proTemp[i] as Sprite;
                }
                Debug.Log("피자로 변경");
                break;
            case 4: //수박
                potTemp = Resources.LoadAll("Images/potWmelon");
                proTemp = Resources.LoadAll("Images/proWmelon");
                for (int i = 1; i <= 6; i++)
                {
                    (Resources.Load("Prefabs/potentialSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = potTemp[i] as Sprite;
                    (Resources.Load("Prefabs/processingSlice" + i + "Prefab") as GameObject).GetComponent<SpriteRenderer>().sprite = proTemp[i] as Sprite;
                }
                Debug.Log("수박으로 변경");
                break;
        }
    }
}