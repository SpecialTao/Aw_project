using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlManager : MonoBehaviour {
    /// <summary>
    /// 位置信息
    /// </summary>
    int objName;
    /// <summary>
    /// 一次触发开关
    /// </summary>
    public bool isRead;
    MatchDataManager getData;
    MyRangeSearch rangeSearch;
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
            getData.matchData.selecting = getData.matchData.
                warZone[int.Parse(this.transform.parent.parent.name)].
                grid[int.Parse(this.transform.parent.name)].chr.ID;
            //将“已选择”类型定义为角色
            getData.matchData.selectType = 0;
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
                isRead = true;
            }
        }
    }
    /// <summary>
    /// 判断可选位置
    /// </summary>
    /// <param name="b">开启or关闭</param>
    void Judge(bool b)
    {
        rangeSearch = GameObject.Find("Model").GetComponent<MyRangeSearch>();
        WarZoneManager warZoneManager = new WarZoneManager();
        getData = GameObject.Find("Core").GetComponent<MatchDataManager>();
        //扩散性位置搜索方法
        {
            List<int> a = rangeSearch.RangeSearch(
                int.Parse(this.transform.parent.parent.name),
                int.Parse(this.transform.parent.name),
                0,
                getData.matchData.
                    warZone[int.Parse(this.transform.parent.parent.name)].
                    grid[int.Parse(this.transform.parent.name)].chr.rp);
            warZoneManager.WarZoneSetActive(a, b);
        }
    }
}
