using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData : BattleObjData
{

}
public class Character : MonoBehaviour
{
    /// <summary>
    /// 数据实例化
    /// </summary>
    public List<CharacterData> characterDatas;
}
