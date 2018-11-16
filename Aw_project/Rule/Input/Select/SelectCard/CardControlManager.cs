using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControlManager : MonoBehaviour {
    /// <summary>
    /// 一次触发开关
    /// </summary>
    public bool isRead;
    MatchDataManager getData;
    void Start()
    {
        //获取战局Core数据
        getData = GameObject.Find("Core").GetComponent<MatchDataManager>();
    }
    /// <summary>
    /// 点击事件
    /// </summary>
    public void PointerDown()
    {
        //鼠标左键事件
        if (Input.GetMouseButtonDown(0))
        {
            //将选择对象的id传入core数据管理类的“已选择”
            getData.matchData.selecting = int.Parse(this.name);
            //将“已选择”类型定义为卡牌
            getData.matchData.selectType = 2;
            Judge(true);
            isRead = false;
        }
    }
    /// <summary>
    /// 松开事件
    /// </summary>
    public void PointerUp()
    {
        //鼠标左键事件
        if (Input.GetMouseButtonUp(0))
        {
            //判断光标是否移中了目标
            if (!getData.matchData.isSelect)
            {
                //将core数据管理类中的“已选择”重置
                getData.matchData.selecting = 0;
                Judge(false);
            }
        }
    }
    public void Judge(bool b)
    {
        List<int> a = new List<int>();
        getData = GameObject.Find("Core").GetComponent<MatchDataManager>();
        WarZoneManager warZoneManager = new WarZoneManager();
        //获取所有友方战区
        for (int i = 0; i < 9; i++)
        {
            if (getData.matchData.warZone[i].own == 0)
            {
                a.Add(i);
            }
        }
        warZoneManager.WarZoneSetActive(a,b);
        isRead = true;
    }
}
