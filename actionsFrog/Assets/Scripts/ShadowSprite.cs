using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池设计 赋予给残影
/// </summary>
public class ShadowSprite : MonoBehaviour
{
    private Transform playerTrs;

    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("TimeController")]
    public float activeTime;//显示时间
    public float activeStartTime;//开始显示的时间

    [Header("alphaController")]
    private float alpha;
    public float alphaSet;//初始值
    public float alphaMultiplier;//变量比例

    /// <summary>
    /// 在启用的时候调用 
    /// </summary>
    private void OnEnable()
    {
        playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = this.GetComponent<SpriteRenderer>();
        playerSprite = playerTrs.GetComponent<SpriteRenderer>();

        //copy透明度
        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;
        
        //残影同步
        this.transform.position = playerTrs.position;
        this.transform.rotation = playerTrs.rotation;
        this.transform.localScale = playerTrs.localScale;

        //残影开始时间 (开始对象池
        activeStartTime = Time.deltaTime;
    }

    void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(0.5f, 0.5f, 1, alpha);
        thisSprite.color = color;

        //返回对象池
        if (Time.deltaTime >= activeStartTime + activeTime) {
            ShadowPoolCtl.instance.ReturnPool(this.gameObject);
        }
    }
}
