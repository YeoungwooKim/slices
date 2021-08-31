using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

    public GameObject GameOverPanel;

    public void activatePanel()
    {
        GameOverPanel.SetActive(true);
    }
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void changeOptionButton()
    {
        SceneManager.LoadScene("beginOption");
    }
}
