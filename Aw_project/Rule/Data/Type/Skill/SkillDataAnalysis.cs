using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能数据解析类
/// </summary>
[System.Serializable]
public class SkillData
{
    /// <summary>
    /// 技能名
    /// </summary>
    public string name;
    /// <summary>
    /// 技能ID
    /// </summary>
    public int ID;
    /// <summary>
    /// 技能类型
    /// ：0物理，1魔法，2能力，3科技
    /// </summary>
    public int type;
    /// <summary>
    /// 是否为被动技能 
    /// </summary>
    public bool isPassive;
    /// <summary>
    /// 技能消耗
    /// ：以能量为基本单位
    /// </summary>
    public int cost;
    /// <summary>
    /// 技能冷却时间
    /// ：以回合为基本单位
    /// </summary>
    public int CD;
    /// <summary>
    /// 技能释放模式
    /// ：0战区，1格，2方向，3无目标
    /// </summary>
    public int mode;
    /// <summary>
    /// 技能释放目标
    /// ：0己方角色，1敌方角色，3场景，4特殊对象
    /// </summary>
    public int[] target;
    /// <summary>
    /// 技能释放形状
    /// ：0正常，1十字
    /// </summary>
    public int shape;
    /// <summary>
    /// 技能释放距离
    /// ：基本单位根据模式决定，方向和无目标距离为零
    /// </summary>
    public int range;
}

public class SkillDataAnalysis : MonoBehaviour {
    /// <summary>
    /// 技能数据
    /// </summary>
    public List<SkillData> skillData;
}
