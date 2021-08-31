using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potentialSliceController : MonoBehaviour
{   
    GameObject potentialBase;
    GameObject potentialSliceClone;
    GameObject selectedBase;
    Vector3 targetPos;
    Vector3 potentialBasePos;
    Vector3 potentialSliceClonePos;
    Vector3 clickedProcessingBasePos;
    string baseName;    
    int chooseSliceNum;
    public bool counttf = false; 

    // Use this for initialization
    void Start()
    {
        potentialBase = GameObject.Find("potentialBase");
        potentialBasePos = potentialBase.transform.position;
    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "processingBase")
        {            
            Destroy(potentialSliceClone);
            //Debug.Log(potentialSliceClone.name + "is destroyed by " + col.gameObject.name);
            StopCoroutine("pmove");            
            GameObject.Find("processingSliceGen").GetComponent<processingSliceGenerator>().makePotentialSlice(col.gameObject.name, chooseSliceNum);
            //col.gameObject <= 맞은 오브젝트             
            counttf = true;
            Invoke("delaycounttf", 0.3f);
        }
    }
    void delaycounttf()
    {
        counttf = false;
    }
   
    public void startMove()
    {
        potentialBase = GameObject.Find("potentialBase");
        potentialBasePos = potentialBase.transform.position;
        //step1 랜덤생성된 potentialSlice 오브젝트 찾기
        chooseSliceNum = potentialBase.GetComponent<potentialBaseController>().random;
        potentialSliceClone = GameObject.Find("potentialSlice" + chooseSliceNum + "Prefab(Clone)");
        potentialSliceClonePos = potentialSliceClone.transform.position;
        //step2 선택된 processingBase를 찾기

        ident();
    }
    bool flag = true;
    void delayFlag()
    {
        flag = true;
    }
    void ident()
    {
        for (int i = 1; i <= 3; i++)
        {
            baseName = GameObject.Find("processingBase" + i).GetComponent<processingBaseController>().clickedProcessingBaseName;
            //Debug.Log("Clicked baseName is " + baseName);
            if (baseName != "" && baseName != "end"&&flag==true)
            {
                StartCoroutine("pmove");
                selectedBase = GameObject.Find(baseName);
                clickedProcessingBasePos = selectedBase.transform.position;
                targetPos = clickedProcessingBasePos;
                flag = false;
                Invoke("delayFlag", 0.6f);
                break;
            }
            else
            {
                clickedProcessingBasePos = Vector3.zero;
            }
        }
    }
    
    IEnumerator pmove()
    {
        while (true)
        {
            potentialSliceClone.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * 3.0f);            
            yield return new WaitForSeconds(0.01f);
        }
    }
}


/*
  GameObjectName.transform.position = Vector3.Lerp(GameObjectName.transform.position, Pointer.transform.position, Time.deltaTime );
 */

/*
        for (int i = 1; i <= 3; i++)
       {
           baseName = GameObject.Find("processingBase" + i).GetComponent<processingBaseController>().clickedProcessingBaseName;            
           Debug.Log("activate  : " + activate);
           if (baseName != "")
           {
               selectedBase = GameObject.Find(baseName);
               clickedProcessingBasePos = selectedBase.transform.position;
               //Debug.Log(selectedBase + " : " + clickedProcessingBasePos);
           }
       }
*/

/*  마우스로 오브젝트 클릭

    Collider2D collider2D;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 클릭한 순간
        {            
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collider2D.OverlapPoint(mousePosition))
            {
                //do great stuff
            }           
        }  
    }
*/
