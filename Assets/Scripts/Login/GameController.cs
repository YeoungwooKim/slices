using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IDinputField;
    public InputField PWinputField;

    [Header("CreateAccountPanel")]
    public InputField NewIDinputField;
    public InputField NewPWinputField;
    public GameObject ActivateCreateAccountPanel;
    [Header("URL")]
    public string LoginURL;
    public string CreateURL;

    public void Awake()
    {
        // 파괴금지 api. 게임 전체 데이터를 관리하는
        // App 씬 단 하나에만 사용해주는 것이 좋다.
        // 최초 로드한 데이터를 가비지 메모리로 잃지 않고 유지하기 위함
        DontDestroyOnLoad(GameObject.Find("logger"));
    }

    // Use this for initialization
    void Start()
    {
        LoginURL = "https://wooya1602.000webhostapp.com/login.php";
        CreateURL = "https://wooya1602.000webhostapp.com/CreateAccount.php";
    }

    public void LoginButton()
    {
        StartCoroutine(LoginCo());
    }
    IEnumerator LoginCo()
    {
        Debug.Log(IDinputField.text);
        Debug.Log(PWinputField.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", IDinputField.text);
        form.AddField("Input_pass", PWinputField.text);

        WWW webRequest = new WWW(LoginURL, form);
        yield return webRequest;

        //Debug.Log(webRequest.text);
        
        if (webRequest.text == "success")
        {
            Debug.Log("login success");
            PlayerPrefs.SetString("userName", IDinputField.text);            
            SceneManager.LoadScene("beginOption");
        }
    }
    public void OpenCreateButton()
    {
        ActivateCreateAccountPanel.SetActive(true);

    }
    public void CreateButton()
    {
        StartCoroutine(CreateCo());

    }
    public void returnButton()
    {
        ActivateCreateAccountPanel.SetActive(false);
    }
    IEnumerator CreateCo()
    {
        Debug.Log(" 생성 계정 : " + NewIDinputField.text);
        Debug.Log(" 생성 비번 : " + NewPWinputField.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", NewIDinputField.text);
        form.AddField("Input_pass", NewPWinputField.text);
        form.AddField("Input_info", "새로 가입함");

        WWW webRequest = new WWW(CreateURL, form);
        yield return webRequest;

        Debug.Log(webRequest.text);
        if( webRequest.text == "CreateSuccess")
        {
            GameObject.Find("PanelControl").GetComponent<LoginStageController>().actCreatePanel();
        }
    }
}
