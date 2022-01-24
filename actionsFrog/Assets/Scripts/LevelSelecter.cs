using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour
{
    public GameObject levelSelectPanel;//选择面板
    Button[] levelSelectButtons;//关卡按钮
    int unlockedLevelIndex;//已解锁关卡编号

     void Start()
    {
        //获取已解锁关卡编号
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevelIndex");
        levelSelectButtons = new Button[levelSelectPanel.transform.childCount];
        for (int i = 0; i < levelSelectPanel.transform.childCount; i++) {
            levelSelectButtons[i] = levelSelectPanel.transform.GetChild(i).GetComponent<Button>();
        }

        for (int i = 0; i < levelSelectButtons.Length; i++) {
            levelSelectButtons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevelIndex + 1; i++) {
            levelSelectButtons[i].interactable = true;
        }

    }

     void Update()
    {
        //判断若当前已通关关卡编号大于已解锁编号，则令解锁编号更新同时保存PlayerPrefs
        if (End.currentLevelIndex > unlockedLevelIndex) {
            unlockedLevelIndex = End.currentLevelIndex;
            PlayerPrefs.SetInt("unlockedLevelIndex",unlockedLevelIndex);
        }
    }


    public void onClickBtnLevel0() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onClickBtnLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void onClickBtnLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void onClickBtnLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

}
