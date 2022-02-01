using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Animator anim;
    [Header("LayerMask")]
    public LayerMask spikesLayer;//尖刺层级
    public GameObject DeadPanel;//死亡文本
    public static bool hasDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //若触碰尖刺层 则死亡
        if (collision.IsTouchingLayers(spikesLayer)) {
            anim.SetTrigger("Die");//噶了
            Destroy(collision.gameObject,0.3f);
            hasDead = true;
        }
    }

}
