using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MatchInitialize{
    /// <summary>
    /// 初始化的info对象
    /// </summary>
    public GameObject info;
    /// <summary>
    /// 初始化的card对象
    /// </summary>
    public GameObject card;
    /// <summary>
    /// 手牌存放对象
    /// </summary>
    public GameObject handCard;
}
public class MatchInitialization : MonoBehaviour {
    /// <summary>
    /// 战局数据实例
    /// </summary>
    MatchDataManager getData;
    /// <summary>
    /// 声明初始化变量
    /// </summary>
    public MatchInitialize matchInitialize;
    /// <summary>
    /// 游戏初始化主逻辑
    /// </summary>
    void Start()
    {
        //战局数据
        getData = GameObject.Find("Core").GetComponent<MatchDataManager>();
        //生成控制节点
        CreateInfo();
        //读取双方玩家卡组
        GetCards();
    }
    /// <summary>
    /// 为每个战区生成控制节点
    /// 关联代码文件：WarZoneSelectManager
    /// </summary>
    public void CreateInfo()
    {
        //为每个站位生成info预制体
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                //生成一个info预制体
                GameObject a = Instantiate(matchInitialize.info, getData.matchData.warZone[i].grid[j].obj.transform);
                //设置预制体战区位置ID
                a.GetComponent<WarZoneSelectManager>().positonID.warZoneID = i;
                //设置预制体站位位置ID
                a.GetComponent<WarZoneSelectManager>().positonID.gridID = j;
                //将预制体默认设置为不激活
                a.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// 获取卡组的方法
    /// </summary>
    public void GetCards()
    {
        //发送手牌
        for (int i = 0; i < 5; i++)
        {
            //获取卡牌数据
            BattleObjData card = GameObject.Find("DataAnalysis").GetComponent<Character>().characterDatas[i];
            //生成一个手牌预制体
            GameObject a = Instantiate(matchInitialize.card, matchInitialize.handCard.transform);
            //将卡牌数据传入战局数据管理类
            getData.matchData.player[0].card[i] = card;
            //修改卡牌对象名字为卡牌ID
            a.GetComponent<Image>().name = (i+1).ToString();
            //修改头像
            a.GetComponent<Image>().sprite = card.image;
        }
    }
}
