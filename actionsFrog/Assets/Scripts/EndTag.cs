using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 终点标识
/// </summary>
public class EndTag : MonoBehaviour
{
    private Transform endTagTrans;//标识变换组件 
    private Vector3 end;

    void Start()
    {
        endTagTrans = this.gameObject.GetComponent<Transform>();
        end = GameObject.FindGameObjectWithTag("End").transform.position;
       
    }
    void Update()
    {
        endTagTrans.LookAt(end,Vector3.up);
    }
}
