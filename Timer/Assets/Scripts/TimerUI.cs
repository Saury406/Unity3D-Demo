using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioEnd;
    public Image currentImage;
    public Sprite beginSprite;
    public Sprite stopSprite;

    public static int timerFlag = 0;//计时器标记

    //开始计时
    public void onClickBtnBeginTimer() {
        
        if (timerFlag == 0)
        {
            timerFlag = 1;
            audioSource.Play();
            currentImage.sprite = stopSprite;
        }
        else {
            timerFlag = 0;
            audioSource.Play();
            currentImage.sprite = beginSprite;
        }
    }

    //退出结束
    public void onClickBtnEnd() {
        audioEnd.Play();
        Application.Quit(); 
    }
}
