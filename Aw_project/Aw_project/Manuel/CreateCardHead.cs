using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GetID_data
{
    public string name;
    public Sprite sp;
}
public class CreateCardHead : MonoBehaviour {
    /// <summary>
    /// 放卡片头像的父节点
    /// </summary>
    public Transform cardParent;
    /// <summary>
    /// 头像预制体
    /// </summary>
    public GetID getID_prefab;
    /// <summary>
    /// 存放所有生成出来的卡牌头像
    /// </summary>
    public List<GetID> getID_list;
    /// <summary>
    /// 生成次数
    /// </summary>
    public int count;
    /// <summary>
    /// 获取相机
    /// </summary>
    public ReadToText getCamera;
    public List<GetID_data> getID_dataList;

	// Use this for initialization
	void Start () {
        count = 0;
        foreach (var item in getID_dataList)
        {
            Instantiate(getID_prefab, cardParent).SetPrefeb(item.sp,item.name,count).readToText = getCamera;
            count++;
        }
	}
}
