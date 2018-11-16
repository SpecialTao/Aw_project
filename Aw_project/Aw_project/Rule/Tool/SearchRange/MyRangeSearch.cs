using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IRangeSearth
{
    /// <summary>
    /// 接口：实现扩散性的搜索功能
    /// 
    /// 在6*6的棋盘上，根据类型（战区、站位）和距离进行范围判断
    /// 站位使用6*6集合搜索，战区使用3*3集合搜索
    /// 结构：左下角为第一个元素，往右递增，站位结构同理
    /// 返回所有满足条件的ID(战区或站位的下标)
    /// 
    /// 输出范例：
    /// RangeSearch(4,0,0)  返回自身战区ID
    ///     return(1)
    /// RangeSearch(4,0,1)  返回自身以及相邻战区ID
    ///     return(0,1,2,4)
    /// RangeSearch(4,1,1)  返回自身以及相邻站位ID
    ///     return(3,4,5,10) 
    /// RangeSearch(4,1,2)  返回自身、相邻站位ID、相邻站位的相邻站位ID（需除去重复元素）
    ///     return(2,3,4,5,9,10,11,16)
    /// </summary>
    /// <param name="grid">自身站位ID</param>
    /// <param name="type">类型：0战区，1站位</param>
    /// <param name="range">距离</param>
    List<int> RangeSearch(int zone, int grid, int type, int range);
}
/// <summary>
/// 战区搜索功能类
/// </summary>
public class MyRangeSearch : MonoBehaviour, IRangeSearth
{
    private int zoneX = 3;
    private int zoneY = 3;

    private int allX = 6;
    private int allY = 6;

    private int gridX = 2;
    private int gridY = 2;

    public List<int> RangeSearch(int zone, int grid, int type, int range)
    {
        List<int> IDs = null;
        switch (type)
        {
            case 0:
                //转换为战区索引
                
                //战位坐标
                int poix = (grid % 2 == 1 ? 1 : 0) + ( zone % zoneY ) * gridX;
                int poiy = (grid > 1 ? 1 : 0) + zone / zoneX;
                //战区坐标
                int zonex = poix / gridX;
                int zoney = poiy / gridY;

                int zoneIndex = zonex + zoney * zoneY;
                IDs = GetPoisByIndex(zoneIndex, zoneX, zoneY, range);
                break;

            case 1:

                IDs = GetPoisByIndex(grid, gridX, gridY, range);
                break;

            default:
                break;
        }
        return IDs;
    }

    /// <summary>
    /// 根据索引获取索引附近的索引.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="maxY"></param>
    /// <param name="maxX"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    private List<int> GetPoisByIndex(int index, int maxX, int maxY, int range)
    {
        List<int> IDs = new List<int>();
        int theY = index / maxX;
        int theX = index % maxX;
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                int length = GetSelectToPosiDistance(theX, theY, x, y);
                //Console.WriteLine(theX+"," +theY+ ":"+(x + y * maxX) + ":" + length+":"+x+","+y);
                if (length <= range)
                {
                    IDs.Add(x + y * maxX);

                }
            }
        }
        return IDs;
    }

    /// <summary>
    /// 获得点到一个点的步数距离
    /// </summary>
    /// <param name="selectData"></param>
    /// <param name="judgmentPoint"></param>
    /// <returns></returns>
    private int GetSelectToPosiDistance(int poi1X, int poi1Y, int poi2X, int poi2Y)
    {
        return Mathf.Abs(poi2Y - poi1Y) + Mathf.Abs(poi2X - poi1X);
    }
}