using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 战区逻辑处理类
/// </summary>
public class WarZoneManager{
    /// <summary>
    /// 激活站位显示函数
    /// </summary>
    /// <param name="target">目标战区ID</param>
    /// <param name="b">启动or关闭</param>
    public void WarZoneSetActive(List<int> target,bool b)
    {
        List<WarZoneData> infoObj = new List<WarZoneData>();
        for (int i = 0; i < target.Count; i++)
        {
            infoObj.Add(GameObject.Find("Core").GetComponent<MatchDataManager>().matchData.warZone[target[i]]);
            for (int j = 0; j < 4; j++)
            {
                //判断站位上是否有角色
                if (infoObj[i].grid[j].chr.ID == 0)
                {
                    //将战区站位里的info对象激活
                    infoObj[i].grid[j].obj.transform.GetChild(0).GetChild(0).gameObject.SetActive(b);
                }
            }
        }
    }
}
