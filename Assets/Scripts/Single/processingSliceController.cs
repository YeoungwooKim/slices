using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class processingSliceController : MonoBehaviour
{    
    void OnTriggerEnter2D(Collider2D col)
    {
        //col.gameObject = base
        //gameObject = processingSlice
        
        if (col.gameObject.name == "processingBase1"&& col.gameObject.transform.position == gameObject.transform.position)
        {
            gameObject.tag = "pb1";
        }
        else if (col.gameObject.name == "processingBase2" && col.gameObject.transform.position == gameObject.transform.position)
        {
            gameObject.tag = "pb2";
        }
        else if (col.gameObject.name == "processingBase3" && col.gameObject.transform.position == gameObject.transform.position)
        {
            gameObject.tag = "pb3";
        }

    }    
}
