using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    /// <summary>
    /// 플레이어가 가지고 있는 스킬 종류
    /// </summary>
    public int currentSkillCnt;

    /// <summary>
    /// 회사 스킬 레벨
    /// </summary>
    public Dictionary<int, int> skillLevel = new Dictionary<int, int>();

    /// <summary>
    /// 회사 스킬 레벨 초기화
    /// </summary>
    public void InitSkillDictionary()
    {
        for(int i = 0; i < 10; i++)
        {
            skillLevel[i] = 0;
        }
    }

}
