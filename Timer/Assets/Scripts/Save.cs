using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¥¢¥Ê¿‡
/// </summary>
public class Save : MonoBehaviour
{
    public static Save instance;
     void Awake()
    {
        instance = this;
    }

     void Update()
    {
        SaveNum();
    }

    public void SaveNum() {
        PlayerPrefs.SetInt("Days", Timer.day);
        PlayerPrefs.SetInt("Hours", Timer.hour);
        PlayerPrefs.SetInt("Minutes", Timer.minute);
        PlayerPrefs.SetInt("Seconds", Timer.second);
        PlayerPrefs.SetFloat("DeltaTime", Timer.timeSpend);
        Debug.Log("SETING");
        Debug.Log("Days:" + Timer.day + " " + "Seconds" + Timer.second);
    }

}
