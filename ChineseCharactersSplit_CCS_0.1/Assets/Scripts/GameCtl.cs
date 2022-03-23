
using System;
using System.Collections;
using UnityEngine;

public class GameCtl : MonoBehaviour
{
    // 小场景摄像机
    [SerializeField] private Transform[] littleSceneCams;
    // 小场景中心（相机围绕次中心旋转）
    [SerializeField] private Transform[] littleSceneCenters;

    // 盒子
    [SerializeField] private Transform box;

    // 主摄像机
    [SerializeField] private Transform camMain;


    private float m_deltaX;
    private float m_deltaY;
    [SerializeField] private float m_rotateSpeed;

    [SerializeField] private Vector3 lookOffset = new Vector3(0, 1, 0);

    [SerializeField] private Vector3 lookFaceOffset = new Vector3(0, -0.5f, 0);

    [SerializeField] private float moveYSpeed = 0.05f;

    [SerializeField] private float moveZSpeed = 0.1f;

    private int level = 0;

    [SerializeField] private Animator ani;

    private bool canRotate = true;

    void Update()
    {
        if (!canRotate || !Input.GetMouseButton(0)) return;
        m_deltaX = Input.GetAxis("Mouse X");
        m_deltaY = Input.GetAxis("Mouse Y");

        if (m_deltaX == 0 && m_deltaY == 0)
        {
            return;
        }
        // 左右旋转盒子
        box.Rotate(Vector3.up, -m_deltaX);
        // 左右旋转每个小场景
        for (int i = 0, len = littleSceneCenters.Length; i < len; ++i)
        {
            littleSceneCenters[i].Rotate(Vector3.up, -m_deltaX * m_rotateSpeed);
        }


        // 移动主摄像机
        camMain.localPosition += new Vector3(0, m_deltaY * moveYSpeed, m_deltaY * moveZSpeed);


        // 限制主摄像机的移动区域
        if (LimitCamPos()) return;

        // 移动小场景摄像机
        for (int i = 0, len = littleSceneCams.Length; i < len; ++i)
        {
            var cam = littleSceneCams[i];
            cam.localPosition += new Vector3(0, m_deltaY * moveYSpeed, m_deltaY * moveZSpeed);
            cam.LookAt(littleSceneCenters[i].position + lookFaceOffset);
        }

        // 检查是否触发了机关
        CheckLevelCondition();
    }

    // 限制主摄像机的移动区域 
    private bool LimitCamPos()
    {
        var curPos = camMain.position;
        var isOut = false;
        if (curPos.z < -5f)
        {
            curPos.z = -5f; isOut = true;
        }

        if (curPos.z > 1.2f)
        {
            curPos.z = 1.2f; isOut = true;
        }
        if (curPos.y > 4.8f)
        {
            curPos.y = 4.8f; isOut = true;
        }
        if (curPos.y < 1.3f)
        {
            curPos.y = 1.3f; isOut = true;
        }
        camMain.position = curPos;
        camMain.LookAt(box.position + lookOffset);
        return isOut;
    }

    /// <summary>
    /// 检测是否触发了机关
    /// </summary>
    private void CheckLevelCondition()
    {
        if (Vector3.Distance(camMain.position, new Vector3(0, 2.242501f, -3.405001f)) <= 0.5f &&
            Math.Abs(camMain.localEulerAngles.x - 20.047f) <= 2 &&
            0 == level)
        {
            Debug.Log("触发了机关");
            StartCoroutine(NextLevel());
        }
    }


    // 下一关
    private IEnumerator NextLevel()
    {
        canRotate = false;
        ++level;
        ani.SetInteger("level", level);
        yield return null;
        ani.SetInteger("level", 0);
        // 四秒后才允许旋转
        yield return new WaitForSeconds(4);
        canRotate = true;
    }
}
