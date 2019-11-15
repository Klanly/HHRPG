using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

namespace JyGame
{
    [XmlType("item")]
    public class ItemInstance : BasePojo
    {
        [XmlIgnore]
        private string _name;

        [XmlElement("addition_trigger")]
        public List<Trigger> AdditionTriggers = new List<Trigger>();

        [XmlIgnore]
        private Item _item;

        public override string PK
        {
            get
            {
                string text = this.type + "_" + this.Name;
                foreach (Trigger trigger in this.AdditionTriggers)
                {
                    text = text + "_" + trigger.PK;
                }
                return text;
            }
        }

        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                this._item = Item.GetItem(value);
            }
        }

        //		[XmlIgnore]
        //		public string desc
        //		{
        //			get
        //			{
        //				return this.item.desc;
        //			}
        //		}

        //		// Token: 0x1700006E RID: 110
        //		// (get) Token: 0x060001D9 RID: 473 RVA: 0x000163E4 File Offset: 0x000145E4
        //		[XmlIgnore]
        //		public string talent
        //		{
        //			get
        //			{
        //				return this.item.talent;
        //			}
        //		}

        //		// Token: 0x1700006F RID: 111
        //		// (get) Token: 0x060001DA RID: 474 RVA: 0x000163F4 File Offset: 0x000145F4
        //		[XmlIgnore]
        //		public string pic
        //		{
        //			get
        //			{
        //				return this.item.pic;
        //			}
        //		}

        //		// Token: 0x17000070 RID: 112
        //		// (get) Token: 0x060001DB RID: 475 RVA: 0x00016404 File Offset: 0x00014604
        //		[XmlIgnore]
        //		public int level
        //		{
        //			get
        //			{
        //				return this.item.level;
        //			}
        //		}

        //		// Token: 0x17000071 RID: 113
        //		// (get) Token: 0x060001DC RID: 476 RVA: 0x00016414 File Offset: 0x00014614
        //		[XmlIgnore]
        //		public int price
        //		{
        //			get
        //			{
        //				return this.item.price;
        //			}
        //		}

        //		// Token: 0x17000072 RID: 114
        //		// (get) Token: 0x060001DD RID: 477 RVA: 0x00016424 File Offset: 0x00014624
        //		[XmlIgnore]
        //		public bool drop
        //		{
        //			get
        //			{
        //				return this.item.drop;
        //			}
        //		}

        //		// Token: 0x17000073 RID: 115
        //		// (get) Token: 0x060001DE RID: 478 RVA: 0x00016434 File Offset: 0x00014634
        //		[XmlIgnore]
        //		public string[] Talents
        //		{
        //			get
        //			{
        //				return this.talent.Split(new char[]
        //				{
        //					'#'
        //				}, StringSplitOptions.RemoveEmptyEntries);
        //			}
        //		}

        //		// Token: 0x17000074 RID: 116
        //		// (get) Token: 0x060001DF RID: 479 RVA: 0x00016450 File Offset: 0x00014650
        //		[XmlIgnore]
        //		public string CanzhangSkill
        //		{
        //			get
        //			{
        //				return this.item.CanzhangSkill;
        //			}
        //		}

        //		// Token: 0x17000075 RID: 117
        //		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00016460 File Offset: 0x00014660
        //		[XmlIgnore]
        //		public List<Require> Requires
        //		{
        //			get
        //			{
        //				return this.item.Requires;
        //			}
        //		}

        //		// Token: 0x17000076 RID: 118
        //		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00016470 File Offset: 0x00014670
        //		[XmlIgnore]
        //		public List<Trigger> Triggers
        //		{
        //			get
        //			{
        //				return this.item.Triggers;
        //			}
        //		}

        //		// Token: 0x17000077 RID: 119
        //		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00016480 File Offset: 0x00014680
        //		[XmlIgnore]
        //		public int Cooldown
        //		{
        //			get
        //			{
        //				return this.item.Cooldown;
        //			}
        //		}

        //		// Token: 0x17000078 RID: 120
        //		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00016490 File Offset: 0x00014690
        //		[XmlIgnore]
        //		public IEnumerable<Trigger> AllTriggers
        //		{
        //			get
        //			{
        //				foreach (Trigger t in this.Triggers)
        //				{
        //					yield return t;
        //				}
        //				foreach (Trigger t2 in this.AdditionTriggers)
        //				{
        //					yield return t2;
        //				}
        //				yield break;
        //			}
        //		}

        //		// Token: 0x060001E4 RID: 484 RVA: 0x000164B4 File Offset: 0x000146B4
        //		public Color GetColor()
        //		{
        //			if (this.AdditionTriggers.Count >= 4)
        //			{
        //				return Color.magenta;
        //			}
        //			if (this.AdditionTriggers.Count == 3)
        //			{
        //				return Color.yellow;
        //			}
        //			if (this.AdditionTriggers.Count == 2)
        //			{
        //				return Color.green;
        //			}
        //			if (this.AdditionTriggers.Count == 1)
        //			{
        //				return Color.blue;
        //			}
        //			if (this.Name.EndsWith("残章"))
        //			{
        //				return Color.blue;
        //			}
        //			if (this.type == 8)
        //			{
        //				return Color.red;
        //			}
        //			if (this.type == 7)
        //			{
        //				return Color.magenta;
        //			}
        //			return Color.white;
        //		}

        //		// Token: 0x060001E5 RID: 485 RVA: 0x00016564 File Offset: 0x00014764
        //		public string GetTypeStr()
        //		{
        //			switch (this.Type)
        //			{
        //			case ItemType.Costa:
        //				return "战场消耗品";
        //			case ItemType.Weapon:
        //				return "装备：武器";
        //			case ItemType.Armor:
        //				return "装备：防具";
        //			case ItemType.Accessories:
        //				return "装备：饰品";
        //			case ItemType.Book:
        //				return "武学经书";
        //			case ItemType.Mission:
        //				return "任务物品";
        //			case ItemType.SpeicalSkillBook:
        //				return "消耗品：特技书";
        //			case ItemType.TalentBook:
        //				return "消耗品：天赋书";
        //			case ItemType.Upgrade:
        //				return "消耗品：永久增强性物品";
        //			case ItemType.Special:
        //				return "特殊物品";
        //			case ItemType.Canzhang:
        //				return "武学残章";
        //			default:
        //				return string.Empty;
        //			}
        //		}

        //		// Token: 0x060001E6 RID: 486 RVA: 0x000165F8 File Offset: 0x000147F8
        //		public string GetLevelStr()
        //		{
        //			if (this.Type != ItemType.Weapon && this.Type != ItemType.Armor && this.Type != ItemType.Accessories)
        //			{
        //				return string.Empty;
        //			}
        //			if (this.AdditionTriggers.Count == 0)
        //			{
        //				return "【普通】";
        //			}
        //			if (this.AdditionTriggers.Count == 1)
        //			{
        //				return "【高级】";
        //			}
        //			if (this.AdditionTriggers.Count == 2)
        //			{
        //				return "【稀有】";
        //			}
        //			if (this.AdditionTriggers.Count == 3)
        //			{
        //				return "【神器】";
        //			}
        //			return "【史诗】";
        //		}

        //		// Token: 0x060001E7 RID: 487 RVA: 0x00016690 File Offset: 0x00014890
        //		public bool HasTalent(string talent)
        //		{
        //			string[] array = talent.Split(new char[]
        //			{
        //				'#'
        //			});
        //			foreach (string text in array)
        //			{
        //				if (text.Equals(talent))
        //				{
        //					return true;
        //				}
        //			}
        //			foreach (Trigger trigger in this.Triggers)
        //			{
        //				if (trigger.Name == "talent" && trigger.Argvs[0] == talent)
        //				{
        //					return true;
        //				}
        //			}
        //			foreach (Trigger trigger2 in this.AdditionTriggers)
        //			{
        //				if (trigger2.Name == "talent" && trigger2.Argvs[0] == talent)
        //				{
        //					return true;
        //				}
        //			}
        //			return false;
        //		}

        //		// Token: 0x060001E8 RID: 488 RVA: 0x000167F0 File Offset: 0x000149F0
        //		public override string ToString()
        //		{
        //			string equipCase = this.EquipCase;
        //			string text = this.Name + "\n" + this.desc + "\n";
        //			if (!equipCase.Equals(string.Empty))
        //			{
        //				text = text + " \n装备条件 " + equipCase;
        //			}
        //			if (this.Triggers.Count > 0)
        //			{
        //				text += "\n";
        //				foreach (Trigger arg in this.Triggers)
        //				{
        //					text = text + arg + " ";
        //				}
        //				text = text.TrimEnd(new char[0]);
        //			}
        //			string[] array = this.talent.Split(new char[]
        //			{
        //				'#'
        //			});
        //			if (array.Length > 0)
        //			{
        //				text += "\n天赋 ";
        //				foreach (string str in array)
        //				{
        //					string[] array3 = ResourceManager.Get<Resource>("天赋." + str).Value.Split(new char[]
        //					{
        //						'#'
        //					});
        //					string str2 = string.Empty;
        //					if (array3.Length == 1)
        //					{
        //						str2 = array3[0];
        //					}
        //					else
        //					{
        //						str2 = array3[1];
        //					}
        //					text = text + str2 + "\n";
        //				}
        //				text = text.TrimEnd(new char[0]);
        //			}
        //			if (this.Cooldown > 0 && RuntimeData.Instance.GameMode != "normal")
        //			{
        //				text = text + "\n冷却回合数 " + this.Cooldown.ToString();
        //			}
        //			return text;
        //		}

        //		// Token: 0x060001E9 RID: 489 RVA: 0x000169C0 File Offset: 0x00014BC0
        //		public void AddRandomTriggers(int number)
        //		{
        //			if (this.Type != ItemType.Weapon && this.Type != ItemType.Armor && this.Type != ItemType.Accessories)
        //			{
        //				return;
        //			}
        //			for (int i = 0; i < number; i++)
        //			{
        //				this.AddRandomTrigger();
        //			}
        //		}

        //		// Token: 0x060001EA RID: 490 RVA: 0x00016A0C File Offset: 0x00014C0C
        //		public void AddRandomTrigger()
        //		{
        //			Trigger trigger = this.GenerateRandomTrigger();
        //			if (trigger == null)
        //			{
        //				return;
        //			}
        //			this.AdditionTriggers.Add(trigger);
        //		}

        //		// Token: 0x060001EB RID: 491 RVA: 0x00016A34 File Offset: 0x00014C34
        //		public Trigger GenerateRandomTrigger()
        //		{
        //			if (this.Type != ItemType.Weapon && this.Type != ItemType.Armor && this.Type != ItemType.Accessories)
        //			{
        //				return null;
        //			}
        //			List<ITTrigger> list = new List<ITTrigger>();
        //			int num = 0;
        //			foreach (ItemTrigger itemTrigger in ResourceManager.GetAll<ItemTrigger>())
        //			{
        //				if ((this.level >= itemTrigger.MinLevel && this.level <= itemTrigger.MaxLevel) || this.Name.Equals(itemTrigger.Name))
        //				{
        //					foreach (ITTrigger ittrigger in itemTrigger.Triggers)
        //					{
        //						num += ittrigger.Weight;
        //						list.Add(ittrigger);
        //					}
        //				}
        //			}
        //			Trigger trigger;
        //			for (;;)
        //			{
        //				trigger = null;
        //				ITTrigger ittrigger2 = null;
        //				foreach (ITTrigger ittrigger3 in list)
        //				{
        //					double p = (double)ittrigger3.Weight / (double)num;
        //					if (Tools.ProbabilityTest(p))
        //					{
        //						trigger = ittrigger3.GenerateItemTrigger(this.level);
        //						ittrigger2 = ittrigger3;
        //						break;
        //					}
        //				}
        //				if (trigger != null)
        //				{
        //					bool flag = true;
        //					foreach (Trigger trigger2 in this.AdditionTriggers)
        //					{
        //						if (trigger.Name == trigger2.Name && !ittrigger2.HasPool)
        //						{
        //							flag = false;
        //							break;
        //						}
        //						if (trigger.Name == trigger2.Name && ittrigger2.HasPool && trigger.Argvs[0] == trigger2.Argvs[0])
        //						{
        //							flag = false;
        //							break;
        //						}
        //					}
        //					if (flag)
        //					{
        //						break;
        //					}
        //				}
        //			}
        //			return trigger;
        //		}

        //		// Token: 0x060001EC RID: 492 RVA: 0x00016CC8 File Offset: 0x00014EC8
        //		public Dictionary<string, int> getItemRequireAttrs()
        //		{
        //			Dictionary<string, int> dictionary = new Dictionary<string, int>();
        //			dictionary.Clear();
        //			foreach (Require require in this.Requires)
        //			{
        //				if (CommonSettings.RoleAttributeList.Contains(require.Name))
        //				{
        //					dictionary.Add(require.Name, int.Parse(require.ArgvsString));
        //				}
        //			}
        //			return dictionary;
        //		}

        //		// Token: 0x060001ED RID: 493 RVA: 0x00016D60 File Offset: 0x00014F60
        //		public List<string> getItemRequireTalents()
        //		{
        //			List<string> list = new List<string>();
        //			foreach (Require require in this.Requires)
        //			{
        //				if (require.Name == "talent")
        //				{
        //					list.Add(require.ArgvsString);
        //				}
        //			}
        //			return list;
        //		}

        //		// Token: 0x060001EE RID: 494 RVA: 0x00016DE8 File Offset: 0x00014FE8
        //		public bool CanEquip(Role r)
        //		{
        //			if (this.Requires == null)
        //			{
        //				return false;
        //			}
        //			Dictionary<string, int> itemRequireAttrs = this.getItemRequireAttrs();
        //			foreach (string key in CommonSettings.RoleAttributeList)
        //			{
        //				if (itemRequireAttrs.ContainsKey(key))
        //				{
        //					if (r.AttributesFinal[key] < itemRequireAttrs[key])
        //					{
        //						return false;
        //					}
        //				}
        //			}
        //			List<string> itemRequireTalents = this.getItemRequireTalents();
        //			foreach (string talent in itemRequireTalents)
        //			{
        //				if (!r.HasTalent(talent))
        //				{
        //					return false;
        //				}
        //			}
        //			return true;
        //		}

        //		// Token: 0x17000079 RID: 121
        //		// (get) Token: 0x060001EF RID: 495 RVA: 0x00016EC4 File Offset: 0x000150C4
        //		public string EquipCase
        //		{
        //			get
        //			{
        //				if (this.Requires == null)
        //				{
        //					return string.Empty;
        //				}
        //				string text = string.Empty;
        //				Dictionary<string, int> itemRequireAttrs = this.getItemRequireAttrs();
        //				foreach (string text2 in itemRequireAttrs.Keys)
        //				{
        //					string arg = CommonSettings.AttributeToChinese(text2);
        //					text += string.Format("{0}>{1} ", arg, itemRequireAttrs[text2]);
        //				}
        //				List<string> itemRequireTalents = this.getItemRequireTalents();
        //				foreach (string str in itemRequireTalents)
        //				{
        //					text += string.Format("具有天赋【" + str + "】 ", new object[0]);
        //				}
        //				return text.TrimEnd(new char[0]);
        //			}
        //		}

        //		// Token: 0x060001F0 RID: 496 RVA: 0x00016FEC File Offset: 0x000151EC
        //		public ItemSkill GetItemSkill()
        //		{
        //			foreach (Trigger trigger in this.Triggers)
        //			{
        //				if (trigger.Name.Equals("skill") || trigger.Name.Equals("internalskill") || trigger.Name.Equals("specialskill") || trigger.Name.Equals("talent"))
        //				{
        //					return new ItemSkill
        //					{
        //						IsInternal = trigger.Name.Equals("internalskill"),
        //						SkillName = trigger.Argvs[0],
        //						MaxLevel = ((trigger.Argvs.Count <= 1) ? 1 : int.Parse(trigger.Argvs[1]))
        //					};
        //				}
        //			}
        //			return null;
        //		}

        //		// Token: 0x060001F1 RID: 497 RVA: 0x00017108 File Offset: 0x00015308
        //		public ItemResult TryUse(Role source, Role target)
        //		{
        //			ItemResult itemResult = new ItemResult();
        //			foreach (Trigger trigger in this.item.Triggers)
        //			{
        //				string name = trigger.Name;
        //				switch (name)
        //				{
        //				case "AddHp":
        //				{
        //					int num2 = int.Parse(trigger.Argvs[0]);
        //					itemResult.Hp += num2;
        //					continue;
        //				}
        //				case "RecoverHp":
        //				{
        //					int num3 = (int)((double)target.maxhp * ((double)int.Parse(trigger.Argvs[0]) / 100.0));
        //					itemResult.Hp += num3;
        //					continue;
        //				}
        //				case "AddMp":
        //				{
        //					int num4 = int.Parse(trigger.Argvs[0]);
        //					itemResult.Mp += num4;
        //					continue;
        //				}
        //				case "RecoverMp":
        //				{
        //					int num5 = (int)((double)target.maxmp * ((double)int.Parse(trigger.Argvs[0]) / 100.0));
        //					itemResult.Mp += num5;
        //					continue;
        //				}
        //				case "解毒":
        //					itemResult.DescPoisonLevel = int.Parse(trigger.Argvs[0]);
        //					itemResult.DescPoisonDuration = int.Parse(trigger.Argvs[1]);
        //					continue;
        //				case "Balls":
        //					itemResult.Balls = int.Parse(trigger.Argvs[0]);
        //					continue;
        //				case "AddMaxHp":
        //					itemResult.MaxHp = int.Parse(trigger.Argvs[0]);
        //					continue;
        //				case "AddMaxMp":
        //					itemResult.MaxMp = int.Parse(trigger.Argvs[0]);
        //					continue;
        //				case "AddBuff":
        //					itemResult.Buffs = Buff.Parse(trigger.Argvs[0]);
        //					continue;
        //				}
        //				Debug.Log("error item trigger " + trigger.Name);
        //			}
        //			return itemResult;
        //		}

        //		// Token: 0x1700007A RID: 122
        //		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000173D4 File Offset: 0x000155D4
        //		[XmlIgnore]
        //		public string DescriptionInRichtext
        //		{
        //			get
        //			{
        //				string text = string.Empty;
        //				text = text + "<color='black'>" + this.desc + "</color>";
        //				string equipCase = this.EquipCase;
        //				if (!equipCase.Equals(string.Empty))
        //				{
        //					text = text + "\n\n<color='red'>装备要求:\n" + equipCase + "</color>";
        //				}
        //				if (this.Triggers.Count > 0)
        //				{
        //					text += "\n\n<color='green'>物品效果:\n";
        //					foreach (Trigger trigger in this.Triggers)
        //					{
        //						text = text + trigger.ToString() + "\n";
        //					}
        //					text += "</color>";
        //				}
        //				if (this.Talents.Length > 0)
        //				{
        //					foreach (string name in this.Talents)
        //					{
        //						text = text + "<color='blue'>" + Resource.GetTalentInfo(name, false) + "</color>\n";
        //					}
        //				}
        //				if (this.AdditionTriggers.Count > 0)
        //				{
        //					text += "\n\n<color='green'>附加效果:\n";
        //					foreach (Trigger trigger2 in this.AdditionTriggers)
        //					{
        //						text = text + trigger2.ToString() + "\n";
        //					}
        //					text += "</color>";
        //				}
        //				if (this.Cooldown > 0 && RuntimeData.Instance.GameMode != "normal")
        //				{
        //					text = text + "\n冷却回合数 " + this.Cooldown.ToString();
        //				}
        //				return text;
        //			}
        //		}

        //		// Token: 0x1700007B RID: 123
        //		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000175D4 File Offset: 0x000157D4
        //		[XmlIgnore]
        //		public string DescriptionInRichtextBlackEnd
        //		{
        //			get
        //			{
        //				return this.DescriptionInRichtext.Replace("black", "white").Replace("blue", "cyan").Replace("green", "yellow");
        //			}
        //		}

        [XmlIgnore]
        public int type
        {
            get
            {
                return this.item.type;
            }
        }

        //		// Token: 0x1700007D RID: 125
        //		// (get) Token: 0x060001F5 RID: 501 RVA: 0x00017624 File Offset: 0x00015824
        //		[XmlIgnore]
        //		public ItemType Type
        //		{
        //			get
        //			{
        //				return (ItemType)this.item.type;
        //			}
        //		}

        [XmlIgnore]
        public Item item
        {
            get
            {
                if (this._item == null)
                {
                    this._item = Item.GetItem(this.Name);
                }
                return this._item;
            }
        }

        //		// Token: 0x060001F7 RID: 503 RVA: 0x00017664 File Offset: 0x00015864
        //		public override bool Equals(object obj)
        //		{
        //			return obj is ItemInstance && this.PK == (obj as ItemInstance).PK;
        //		}

        //		// Token: 0x060001F8 RID: 504 RVA: 0x0001768C File Offset: 0x0001588C
        //		public override int GetHashCode()
        //		{
        //			int num = 0;
        //			foreach (char c in this.PK)
        //			{
        //				num += (int)c;
        //			}
        //			return num;
        //		}

        public static ItemInstance Generate(string name, bool setRandomTriggers = false)
        {
            return Item.GetItem(name).Generate(setRandomTriggers);
        }
    }
}
