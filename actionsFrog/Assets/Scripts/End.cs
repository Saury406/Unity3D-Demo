using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject light_end;
    public static int currentLevelIndex;
    //private static bool CanCallFlag = false;//需要方法传参

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 3;//获取当前编号 -3 由于level1从build3开始
            //Debug.Log(currentLevelIndex);
            light_end.SetActive(true);
            SceneCtl.instance.BeginNextLevel();//开启线程
            //Invoke("nextLevel",2.0f);
        }
    }

    
}
