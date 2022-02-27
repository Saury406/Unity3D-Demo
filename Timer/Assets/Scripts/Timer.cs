using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static int hour;
    public static int minute;
    public static int second;
    public static int day = 0;
    public Text text_timeSpend;

    // 已经花费的时间
    public static float timeSpend = 0.0f;

     void Start()
    {
        day = PlayerPrefs.GetInt("Days");
        hour = PlayerPrefs.GetInt("Hours");
        minute = PlayerPrefs.GetInt("Minutes");
        second = PlayerPrefs.GetInt("Seconds");
        timeSpend = PlayerPrefs.GetFloat("DeltaTime");
        Debug.Log("GETING");
        Debug.Log("Days:" + day + " " + "Seconds" + second + "\n" + timeSpend);
    }

    void Update()
    {
        if (TimerUI.timerFlag == 1) {
            timeSpend += Time.deltaTime;      
            hour = (int)timeSpend / 3600;
            minute = ((int)timeSpend - hour * 3600) / 60;
            second = (int)timeSpend - hour * 3600 - minute * 60;

            if (hour == 24)
            {
                day++ ;
                hour = 0;
            }

            text_timeSpend.text = string.Format("{0:D2}Days\n{1:D2}H:{2:D2}M:{3:D2}S", day, hour, minute, second);
        }
    }

}
