using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("trigger")]
    public class ITTrigger
    {

        //		public Trigger GenerateItemTrigger(int itemLevel)
        //		{
        //			Trigger trigger = new Trigger();
        //			trigger.Name = this.Name;
        //			int round = RuntimeData.Instance.Round;
        //			if (this.Name == "attribute")
        //			{
        //				string[] array = new string[]
        //				{
        //					"搏击格斗",
        //					"使剑技巧",
        //					"耍刀技巧",
        //					"奇门兵器",
        //					"根骨",
        //					"臂力",
        //					"福缘",
        //					"身法",
        //					"定力",
        //					"悟性"
        //				};
        //				string arg = array[Tools.GetRandomInt(0, array.Length - 1)];
        //				int a = (int)((double)itemLevel * ((double)(round + 3) / 4.0)) + itemLevel;
        //				int b = (int)((double)itemLevel * ((double)(round + 3) / 3.0)) + itemLevel * 2;
        //				trigger.ArgvsString = string.Format("{0},{1}", arg, Tools.GetRandomInt(a, b));
        //				return trigger;
        //			}
        //			if (this.Name == "powerup_skill")
        //			{
        //				Skill random;
        //				for (;;)
        //				{
        //					random = ResourceManager.GetRandom<Skill>();
        //					if ((float)(itemLevel + 4) >= random.Hard)
        //					{
        //						if (random.Hard + 1f >= (float)itemLevel)
        //						{
        //							break;
        //						}
        //					}
        //				}
        //				int a2 = (int)(3f * ((float)(round + 3) / (float)((double)random.Hard / 2.0 + 1.0)));
        //				int num = (int)(15f * ((float)(round + 3) / (float)((double)random.Hard / 2.0 + 1.0)));
        //				if (random.Hard < 6f)
        //				{
        //					num += round * 15;
        //				}
        //				trigger.ArgvsString = string.Format("{0},{1}", random.Name, Tools.GetRandomInt(a2, num));
        //				return trigger;
        //			}
        //			if (this.Name == "powerup_internalskill")
        //			{
        //				InternalSkill random2;
        //				for (;;)
        //				{
        //					random2 = ResourceManager.GetRandom<InternalSkill>();
        //					if ((float)(itemLevel + 4) >= random2.Hard)
        //					{
        //						if (random2.Hard + 1f >= (float)itemLevel)
        //						{
        //							break;
        //						}
        //					}
        //				}
        //				int a3 = (int)(2f * ((float)(round + 3) / (float)((double)random2.Hard / 2.0 + 1.0)));
        //				int num2 = (int)(10f * ((float)(round + 3) / (float)((double)random2.Hard / 2.0 + 1.0)));
        //				if (random2.Hard < 6f)
        //				{
        //					num2 += round * 10;
        //				}
        //				trigger.ArgvsString = string.Format("{0},{1}", random2.Name, Tools.GetRandomInt(a3, num2));
        //				return trigger;
        //			}
        //			if (this.Name == "powerup_aoyi")
        //			{
        //				Aoyi random3;
        //				float startSkillHard;
        //				for (;;)
        //				{
        //					random3 = ResourceManager.GetRandom<Aoyi>();
        //					startSkillHard = random3.GetStartSkillHard();
        //					if ((float)(itemLevel + 4) >= startSkillHard)
        //					{
        //						if (startSkillHard + 1f >= (float)itemLevel)
        //						{
        //							break;
        //						}
        //					}
        //				}
        //				int a4 = (int)(15f * ((float)(round + 3) / (float)((double)startSkillHard / 2.0 + 1.0)));
        //				int num3 = (int)(30f * ((float)(round + 3) / (float)((double)startSkillHard / 2.0 + 1.0)));
        //				if (startSkillHard < 6f)
        //				{
        //					num3 += round * 15;
        //				}
        //				trigger.ArgvsString = string.Format("{0},{1},{2}", random3.Name, Tools.GetRandomInt(a4, num3), Tools.GetRandomInt(0, 10));
        //				return trigger;
        //			}
        //			if (this.Name == "powerup_uniqueskill")
        //			{
        //				UniqueSkill random4;
        //				for (;;)
        //				{
        //					random4 = ResourceManager.GetRandom<UniqueSkill>();
        //					if ((float)(itemLevel + 4) >= random4.Hard)
        //					{
        //						if (random4.Hard + 1f >= (float)itemLevel)
        //						{
        //							break;
        //						}
        //					}
        //				}
        //				int a5 = (int)(10f * ((float)(round + 3) / (float)((double)random4.Hard / 2.0 + 1.0)));
        //				int num4 = (int)(25f * ((float)(round + 3) / (float)((double)random4.Hard / 2.0 + 1.0)));
        //				if (random4.Hard < 6f)
        //				{
        //					num4 += round * 15;
        //				}
        //				trigger.ArgvsString = string.Format("{0},{1}", random4.Name, Tools.GetRandomInt(a5, num4));
        //				return trigger;
        //			}
        //			if (this.Name == "attack")
        //			{
        //				int a6 = itemLevel * 1 * (1 + round * 2);
        //				int b2 = itemLevel * 2 * (1 + round * 2);
        //				trigger.ArgvsString = string.Format("{0},{1}", Tools.GetRandomInt(a6, b2), Tools.GetRandomInt(1, itemLevel));
        //				return trigger;
        //			}
        //			if (this.Name == "powerup_quanzhang" || this.Name == "powerup_qimen" || this.Name == "powerup_daofa" || this.Name == "powerup_jianfa")
        //			{
        //				int a7 = (int)((double)itemLevel * 0.2 * (double)(1 + round * 2));
        //				int b3 = (int)((double)itemLevel * 0.4 * (double)(1 + round * 2));
        //				trigger.ArgvsString = string.Format("{0}", Tools.GetRandomInt(a7, b3));
        //				return trigger;
        //			}
        //			if (this.Name == "criticalp")
        //			{
        //				float num5 = 0.5f;
        //				float num6 = (float)itemLevel;
        //				trigger.ArgvsString = Math.Round(Tools.GetRandom((double)num5, (double)num6), 2).ToString();
        //				return trigger;
        //			}
        //			List<string> list = new List<string>();
        //			list.Clear();
        //			for (int i = 0; i < this.Params.Count; i++)
        //			{
        //				ITParam itparam = this.Params[i];
        //				if (itparam.Min != -1)
        //				{
        //					list.Add(Tools.GetRandomInt(itparam.Min, itparam.Max).ToString());
        //				}
        //				else if (itparam.Pool != string.Empty)
        //				{
        //					string[] array2 = itparam.Pool.Split(new char[]
        //					{
        //						','
        //					});
        //					string item = array2[Tools.GetRandomInt(0, array2.Length - 1)];
        //					list.Add(item);
        //				}
        //			}
        //			trigger.ArgvsString = string.Empty;
        //			for (int j = 0; j < list.Count; j++)
        //			{
        //				Trigger trigger2 = trigger;
        //				trigger2.ArgvsString = trigger2.ArgvsString + list[j] + ",";
        //			}
        //			trigger.ArgvsString.TrimEnd(new char[]
        //			{
        //				','
        //			});
        //			return trigger;
        //		}

        //		// Token: 0x17000080 RID: 128
        //		// (get) Token: 0x060001FE RID: 510 RVA: 0x00017E4C File Offset: 0x0001604C
        //		public bool HasPool
        //		{
        //			get
        //			{
        //				foreach (ITParam itparam in this.Params)
        //				{
        //					if (itparam.Pool != string.Empty)
        //					{
        //						return true;
        //					}
        //				}
        //				return false;
        //			}
        //		}

        //		// Token: 0x040001A8 RID: 424
        //		[XmlAttribute("name")]
        //		public string Name = string.Empty;

        //		// Token: 0x040001A9 RID: 425
        //		[XmlAttribute("w")]
        //		public int Weight = 100;

        //		// Token: 0x040001AA RID: 426
        //		[XmlElement("param")]
        //		public List<ITParam> Params = new List<ITParam>();
    }
}
