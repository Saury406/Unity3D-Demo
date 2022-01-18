using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour
{
    private Button btnStart;
    private Button btnQuit;
    private Button btnSet;
    private GameObject setUI;
    private bool isActive = false;

    void Start()
    {
        btnStart = transform.Find("Start").GetComponent<Button>();
        btnSet = transform.Find("Setting").GetComponent<Button>();
        btnQuit = transform.Find("Quit").GetComponent<Button>();
        setUI = transform.Find("setPanel").gameObject;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void onBtnClickSetting()
    {
        if (isActive == false)
            setUI.SetActive(true);
        isActive = true;
    }

    public void onBtnClickQuit() {
        Application.Quit();
    }

    public void onBtnClickQuitSetting() {
        if (isActive == true)
            setUI.SetActive(false);   
    }
}
