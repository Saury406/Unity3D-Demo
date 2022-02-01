using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//人物状态
public enum PlayerStatus
{
    None//无技能   0 : index
        , Jump //普通跳跃   1
        , SPJump  //超级跳跃    2
        , Dash //冲刺     3
        , Levitation //反重力  4
        , Flash //闪烁    5
        , Over //穿墙     6
}

//游戏状态
public enum GameSatus
{
    Start,        //开始
    LevelCount,   //回合计算
    Normal,       //通常
    Win,          //游戏胜利
    Lose,         //游戏失败
}       
public class PlayerStatusManager
{
    //游戏相关状态定义和管理
    public static PlayerStatus CurrentPlayerStatus;
    public static GameSatus CurrentGameStatus;


    void Start()
    {
        CurrentPlayerStatus = PlayerStatus.None;//无状态初始化
        CurrentGameStatus = GameSatus.Start;//游戏开始
    }

    //构造函数
    public PlayerStatusManager(PlayerStatus currentPlayerStatus, GameSatus currentGameStatus)
    {
        CurrentPlayerStatus = currentPlayerStatus;
        CurrentGameStatus = currentGameStatus;
    }

    public PlayerStatus GetCarbonSatus()
    {
        return CurrentPlayerStatus;
    }
    public GameSatus GetGameSatus()
    {
        return CurrentGameStatus;
    }
}
