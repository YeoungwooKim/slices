using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBtn : MonoBehaviour {
    
    public void hello()
    {
        if(GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().chance > 0)
        {
            GameObject.Find("Main Camera").GetComponent<PercentIncreaser>().chance--;
            GameObject.Find("potentialBase").GetComponent<potentialBaseController>().random = Random.Range(1, 7); 
            Destroy(GameObject.FindGameObjectWithTag("potentialSlice"));
        }
    }
}
