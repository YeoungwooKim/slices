using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBtnSpinner : MonoBehaviour {
    GameObject btn;
    Vector2 btnPos;
    Vector2 mousePos;
    int distance;

    void Start()
    {
        btn = GameObject.Find("FlushButton");
        btnPos = btn.transform.position;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        distance = (int)Vector2.Distance(btnPos, mousePos);

        if (distance < 2)
        {
            StartCoroutine("Run");
        }
    }

    IEnumerator Run()
    {
        btn.transform.Rotate(0.0f, 0.0f, -15.0f);
        yield return new WaitForFixedUpdate();
    }
}
