using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginStageController : MonoBehaviour {

    public GameObject CreateAccountPanel;
    public GameObject LoginPanel;
    public void actCreatePanel()
    {
        CreateAccountPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }
    public void actLoginPanel()
    {
        CreateAccountPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }
}
