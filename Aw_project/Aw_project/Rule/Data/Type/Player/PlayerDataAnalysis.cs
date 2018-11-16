using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    /// <summary>
    /// 玩家手牌数据
    /// </summary>
    public List<BattleObjData> card;
    /// <summary>
    /// 玩家牌库数据
    /// </summary>
    public List<BattleObjData> cards;
    /// <summary>
    /// 玩家坟场数据
    /// </summary>
    public List<BattleObjData> death;
}
public class PlayerDataAnalysis : MonoBehaviour {

}
