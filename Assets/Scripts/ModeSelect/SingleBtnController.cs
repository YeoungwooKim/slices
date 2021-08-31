using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleBtnController : MonoBehaviour {
//using UnityEngine.SceneManagement;
    public void singleBtnController()
    {
        Debug.Log("hi single");
        SceneManager.LoadScene("SinglePlayScene");
    }
}
