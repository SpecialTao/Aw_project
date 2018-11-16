using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WarZoneData
{
    /// <summary>
    /// 战区的游戏对象
    /// </summary>
    public GameObject obj;
    /// <summary>
    /// 所属玩家
    /// 0红， 1蓝，2中立
    /// </summary>
    public int own;
    /// <summary>
    /// 每回合提供能量
    /// </summary>
    public int energy;
    /// <summary>
    /// 战区视野
    /// </summary>
    public int sight;
    /// <summary>
    /// 战区类型
    /// 0左下角，1下，2右下角，3左，4中心，5右，6左上角，7上，8右上角
    /// </summary>
    public int type;
    /// <summary>
    /// 站位数据
    /// </summary>
    public List<GridData> grid;
}
public class WarZoneDataAnalysis : MonoBehaviour {
    
}
