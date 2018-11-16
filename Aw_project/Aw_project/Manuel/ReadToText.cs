using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IngameObject
    {
    /// <summary>
    /// 游戏对象
    /// </summary>
    public List<GameObject> obj;
}
public class ReadToText : MonoBehaviour {
    /// <summary>
    /// 游戏运行时声明的实例
    /// </summary>
    public IngameObject ingameObject;
    /// <summary>
    /// 游戏运行时声明的实例
    /// </summary>
    public List<Text> texts;
    //新建暂存对象
    GameDataView reading = new GameDataView();
    // 点击时调用该函数
    public void ClickEvent(int a)
    {
        texts[0].text = reading.allBattleObjData[a].id;
        texts[1].text = reading.allBattleObjData[a].name;
        texts[2].text = reading.allBattleObjData[a].sex;
        texts[3].text = reading.allBattleObjData[a].stage;
        texts[4].text = reading.allBattleObjData[a].type;
        texts[5].text = reading.allBattleObjData[a].hp.ToString(); 
        texts[6].text = reading.allBattleObjData[a].atk.ToString(); 
        texts[7].text = reading.allBattleObjData[a].def.ToString(); 
        texts[8].text = reading.allBattleObjData[a].mp.ToString(); 
        texts[9].text = reading.allBattleObjData[a].passive_name; 
        texts[10].text = reading.allBattleObjData[a].skill_name_1; 
        texts[11].text = reading.allBattleObjData[a].skill_name_2;
        texts[12].text = reading.allBattleObjData[a].passive_info;
        texts[13].text = reading.allBattleObjData[a].skill_info_1;
        texts[14].text = reading.allBattleObjData[a].skill_info_2;
        texts[15].text = reading.allBattleObjData[a].skill_cost_1;
        texts[16].text = reading.allBattleObjData[a].skill_cost_2;
        texts[17].text = reading.allBattleObjData[a].skill_cooldown_1;
        texts[18].text = reading.allBattleObjData[a].skill_cooldown_2;
        texts[19].text = reading.allBattleObjData[a].skill_range_1;
        texts[20].text = reading.allBattleObjData[a].skill_range_2;
    }
    void Start()
    {
        //读取json文件数据
        string json = File.ReadAllText(Application.temporaryCachePath + "/GameData.json");
        //暂存对象获取json文件数据
        reading = JsonUtility.FromJson<GameDataView>(json);
    }
    void Awake()
    {
        for (int i = 0; i < 21; i++)
        {
           texts.Add(ingameObject.obj[i].GetComponent<Text>());
        }
    }
}
