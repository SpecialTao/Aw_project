using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 时机管理类
/// </summary>
public class TimingManager{
    //委托测试代码
    //Timing timing = new Timing();
    //public DamageData damage;
    //void Awake()
    //{
    //    //100点的物理伤害
    //    damage.Damage = 100;
    //    damage.DamageType = 0;
    //    //注册委托
    //    timing.causeDamage += Test;
    //    //动作发送“造成伤害”时机
    //    timing.CauseDamage(damage);
    //}
    ////测试技能
    //public void Test(DamageData dmg)
    //{
    //    Debug.Log(dmg.Damage + "与" + dmg.DamageType);
    //}
}

/// <summary>
/// 时机
/// </summary>
public class Timing : MonoBehaviour
{

    /// <summary>
    /// 玩家抽卡时
    /// </summary>
    public void DrawCard()
    {

    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 玩家召唤角色时
    /// （玩家ID，角色数据,战区ID，站位ID,时机）
    /// </summary>
    /// <param name="player">玩家ID</param>
    /// <param name="chr">角色数据</param>
    /// <param name="warZone">战区ID</param>
    /// <param name="grid">站位ID</param>
    /// <param name="beforeAfter">0之前，1之后</param>
    public void CallCard(int player,BattleObjData chr,int warZone,int grid,int beforeAfter)
    {
        if(callCard != null)
            callCard(player, chr, warZone, grid, beforeAfter);
    }
    public delegate void CallCardDelegate(int player, BattleObjData chr, int warZone, int grid, int beforeAfter);
    public CallCardDelegate callCard;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 角色造成伤害时
    /// （造成伤害的卡牌，受到伤害的目标，伤害数据，时机）
    /// </summary>
    /// <param name="self">卡牌</param>
    /// <param name="target">目标</param>
    /// <param name="dmg">伤害数据</param>
    /// <param name="beforeAfter">0之前，1之后</param>
    public void CauseDamage(BattleObjData self,BattleObjData target,DamageData dmg,int beforeAfter)
    {
        if (callCard != null)
            causeDamage(self,target,dmg,beforeAfter);
    }
    public delegate void CauseDamageDelegate(BattleObjData self, BattleObjData target, DamageData dmg, int beforeAfter);
    public CauseDamageDelegate causeDamage;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 角色受到伤害时
    /// </summary>
    public void SufferDamage()
    {
        
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 位移&移动时
    /// （位移对象，从战区ID，从站位ID，到战区ID，到站位ID,时机）
    /// </summary>
    /// <param name="self">位移对象</param>
    /// <param name="fZone">“从”战区ID</param>
    /// <param name="fGrid">“从”战位ID</param>
    /// <param name="tZone">“去”战区ID</param>
    /// <param name="tGrid">“去”战位ID</param>
    /// <param name="beforeAfter">0之前，1之后</param>
    public void Shift(BattleObjData self, int fZone, int fGrid, int tZone, int tGrid, int beforeAfter)
    {
        if (shift != null)
            shift(self, fZone, fGrid, tZone, tGrid, beforeAfter);
    }
    public void Move(BattleObjData self, int fZone, int fGrid, int tZone, int tGrid, int beforeAfter)
    {
        if (move != null)
            move(self, fZone, fGrid, tZone, tGrid, beforeAfter);
    }
    public delegate void ShiftDelegate(BattleObjData self, int fZone, int fGrid, int tZone, int tGrid, int beforeAfter);
    public ShiftDelegate shift;
    public ShiftDelegate move;
}
