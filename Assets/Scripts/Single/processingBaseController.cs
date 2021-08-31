using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class processingBaseController : MonoBehaviour
{
    public string clickedProcessingBaseName;
    public Vector3 clickedProcessingBasePos;
    Collider2D collider2D;
    public GameObject potentialSlice;
    public string potentialSliceName;
    public GameObject[] pb1, pb2, pb3;
    // Use this for initialization
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("clickIdent");
    }
    bool tf = true;

    IEnumerator clickIdent()
    {
        yield return new WaitForSeconds(0.3f);
        if (Input.GetMouseButtonDown(0) && tf==true) // 클릭한 순간
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collider2D.OverlapPoint(mousePosition))
            {
                GameObject.Find("Text").GetComponent<ScoreController>().clickedBaseName = collider2D.gameObject.name;//start requirement 1/2
                saveData(collider2D.gameObject.name);
                for (int i = 1; i <= 6; i++)
                {
                    potentialSlice = GameObject.Find("potentialSlice" + i + "Prefab(Clone)");
                    if (potentialSlice != null)
                    {
                        potentialSliceName = potentialSlice.name;
                        if(GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().temp != null)
                        {
                            GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().temp++;
                        }
                        Debug.Log("temp "+ GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().temp+" rand "+ GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().randt+" chance "+ GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().chance);
                        GameObject.Find("Text").GetComponent<ScoreController>().potentialSliceName = potentialSliceName;//start requirement 2/2
                        GameObject.Find("Text").GetComponent<ScoreController>().textScoreShow(collider2D.gameObject.name, potentialSliceName);
                        //GameObject.Find("Text").GetComponent<ScoreController>().textScoreShow(클릭한베이스, 생성된potentialSlice);
                        potentialSlice.GetComponent<potentialSliceController>().startMove();

                        break;
                    }
                }
                tf = false;
                Invoke("delayClick", 0.5f);
            }
        }
        else
        {
            saveData("end");
        }
    }
    void delayClick()
    {
        tf = true;
    }
    void saveData(string clickedObject)
    {
        clickedProcessingBaseName = clickedObject;

        switch (clickedObject)
        {
            case "processingBase1":
                clickedProcessingBasePos = GameObject.Find(clickedObject).transform.position;

                break;
            case "processingBase2":
                clickedProcessingBasePos = GameObject.Find(clickedObject).transform.position;


                break;
            case "processingBase3":
                clickedProcessingBasePos = GameObject.Find(clickedObject).transform.position;

                break;
            case "end":
                clickedObject = "";
                clickedProcessingBasePos = Vector3.zero;

                break;
        }
    }
}
