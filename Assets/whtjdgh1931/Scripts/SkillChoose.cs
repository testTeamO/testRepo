using System.Collections.Generic;
using UnityEngine;

public class SkillChoose : MonoBehaviour
{
		/// <summary>
		/// ȸ�� Dictionary
		/// </summary>
		private Dictionary<SkillBase, List<Vector2Int>> CompanyDic = new Dictionary<SkillBase, List<Vector2Int>>();

		[SerializeField] private Skill_One skillOne;
		[SerializeField] private Skill_Two skillTwo;
		[SerializeField] private Skill_Three skillThree;
		[SerializeField] private Skill_Four skillFour;
		[SerializeField] private Skill_Five skillFive;

		public SkillBase preSkillCompany;

		void Start()
		{
				// ȸ�� ��ų �ʱ�ȭ
				skillOne.InitSkillDictionary();
				skillTwo.InitSkillDictionary();
				skillThree.InitSkillDictionary();
				skillFour.InitSkillDictionary();
				skillFive.InitSkillDictionary();

				// ȸ�� ��ų Dictionary�� ����
				CompanyDic[skillOne] = new List<Vector2Int>();
				for (int i = 0; i < 10; i++)
				{
						CompanyDic[skillOne].Add(new Vector2Int(i,0));
				}

				CompanyDic[skillTwo] = new List<Vector2Int>();
				for (int i = 0; i < 10; i++)
				{
						CompanyDic[skillTwo].Add(new Vector2Int(i, 0));
				}

				CompanyDic[skillThree] = new List<Vector2Int>();
				for (int i = 0; i < 10; i++)
				{
						CompanyDic[skillThree].Add(new Vector2Int(i, 0));
				}

				CompanyDic[skillFour] = new List<Vector2Int>();
				for (int i = 0; i < 10; i++)
				{
						CompanyDic[skillFour].Add(new Vector2Int(i, 0));
				}

				CompanyDic[skillFive] = new List<Vector2Int>();
				for (int i = 0; i < 10; i++)
				{
						CompanyDic[skillFive].Add(new Vector2Int(i, 0));
				}


		}

		public void OnClickBtn()
		{
				// �ӽ� ��Ʈ
				int tempNum = 0;
				//ĳ���Ͱ� ������ ȸ�縦 �̾Ҵٸ�
				if (preSkillCompany != null)
				{
						// ĳ���Ͱ� ������ �̾Ҵ� ȸ���� ��ų�� ������ (25%)
						tempNum = Random.Range(0, 100);
						if (tempNum < 25)
						{
								// �ش� ȸ���� ��ų�� �̰� ���׷��̵�
								tempNum = Random.Range(0, 10);
								Vector2Int upgradeSkill = CompanyDic[preSkillCompany][tempNum];
								Debug.Log("PreCompany" + upgradeSkill.ToString());
								upgradeSkill.y += 1;
								if (upgradeSkill.y == 1) preSkillCompany.currentSkillCnt++;
								CompanyDic[preSkillCompany][tempNum] = upgradeSkill;
								return;
						}
				}


				tempNum = Random.Range(0, 5);
				switch (tempNum)
				{
						case 0:
								preSkillCompany = skillOne;
								break;
						case 1:
								preSkillCompany = skillTwo;
								break;
						case 2:
								preSkillCompany = skillThree;
								break;
						case 3:
								preSkillCompany = skillFour;
								break;
						case 4:
								preSkillCompany = skillFive;
								break;
						default:
								Debug.Log("�����߻� : " + tempNum);
								break;
				}

				// �ش� ȸ���� ��ų�� �̰� ���׷��̵�
				tempNum = Random.Range(0, 10);
				Vector2Int tempSkill = CompanyDic[preSkillCompany][tempNum];
				Debug.Log(preSkillCompany + tempSkill.ToString());
				tempSkill.y += 1;
				if (tempSkill.y == 1) preSkillCompany.currentSkillCnt++;
				CompanyDic[preSkillCompany][tempNum] = tempSkill;
				return;

		}
}
