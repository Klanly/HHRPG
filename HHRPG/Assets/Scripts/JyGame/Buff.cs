using System;
using System.Collections.Generic;

namespace JyGame
{
	// Token: 0x02000037 RID: 55
	public class Buff
	{
		// Token: 0x0600019E RID: 414 RVA: 0x00015120 File Offset: 0x00013320
		public static string BuffsToString(List<Buff> buffs)
		{
			if (buffs.Count > 0)
			{
				string text = string.Empty;
				foreach (Buff buff in buffs)
				{
					text += string.Format("#{0}.{1}.{2}.{3}", new object[]
					{
						buff.Name,
						buff.Level,
						buff.Round,
						buff.Property
					});
				}
				text = text.TrimStart(new char[]
				{
					'#'
				});
				return text;
			}
			return string.Empty;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600019F RID: 415 RVA: 0x000151F0 File Offset: 0x000133F0
		public bool IsDebuff
		{
			get
			{
				foreach (string value in Buff.BuffNames)
				{
					if (this.Name.Equals(value))
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00015230 File Offset: 0x00013430
		public static IEnumerable<Buff> Parse(string content)
		{
			if (string.IsNullOrEmpty(content))
			{
				yield break;
			}
			string[] tmp = content.Split(new char[]
			{
				'#'
			});
			foreach (string s in tmp)
			{
				string[] paras = s.Split(new char[]
				{
					'.'
				});
				string name = paras[0];
				int level = 1;
				int round = 3;
				int property = -1;
				if (paras.Length > 1)
				{
					level = int.Parse(paras[1]);
				}
				if (paras.Length > 2)
				{
					round = int.Parse(paras[2]);
				}
				if (paras.Length > 3)
				{
					property = int.Parse(paras[3]);
				}
				yield return new Buff
				{
					Name = name,
					Level = level,
					Round = round,
					Property = property
				};
			}
			yield break;
		}

		// Token: 0x0400012A RID: 298
		public static string[] BuffNames = new string[]
		{
			"恢复",
			"集气",
			"攻击强化",
			"飘渺",
			"左右互搏",
			"神速攻击",
			"醉酒",
			"溜须拍马",
			"易容",
			"狂战",
			"坚守",
			"沾衣十八跌",
			"圣战",
			"轻身",
			"防御强化",
			"魔神降临",
			"神行"
		};

		// Token: 0x0400012B RID: 299
		public static string[] DebuffNames = new string[]
		{
			"中毒",
			"内伤",
			"致盲",
			"缓速",
			"晕眩",
			"攻击弱化",
			"诸般封印",
			"剑封印",
			"刀封印",
			"拳掌封印",
			"奇门封印",
			"伤害加深",
			"重伤",
			"定身",
			"封穴",
			"点穴"
		};

		// Token: 0x0400012C RID: 300
		public string Name;

		// Token: 0x0400012D RID: 301
		public int Level;

		// Token: 0x0400012E RID: 302
		public int Round = -1;

		// Token: 0x0400012F RID: 303
		public int Property = -1;
	}
}
