using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 定义卡牌数据
/// </summary>
[System.Serializable]
public class BattleObjDataView
{
    /// <summary>
    /// 角色名字
    /// </summary>
    public string name;
    /// <summary>
    /// 角色id
    /// </summary>
    public string id;
    /// <summary>
    /// 角色性别
    /// </summary>
    public string sex;
    /// <summary>
    /// 角色势力
    /// </summary>
    public string stage;
    /// <summary>
    /// 角色简介
    /// </summary>
    public string info;
    /// <summary>
    /// 角色类型
    /// </summary>
    public string type;

    /// <summary>
    /// 被动技能名
    /// </summary>
    public string passive_name;
    /// <summary>
    /// 1技能名
    /// </summary>
    public string skill_name_1;
    /// <summary>
    /// 2技能名
    /// </summary>
    public string skill_name_2;
    /// <summary>
    /// 被动技能类型
    /// </summary>
    public string passive_type;
    /// <summary>
    /// 1技能类型
    /// </summary>
    public string skill_type_1;
    /// <summary>
    /// 2技能类型
    /// </summary>
    public string skill_ype_2;
    /// <summary>
    /// 被动技能介绍
    /// </summary>
    public string passive_info;
    /// <summary>
    /// 1技能介绍
    /// </summary>
    public string skill_info_1;
    /// <summary>
    /// 2技能介绍
    /// </summary>
    public string skill_info_2;

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
    /// 1技能消耗
    /// </summary>
    public string skill_cost_1;
    /// <summary>
    /// 2技能消耗
    /// </summary>
    public string skill_cost_2;
    /// <summary>
    /// 1技能CD
    /// </summary>
    public string skill_cooldown_1;
    /// <summary>
    /// 2技能CD
    /// </summary>
    public string skill_cooldown_2;
    /// <summary>
    /// 1技能距离
    /// </summary>
    public string skill_range_1;
    /// <summary>
    /// 2技能距离
    /// </summary>
    public string skill_range_2;
}
/// <summary>
/// 核心游戏数据
/// </summary>
[System.Serializable]
public class GameDataView
{
    /// <summary>
    /// 保存日期
    /// </summary>
    public string date;
    /// <summary>
    /// 所有卡牌的数据
    /// </summary>
    public List<BattleObjDataView> allBattleObjData;
}
public class ViewData : MonoBehaviour {
    /// <summary>
    /// 游戏运行时声明的实例
    /// </summary>
    public GameDataView gameData;
    /// <summary>
    /// 字符串数据
    /// </summary>
    public string gameData_json;

	// Use this for initialization
	void Awake () {
        //将gameData序列化变成字符串
        gameData_json = JsonUtility.ToJson(gameData);
        //新建卡组存档文件
        System.IO.StreamWriter writer =  System.IO.File.CreateText(Application.temporaryCachePath + "/GameData.json");
        writer.Write(gameData_json);
        writer.Close();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
