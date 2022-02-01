using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private static Animator anim;
     void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// 死亡及动画播放
    /// </summary>
    public static void deadAnimation() {
        anim.SetBool("isDead", true);
    }
    
}
