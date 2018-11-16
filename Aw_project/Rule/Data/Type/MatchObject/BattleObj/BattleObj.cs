using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可战斗对象
/// </summary>
[System.Serializable]
public class BattleObjData : MatchObjectData {
    /// <summary>
    /// 角色名字
    /// </summary>
    public string name;
    /// <summary>
    /// 角色头像
    /// </summary>
    public Sprite image;
    /// <summary>
    /// 角色id
    /// </summary>
    public int ID;
    /// <summary>
    /// 角色归属
    /// 0无归属，1红方，2蓝方
    /// </summary>
    public int own;
    /// <summary>
    /// 角色性别
    /// 0女，1男，2中性
    /// </summary>
    public int sex;
    /// <summary>
    /// 角色势力
    /// 0森之宁，1克里，2卡亚，3坎克索拉
    /// </summary>
    public int stage;
    /// <summary>
    /// 角色类型
    /// 0近战，1远程
    /// </summary>
    public int type;

    /// <summary>
    /// 角色生命值
    /// </summary>
    public int hp;
    /// <summary>
    /// 角色攻击力
    /// </summary>
    public int atk;
    /// <summary>
    /// 角色防御力
    /// </summary>
    public int def;
    /// <summary>
    /// 角色魔法力
    /// </summary>
    public int mp;
    /// <summary>
    /// 角色护盾
    /// </summary>
    public int sd;

    /// <summary>
    /// 角色视野
    /// ：以格子为基本单位
    /// </summary>
    public int sight;
    /// <summary>
    /// 角色行动力
    /// ：初始值为1，战区内移动不会消耗行动力
    /// </summary>
    public int ap;
    /// <summary>
    /// 角色移动力
    /// ：以战区为基本单位
    /// </summary>
    public int rp;
    /// <summary>
    /// 角色攻击距离
    /// ：以战区为基本单位
    /// </summary>
    public int ar;
}
