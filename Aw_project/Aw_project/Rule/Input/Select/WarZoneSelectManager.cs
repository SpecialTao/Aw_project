using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PositonID
{
    /// <summary>
    /// 战区ID
    /// </summary>
    public int warZoneID;
    /// <summary>
    /// 站位ID
    /// </summary>
    public int gridID;
}
/// <summary>
///作用效果选择类 
/// </summary>
public class WarZoneSelectManager : MonoBehaviour {
    public GameObject Obj;
    public PositonID positonID;
    MatchDataManager getData;
    Action action;
    void MyGetcomponent()
    {
        action = GameObject.Find("Model").GetComponent<Action>();
        //获取战局Core数据
        getData = GameObject.Find("Core").GetComponent<MatchDataManager>();
    }
    void Start()
    {
        MyGetcomponent();
    }
    /// <summary>
    /// 选中了该作用地域时触发该函数
    /// </summary>
    public void PointerDrag()
    {
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
        {

        }
        else
        {
            MyGetcomponent();
            positonID = getData.matchData.positonID;
            //判断是否选中了对象
            if (getData.matchData.isSelect)
            {
                //“已选择”逻辑
                getData.matchData.isSelect = false;
                //判断选中对象的类型
                switch (getData.matchData.selectType)
                {
                    //选中角色的情况下（移动、攻击）
                    case 0:
                        break;
                    //选中技能的情况下（释放技能）
                    case 1:
                        break;
                    //选中卡牌的情况下（召唤）
                    case 2:
                        action.CallCard(
                            getData.matchData.matchData.Player,
                            SearchCard(
                                getData.matchData.player[getData.matchData.matchData.Player].card,
                                getData.matchData.selecting),
                            positonID.warZoneID,
                            positonID.gridID);
                        break;
                }
            }
            Obj.GetComponent<Image>().color = new Color(0.6640974f, 1, 0.4705882f, 0.3490196f);
        }
    }
    /// <summary>
    /// 通过ID搜索卡牌的方法
    /// </summary>
    /// <param name="cards">要搜索的集合</param>
    /// <param name="ID">卡牌ID</param>
    BattleObjData SearchCard(List<BattleObjData> cards, int ID)
    {
        foreach (var item in cards)
        {
            if (item.ID == ID)
            {
                return item;
            }
        }
        return null;
    }
    /// <summary>
    /// 光标进入时
    /// </summary>
    public void PointerEnter()
    {
        Obj.GetComponent<Image>().color = new Color(0.6640974f, 1, 0.4705882f, 0.6818392f);
        getData.matchData.isSelect = true;
    }
    /// <summary>
    /// 光标离开时
    /// </summary>
    public void PointerLeave()
    {
        Obj.GetComponent<Image>().color = new Color(0.6640974f, 1, 0.4705882f, 0.3490196f);
        getData.matchData.isSelect = false;
    }
    public void SelectEnter()
    {
        getData.matchData.positonID = positonID;
    }
}
