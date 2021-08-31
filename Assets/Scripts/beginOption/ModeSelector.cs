using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour {
    public GameObject SelectModePanel;

    public void cancelModePanel()
    {
        SelectModePanel.SetActive(false);
    }

    public void origin()
    {
        SceneManager.LoadScene("SinglePlayScene");
    }
    public void timeattack()
    {
        SceneManager.LoadScene("TimeAttack");
    }
}
