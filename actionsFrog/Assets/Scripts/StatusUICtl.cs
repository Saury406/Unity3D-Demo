using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUICtl : MonoBehaviour
{
    public Text PlayerActionStatus;
    void Start()
    {
        
    }

    void Update()
    {
        PlayerActionStatus.text = "PlayerStatus:" + PlayerStatusManager.CurrentPlayerStatus.ToString();
    }
}
