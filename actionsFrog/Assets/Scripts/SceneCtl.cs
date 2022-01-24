using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneCtl : MonoBehaviour
{
    public static SceneCtl instance;
    [Header("SceneSet")]
    private int scenesCount = 1;
    public Text levelCountTxt;
    private int levelCount = 0;
     void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 设置线程
    /// </summary>
    public void BeginNextLevel()
    {
        StartCoroutine(nextLevel());
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(2.0f);//注意逻辑顺序，先Wait后加载
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}
