using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class processingSliceGenerator : MonoBehaviour
{    
    Vector3 processingBasePos;
    int choosenSliceNum;
    
    //potentialSliceController에서 실행됨.
    public void makePotentialSlice(string clickedProcessingBaseName, int choosenSliceNum)
    {
        processingBasePos = GameObject.Find(clickedProcessingBaseName).transform.position;
      // if(GameObject .Find("")). GetComponent <>().score[i, k] > 1)
        for (int i = 0; i < 1; i++)
        {
            GameObject processingSlice = Instantiate(Resources.Load("Prefabs/" + "processingSlice" + choosenSliceNum + "Prefab")) as GameObject;
            processingSlice.transform.position = processingBasePos;            
        }        
    }        
}
