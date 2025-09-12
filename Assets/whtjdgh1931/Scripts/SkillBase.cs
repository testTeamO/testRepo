using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    /// <summary>
    /// �÷��̾ ������ �ִ� ��ų ����
    /// </summary>
    public int currentSkillCnt;

    /// <summary>
    /// ȸ�� ��ų ����
    /// </summary>
    public Dictionary<int, int> skillLevel = new Dictionary<int, int>();

    /// <summary>
    /// ȸ�� ��ų ���� �ʱ�ȭ
    /// </summary>
    public void InitSkillDictionary()
    {
        for(int i = 0; i < 10; i++)
        {
            skillLevel[i] = 0;
        }
    }

}
