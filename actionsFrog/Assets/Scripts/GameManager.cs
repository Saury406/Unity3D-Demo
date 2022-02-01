using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private static bool flag = false;
     void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //R键重开 
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//重加载
            Spikes.hasDead = false;//反设
        }

    }
}
