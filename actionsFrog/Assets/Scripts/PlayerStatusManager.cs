using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//人物状态
public enum PlayerStatus
{
    None//无技能
        , Jump //普通跳跃
        , SPJump  //超级跳跃
        , Dash //冲刺
        , Levitation //反重力
        , Flash //闪烁
        , Over //穿墙
}

//游戏状态
public enum GameSatus
{
    Start,       //开始
    LevelCount,   //回合计算
    Normal,       //通常
    Win,          //游戏胜利
    Lose,
}       //游戏失败
        //民众状态
public class PlayerStatusManager
{
    //游戏相关状态定义和管理
    public PlayerStatus CurrentPlayerStatus;
    public GameSatus CurrentGameStatus;
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
