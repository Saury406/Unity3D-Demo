using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCtl : MonoBehaviour
{
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void OnClickBeginBtn() 
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 设置
    /// </summary>
    public void OnClickSettingBtn()
    {

    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void OnClickExitBtn()
    {
        Application.Quit();
    }

    /// <summary>
    /// 退出当前关卡
    /// </summary>
    public void OnClickQuitLevelBtn() {
        SceneManager.LoadScene(2);
    }

    public void OnClickQuitInSelecterBtn() {
        SceneManager.LoadScene(0);
    }

}
