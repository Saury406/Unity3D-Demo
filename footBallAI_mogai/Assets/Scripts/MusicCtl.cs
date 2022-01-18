using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCtl : MonoBehaviour
{
    public Sprite buttonNormal;//正常播放UI
    public Sprite buttonPushed;//暂停UI
    private bool volumeFlag = false;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = (volume > 0) ? buttonNormal : buttonPushed;
    }

    // Update is called once per frame
    public void onClickBtnVolumeAction()
    {
        //设置flag改变图标
        volumeFlag = !volumeFlag;
        volume = (volumeFlag) ? 1 : 0;
        image.sprite = (volumeFlag) ? buttonNormal : buttonPushed;
    }
    private float volume
    {
        get { 
            return AudioListener.volume; 
        }
        set { 
            AudioListener.volume = value; 
        }
    }
}
