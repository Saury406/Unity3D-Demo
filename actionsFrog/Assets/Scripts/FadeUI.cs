using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 淡入淡出UI
/// </summary>
public class FadeUI : MonoBehaviour
{
    private static float UI_Alpha = 1.0f;
    public static float AlphaSpeed = 0.5f;
    private static CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

 
    void Update()
    {
        //若不存在直接结束
        if (canvasGroup == null)
        {
            return;
        }

        //判断透明度
        if (UI_Alpha != canvasGroup.alpha && Spikes.hasDead == true)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, AlphaSpeed * Time.deltaTime);//线性变化 
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
            }
           
        }
    }

    /// <summary>
    /// 淡入事件
    /// </summary>
    public static void UI_Fade_InEvent() {
        UI_Alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 淡出事件
    /// </summary>
    public static void UI_Fade_OutEvent() {
        UI_Alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
