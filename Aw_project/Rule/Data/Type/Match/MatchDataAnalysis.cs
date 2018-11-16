using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战局数据解析类
/// </summary>
[System.Serializable]
public class MatchData
{
    /// <summary>
    /// 当前回合数
    /// ：记录当前大回合
    /// </summary>
    public int Turn;
    /// <summary>
    /// 昼夜
    /// ：0白天，1夜晚
    /// </summary>
    public int DayNight;
    /// <summary>
    /// 当前玩家
    /// ：0红方，1蓝方
    /// </summary>
    public int Player;
}
public class MatchDataAnalysis : MonoBehaviour {
    
}
