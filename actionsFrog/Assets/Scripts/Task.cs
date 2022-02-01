using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task
{
    //任务名
    private string m_TaskName;
    public string TaskName
    {
        set
        {
            m_TaskName = value;
        }
        get
        {
            return m_TaskName;
        }
    }

    //任务具体内容，外部传入
    public Action Work;

    /// <summary>
    /// 当前任务
    /// </summary>
    /// <param name="work"></param>
    /// <param name="taskName"></param>
    public Task(Action work, string taskName = "defaultTaskName")
    {
        this.Work = work;
        this.m_TaskName = taskName;
    }
}

