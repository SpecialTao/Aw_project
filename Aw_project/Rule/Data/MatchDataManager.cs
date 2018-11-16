using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MatchDataSave
{
    /// <summary>
    /// 保存日期
    /// </summary>
    public string date;
    /// <summary>
    /// 当前选择对象ID
    /// </summary>
    public int selecting;
    /// <summary>
    /// 当前选择对象类型
    /// ：0角色，1技能，2卡牌
    /// </summary>
    public int selectType;
    /// <summary>
    /// 光标选择了对象
    /// </summary>
    public bool isSelect;
    /// <summary>
    /// 选择的位置信息
    /// </summary>
    public PositonID positonID;
    /// <summary>
    /// 比赛数据
    /// </summary>
    public MatchData matchData;
    /// <summary>
    /// 战区数据
    /// </summary>
    public List<WarZoneData> warZone;
    /// <summary>
    /// 玩家数据
    /// </summary>
    public List<PlayerData> player;
}
public class MatchDataManager : MonoBehaviour {
    /// <summary>
    /// 游戏运行时声明的实例
    /// </summary>
    public MatchDataSave matchData;
    /// <summary>
    /// 字符串数据
    /// </summary>
    public string matchData_json;
    void Awake()
    {
        //将gameData序列化变成字符串
        matchData_json = JsonUtility.ToJson(matchData);
        //新建卡组存档文件
        System.IO.StreamWriter writer = System.IO.File.CreateText(Application.temporaryCachePath + "/MatchData.json");
        writer.Write(matchData_json);
        writer.Close();
    }
}
