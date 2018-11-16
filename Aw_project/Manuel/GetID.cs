using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 头像预制体脚本
/// </summary>
public class GetID : MonoBehaviour {
    /// <summary>
    /// 卡牌名字
    /// </summary>
    public Text cardName;
    /// <summary>
    /// 卡牌头像
    /// </summary>
    public Image cardHead;
    /// <summary>
    /// 调用点击数据转换事件
    /// </summary>
    public ReadToText readToText;
    /// <summary>
    /// 鼠标点击函数
    /// </summary>
    public void Click() {
        Debug.Log(readToText);
        readToText.ClickEvent(int.Parse(this.name));
    }
    /// <summary>
    /// 设置名字及图片
    /// </summary>
    public GetID SetPrefeb(Sprite cardImage,string cardName,int a)
    {
        //传名字和图片给脚本附属对象
        this.cardName.text = cardName;
        this.cardHead.sprite = cardImage;
        this.name = a.ToString();
        return this;
    }
}
