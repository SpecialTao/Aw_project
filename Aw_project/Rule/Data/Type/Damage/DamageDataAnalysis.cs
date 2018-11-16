using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 伤害数据解析类
/// </summary>
[System.Serializable]
public class DamageData
{
    /// <summary>
    /// 伤害数值
    /// </summary>
    public int Damage;
    /// <summary>
    /// 伤害类型
    /// 0物理，1魔法
    /// </summary>
    public int DamageType;
}
