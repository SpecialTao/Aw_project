using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 动作类
/// </summary>
public class Action : MonoBehaviour
{
    public MatchDataManager getData;
    public CardControlManager cardControlManager;
    public Timing timing;
    public GameObject gameChr;
    
    /// <summary>
    /// 位移动作
    /// </summary>
    /// <param name="chr"></param>
    /// <param name="fZone"></param>
    /// <param name="fGrid"></param>
    /// <param name="tZone"></param>
    /// <param name="tGrid"></param>
    public void Shift(BattleObjData chr,int fZone,int fGrid,int tZone,int tGrid)
    {

    }

    /// <summary>
    /// 召唤卡牌动作
    /// （玩家ID，角色数据，战区id，格子id）
    /// </summary>
    /// <param name="player">玩家ID</param>
    /// <param name="chr">角色数据</param>
    /// <param name="warzone">战区id</param>
    /// <param name="grid">格子id</param>
    public void CallCard(int player,BattleObjData chr,int warzone,int grid)
    {
        //寻找卡牌位置
        int search = 0;
        Transform posi;
        {
            //时机：召唤卡牌前
            timing.CallCard(player, chr, warzone, grid, 0);
            //改变游戏目标的父级
            posi = GameObject.Find("IHandCard").transform.GetComponentInChildren<Transform>();
            foreach (Transform item in posi)
            {
                if(int.Parse(item.name) == chr.ID)
                    item.SetParent(GameObject.Find("IBattleField").transform);
            }
            //将目标作用效果设置为不激活
            cardControlManager.Judge(false);
            //数据传输
            {
                //查找目标卡牌下标
                for (int i = 0; i < getData.matchData.player[player].card.Count; i++)
                {
                    if (getData.matchData.player[player].card[i].ID == chr.ID)
                    {
                        search = i;
                        break;
                    }
                }
                //将角色数据赋值至战场上
                getData.matchData.warZone[warzone].grid[grid].chr = getData.matchData.player[player].card[search];
                //移除手牌卡牌数据
                getData.matchData.player[player].card.RemoveAt(search);
            }
            //对象生成
            {
                //生成一个预制体
                GameObject a = Instantiate(gameChr, GameObject.Find("Panel").transform.GetChild(warzone).GetChild(grid));
                //将图片赋值到角色对象上
                a.GetComponent<Image>().sprite = chr.image;
                //将属性显示到UI上（Hp、Atk、Def、Mp）
                UIview(a, chr);
            }
            Debug.Log("1");
            //时机：召唤卡牌后
            timing.CallCard(player, chr, warzone, grid, 1);
        }
    }
    /// <summary>
    /// 显示UI的方法
    /// </summary>
    /// <param name="a">对象</param>
    /// <param name="chr">角色数据</param>
    public void UIview(GameObject a,BattleObjData chr)
    {
        a.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = chr.hp.ToString();
        a.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = chr.atk.ToString();
        a.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = chr.def.ToString();
        a.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = chr.mp.ToString();
        a.transform.GetChild(1).GetChild(5).GetComponent<Text>().text = chr.name.ToString();
    }
}