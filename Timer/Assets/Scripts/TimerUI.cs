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

    public static int timerFlag = 0;//��ʱ�����

    //��ʼ��ʱ
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

    //�˳�����
    public void onClickBtnEnd() {
        audioEnd.Play();
        Application.Quit(); 
    }
}
