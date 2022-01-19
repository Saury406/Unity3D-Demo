using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPoolCtl : MonoBehaviour
{
    public static ShadowPoolCtl instance;
    public GameObject shadowPrefabs;

    public int shadowCount;

    //新建对象池队列
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

     void Awake()
    {
        instance = this;

        //初始化对象池
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++) {
            var newShadow = Instantiate(shadowPrefabs);
            //并为子物体
            newShadow.transform.SetParent(this.transform);

            //取消启用，返回对象池
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject) {
        //取消启用，等待调用
        gameObject.SetActive(false);
        //取消显示，加入队列
        availableObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool() {
        //若生成时间内已经完成了对所有对象池的对象启用，则重新初始化对象池防止不够用残影 
        if (availableObjects.Count == 0) {
            FillPool();
        }
        var outShadow =  availableObjects.Dequeue();
        outShadow.SetActive(true);

        return outShadow;
    }


}
