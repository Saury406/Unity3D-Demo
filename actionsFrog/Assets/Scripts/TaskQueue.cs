using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskQueue
{
    public string _currentName;
    //构造函数
    public TaskQueue()
    {
        m_TaskQueue = new Queue<Task>();
        m_TasksNum = 0;
    }

    /// <summary>
    /// 添加任务
    /// </summary>
    /// <param name="task"></param>
    public void AddTask(Task task)
    {
        m_TaskQueue.Enqueue(task);
    }

    public void AddTask(Action work, string currentTaskName)
    {
        _currentName = currentTaskName;
        Task task = new Task(work,currentTaskName);
        m_TaskQueue.Enqueue(task);
    }

    /// <summary>
    /// 开始任务
    /// </summary>
    public void Start()
    {
        //获取任务队列的总任务数
        m_TasksNum = m_TaskQueue.Count;

        if (OnStart != null)
        {
            OnStart();
        }
        NextTask();
    }

    /// <summary>
    /// 清空任务
    /// </summary>
    public void Clear()
    {
        m_TaskQueue.Clear();
        m_TasksNum = 0;
    }

    /// <summary>
    /// 开始任务回调
    /// </summary>
    public Action OnStart = null;

    /// <summary>
    /// 完成所有任务回调
    /// </summary>
    public Action OnFinish = null;

    /// <summary>
    /// 下一个任务
    /// </summary>
    public void NextTask()
    {
        if (m_TaskQueue.Count > 0)
        {
            Task task = m_TaskQueue.Dequeue();
            task.Work();
            NextTask();
        }
        else
        {
            if (OnFinish != null)
            {
                OnFinish();
            }
        }
    }

    /// <summary>
    /// 当前任务进度
    /// </summary>
    public float TaskProcess
    {
        get
        {
            return 1 - m_TaskQueue.Count * 1.0f / m_TasksNum;
        }
    }

    /// <summary>
    /// 任务队列总任务量
    /// </summary>
    public int m_TasksNum = 0;

    /// <summary>
    /// 任务队列
    /// </summary>
    private Queue<Task> m_TaskQueue;
}