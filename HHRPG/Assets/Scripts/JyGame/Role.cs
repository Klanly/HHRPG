using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("role")]
    public class Role : BasePojo
    {
        [XmlAttribute("key")]
        public string Key;

        [XmlAttribute("animation")]
        public string Animation;

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("head")]
        public string Head;

        [XmlAttribute]
        public int hp;

        [XmlAttribute]
        public int maxhp;

        [XmlAttribute]
        public int mp;

        [XmlAttribute]
        public int maxmp;

        [XmlAttribute]
        public int wuxing;

        [XmlAttribute]
        public int shenfa;

        [XmlAttribute]
        public int bili;

        [XmlAttribute]
        public int gengu;

        [XmlAttribute]
        public int fuyuan;

        [XmlAttribute]
        public int dingli;

        [XmlAttribute]
        public int quanzhang;

        [XmlAttribute]
        public int jianfa;

        [XmlAttribute]
        public int daofa;

        [XmlAttribute]
        public int qimen;

        [XmlAttribute]
        public string currentSkillName = string.Empty;

        private int _level;

        [XmlAttribute]
        public int exp;

        [XmlAttribute("arena")]
        public string ArenaValue;

        [XmlAttribute("female")]
        public int FemaleValue;

        [XmlIgnore]
        public List<string> Talents = new List<string>();

        [XmlAttribute]
        public int leftpoint;

        [XmlAttribute("grow_template")]
        public string GrowTemplateValue = "default";

        //[XmlArrayItem(typeof(SkillInstance))]
        //[XmlArray("skills")]
        //public List<SkillInstance> Skills = new List<SkillInstance>();

        //[XmlArray("internal_skills")]
        //[XmlArrayItem(typeof(InternalSkillInstance))]
        //public List<InternalSkillInstance> InternalSkills = new List<InternalSkillInstance>();

        //[XmlArray("special_skills")]
        //[XmlArrayItem(typeof(SpecialSkillInstance))]
        //public List<SpecialSkillInstance> SpecialSkills = new List<SpecialSkillInstance>();

        [XmlIgnore]
        public int balls;

        //[XmlArray("items")]
        //[XmlArrayItem(typeof(ItemInstance))]
        //public List<ItemInstance> Equipment = new List<ItemInstance>();

        //[XmlIgnore]
        //public AttributeFinalHelper AttributesFinal;

        [XmlIgnore]
        public AttributeHelper Attributes;

        //[XmlIgnore]
        //public BattleSprite Sprite;

        public Role()
        {
            //this.AttributesFinal = new AttributeFinalHelper(this);
            this.Attributes = new AttributeHelper(this);
        }


        [XmlIgnore]
        public override string PK
        {
            get
            {
                return this.Key;
            }
        }

        //		public override void InitBind()
        //		{
        //			foreach (SkillInstance skillInstance in this.Skills)
        //			{
        //				skillInstance.Owner = this;
        //				skillInstance.RefreshUniquSkills();
        //				foreach (UniqueSkillInstance uniqueSkillInstance in skillInstance.UniqueSkills)
        //				{
        //					uniqueSkillInstance.Owner = this;
        //				}
        //			}
        //			foreach (InternalSkillInstance internalSkillInstance in this.InternalSkills)
        //			{
        //				internalSkillInstance.Owner = this;
        //				internalSkillInstance.RefreshUniquSkills();
        //				foreach (UniqueSkillInstance uniqueSkillInstance2 in internalSkillInstance.UniqueSkills)
        //				{
        //					uniqueSkillInstance2.Owner = this;
        //				}
        //			}
        //			foreach (SpecialSkillInstance specialSkillInstance in this.SpecialSkills)
        //			{
        //				specialSkillInstance.Owner = this;
        //			}
        //			this.hp = this.maxhp;
        //			this.mp = this.maxmp;
        //		}

        //		// Token: 0x0600022C RID: 556 RVA: 0x000189A4 File Offset: 0x00016BA4
        //		public string GetAnimation()
        //		{
        //			using (IEnumerator<Trigger> enumerator = this.GetTriggers("animation").GetEnumerator())
        //			{
        //				if (enumerator.MoveNext())
        //				{
        //					Trigger trigger = enumerator.Current;
        //					return trigger.Argvs[1];
        //				}
        //			}
        //			return this.Animation;
        //		}

        //		// Token: 0x17000090 RID: 144
        //		// (get) Token: 0x0600022D RID: 557 RVA: 0x00018A20 File Offset: 0x00016C20
        //		// (set) Token: 0x0600022E RID: 558 RVA: 0x00018AC8 File Offset: 0x00016CC8
        //		[XmlIgnore]
        //		public SkillBox CurrentSkill
        //		{
        //			get
        //			{
        //				SkillBox skillBox = null;
        //				foreach (SkillBox skillBox2 in this.GetAvaliableSkills())
        //				{
        //					if (skillBox == null)
        //					{
        //						skillBox = skillBox2;
        //					}
        //					if (string.IsNullOrEmpty(this.currentSkillName) && skillBox2.SkillType == SkillType.Normal)
        //					{
        //						return skillBox2;
        //					}
        //					if (skillBox2.Name == this.currentSkillName)
        //					{
        //						return skillBox2;
        //					}
        //				}
        //				return skillBox;
        //			}
        //			set
        //			{
        //				this.currentSkillName = value.Name;
        //			}
        //		}

        //		// Token: 0x17000091 RID: 145
        //		// (get) Token: 0x0600022F RID: 559 RVA: 0x00018AD8 File Offset: 0x00016CD8
        //		[XmlIgnore]
        //		public int wuxue
        //		{
        //			get
        //			{
        //				return 20 + this.Level * this.GrowTemplate.Attributes["wuxue"];
        //			}
        //		}

        //		// Token: 0x17000092 RID: 146
        //		// (get) Token: 0x06000230 RID: 560 RVA: 0x00018B04 File Offset: 0x00016D04
        //		// (set) Token: 0x06000231 RID: 561 RVA: 0x00018B0C File Offset: 0x00016D0C
        //		[XmlAttribute]
        //		public int level
        //		{
        //			get
        //			{
        //				return this._level;
        //			}
        //			set
        //			{
        //				this._level = value;
        //				this.exp = this.PrevLevelupExp;
        //			}
        //		}

        //		// Token: 0x17000093 RID: 147
        //		// (get) Token: 0x06000232 RID: 562 RVA: 0x00018B24 File Offset: 0x00016D24
        //		public int Level
        //		{
        //			get
        //			{
        //				return this.level;
        //			}
        //		}

        //		// Token: 0x17000094 RID: 148
        //		// (get) Token: 0x06000233 RID: 563 RVA: 0x00018B2C File Offset: 0x00016D2C
        //		// (set) Token: 0x06000234 RID: 564 RVA: 0x00018B34 File Offset: 0x00016D34
        //		[XmlIgnore]
        //		public int Exp
        //		{
        //			get
        //			{
        //				return this.exp;
        //			}
        //			set
        //			{
        //				this.exp = value;
        //			}
        //		}

        //		// Token: 0x17000095 RID: 149
        //		// (get) Token: 0x06000235 RID: 565 RVA: 0x00018B40 File Offset: 0x00016D40
        //		public bool Arena
        //		{
        //			get
        //			{
        //				return this.ArenaValue != "no";
        //			}
        //		}

        //		// Token: 0x17000096 RID: 150
        //		// (get) Token: 0x06000236 RID: 566 RVA: 0x00018B54 File Offset: 0x00016D54
        //		public bool Female
        //		{
        //			get
        //			{
        //				return this.FemaleValue == 1;
        //			}
        //		}

        //		// Token: 0x17000097 RID: 151
        //		// (get) Token: 0x06000237 RID: 567 RVA: 0x00018B60 File Offset: 0x00016D60
        //		// (set) Token: 0x06000238 RID: 568 RVA: 0x00018B78 File Offset: 0x00016D78
        //		[XmlAttribute("talent")]
        //		public string TalentValue
        //		{
        //			get
        //			{
        //				return string.Join("#", this.Talents.ToArray());
        //			}
        //			set
        //			{
        //				this.Talents.Clear();
        //				foreach (string text in value.Split(new char[]
        //				{
        //					'#'
        //				}))
        //				{
        //					if (!string.IsNullOrEmpty(text))
        //					{
        //						this.Talents.Add(text);
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x17000098 RID: 152
        //		// (get) Token: 0x06000239 RID: 569 RVA: 0x00018BD4 File Offset: 0x00016DD4
        //		[XmlIgnore]
        //		public RoleGrowTemplate GrowTemplate
        //		{
        //			get
        //			{
        //				RoleGrowTemplate roleGrowTemplate = ResourceManager.Get<RoleGrowTemplate>(this.GrowTemplateValue);
        //				if (roleGrowTemplate == null)
        //				{
        //					roleGrowTemplate = ResourceManager.Get<RoleGrowTemplate>("default");
        //				}
        //				return roleGrowTemplate;
        //			}
        //		}

        //		// Token: 0x0600023A RID: 570 RVA: 0x00018C00 File Offset: 0x00016E00
        //		public ItemInstance GetEquipment(ItemType type)
        //		{
        //			return this.GetEquipment((int)type);
        //		}

        //		// Token: 0x0600023B RID: 571 RVA: 0x00018C0C File Offset: 0x00016E0C
        //		public ItemInstance GetEquipment(int type)
        //		{
        //			if (this.Equipment == null)
        //			{
        //				return null;
        //			}
        //			foreach (ItemInstance itemInstance in this.Equipment)
        //			{
        //				if (itemInstance.type == type)
        //				{
        //					return itemInstance;
        //				}
        //			}
        //			return null;
        //		}

        public Role Clone()
        {
            return BasePojo.Create<Role>(this.Xml);
        }

        public void Reset(bool recover = true)
        {
            if (recover)
            {
                this.hp = this.Attributes["maxhp"];
                this.mp = this.Attributes["maxmp"];
            }
            else
            {
                if (this.Attributes["hp"] <= 0)
                {
                    this.hp = 1;
                }
                if (this.Attributes["mp"] <= 0)
                {
                    this.mp = 0;
                }
            }
            this.balls = 0;
            this.SkillCdRecover();
        }

        /// <summary>
        /// 技能CD恢复
        /// </summary>
        public void SkillCdRecover()
        {
            //foreach (SkillInstance skillInstance in this.Skills)
            //{
            //    skillInstance.CurrentCd = 0;
            //    foreach (UniqueSkillInstance uniqueSkillInstance in skillInstance.UniqueSkills)
            //    {
            //        uniqueSkillInstance.CurrentCd = 0;
            //    }
            //}
            //foreach (InternalSkillInstance internalSkillInstance in this.InternalSkills)
            //{
            //    foreach (UniqueSkillInstance uniqueSkillInstance2 in internalSkillInstance.UniqueSkills)
            //    {
            //        uniqueSkillInstance2.CurrentCd = 0;
            //    }
            //}
            //foreach (SpecialSkillInstance specialSkillInstance in this.SpecialSkills)
            //{
            //    specialSkillInstance.CurrentCd = 0;
            //}
        }

        //		// Token: 0x17000099 RID: 153
        //		// (get) Token: 0x0600023F RID: 575 RVA: 0x00018EEC File Offset: 0x000170EC
        //		[XmlIgnore]
        //		public int LevelupExp
        //		{
        //			get
        //			{
        //				return CommonSettings.LevelupExp(this.Level);
        //			}
        //		}

        //		// Token: 0x1700009A RID: 154
        //		// (get) Token: 0x06000240 RID: 576 RVA: 0x00018EFC File Offset: 0x000170FC
        //		[XmlIgnore]
        //		public int PrevLevelupExp
        //		{
        //			get
        //			{
        //				return CommonSettings.LevelupExp(this.Level - 1);
        //			}
        //		}

        //		// Token: 0x06000241 RID: 577 RVA: 0x00018F0C File Offset: 0x0001710C
        //		public void AddTalent(string talent)
        //		{
        //			this.Talents.Add(talent);
        //		}

        //		// Token: 0x06000242 RID: 578 RVA: 0x00018F1C File Offset: 0x0001711C
        //		public bool RemoveTalent(string talent)
        //		{
        //			if (this.Talents.Contains(talent))
        //			{
        //				this.Talents.Remove(talent);
        //				return true;
        //			}
        //			return false;
        //		}

        //		// Token: 0x06000243 RID: 579 RVA: 0x00018F40 File Offset: 0x00017140
        //		public bool HasTalent(string talent)
        //		{
        //			if (this.Talents.Contains(talent))
        //			{
        //				return true;
        //			}
        //			if (this.EquipmentTalents.Contains(talent))
        //			{
        //				return true;
        //			}
        //			InternalSkillInstance equippedInternalSkill = this.GetEquippedInternalSkill();
        //			return equippedInternalSkill != null && equippedInternalSkill.HasTalent(talent);
        //		}

        //		// Token: 0x1700009B RID: 155
        //		// (get) Token: 0x06000244 RID: 580 RVA: 0x00018F90 File Offset: 0x00017190
        //		[XmlIgnore]
        //		public IEnumerable<string> EquipmentTalents
        //		{
        //			get
        //			{
        //				List<string> visitedTalent = new List<string>();
        //				foreach (Trigger t in this.GetTriggers("talent"))
        //				{
        //					string talentName = t.Argvs[0];
        //					if (t.Name == "talent" && !visitedTalent.Contains(talentName))
        //					{
        //						yield return talentName;
        //						visitedTalent.Add(talentName);
        //					}
        //				}
        //				foreach (ItemInstance t2 in this.Equipment)
        //				{
        //					if (t2 != null)
        //					{
        //						foreach (string talentName2 in t2.Talents)
        //						{
        //							if (!visitedTalent.Contains(talentName2))
        //							{
        //								yield return talentName2;
        //								visitedTalent.Add(talentName2);
        //							}
        //						}
        //					}
        //				}
        //				yield break;
        //			}
        //		}

        //		// Token: 0x06000245 RID: 581 RVA: 0x00018FB4 File Offset: 0x000171B4
        //		public InternalSkillInstance GetEquippedInternalSkill()
        //		{
        //			foreach (InternalSkillInstance internalSkillInstance in this.InternalSkills)
        //			{
        //				if (internalSkillInstance.IsUsed)
        //				{
        //					return internalSkillInstance;
        //				}
        //			}
        //			return null;
        //		}

        //		// Token: 0x06000246 RID: 582 RVA: 0x00019028 File Offset: 0x00017228
        //		public void SetEquippedInternalSkill(InternalSkillInstance skill)
        //		{
        //			foreach (InternalSkillInstance internalSkillInstance in this.InternalSkills)
        //			{
        //				internalSkillInstance.equipped = 0;
        //			}
        //			skill.equipped = 1;
        //		}

        //		// Token: 0x06000247 RID: 583 RVA: 0x00019098 File Offset: 0x00017298
        //		public IEnumerable<SkillBox> GetAvaliableSkills()
        //		{
        //			foreach (SpecialSkillInstance ss in this.SpecialSkills)
        //			{
        //				if (ss.IsUsed)
        //				{
        //					yield return ss;
        //				}
        //			}
        //			foreach (SkillInstance ss2 in this.Skills)
        //			{
        //				if (ss2.IsUsed)
        //				{
        //					yield return ss2;
        //					foreach (UniqueSkillInstance us in ss2.UniqueSkills)
        //					{
        //						if (ss2.level >= us.UniqueSkill.RequireLevel)
        //						{
        //							yield return us;
        //						}
        //					}
        //				}
        //			}
        //			InternalSkillInstance EquippedInternalSkill = this.GetEquippedInternalSkill();
        //			if (EquippedInternalSkill != null)
        //			{
        //				foreach (UniqueSkillInstance us2 in EquippedInternalSkill.UniqueSkills)
        //				{
        //					if (EquippedInternalSkill.level >= us2.UniqueSkill.RequireLevel)
        //					{
        //						yield return us2;
        //					}
        //				}
        //			}
        //			yield break;
        //		}

        //		// Token: 0x1700009C RID: 156
        //		// (get) Token: 0x06000248 RID: 584 RVA: 0x000190BC File Offset: 0x000172BC
        //		[XmlIgnore]
        //		public bool Animal
        //		{
        //			get
        //			{
        //				return this.Attributes["female"] == -1;
        //			}
        //		}

        //		// Token: 0x06000249 RID: 585 RVA: 0x000190D4 File Offset: 0x000172D4
        //		public IEnumerable<Trigger> GetTriggers(string name)
        //		{
        //			foreach (ItemInstance item in this.Equipment)
        //			{
        //				foreach (Trigger t in item.AllTriggers)
        //				{
        //					if (t.Name == name)
        //					{
        //						yield return t;
        //					}
        //				}
        //			}
        //			foreach (SkillInstance s in this.Skills)
        //			{
        //				foreach (Trigger t2 in s.Skill.Triggers)
        //				{
        //					if (s.level >= t2.Level && t2.Name == name)
        //					{
        //						yield return t2;
        //					}
        //				}
        //			}
        //			foreach (InternalSkillInstance s2 in this.InternalSkills)
        //			{
        //				foreach (Trigger t3 in s2.InternalSkill.Triggers)
        //				{
        //					if (s2.level >= t3.Level && t3.Name == name)
        //					{
        //						yield return t3;
        //					}
        //				}
        //			}
        //			yield break;
        //		}

        //		// Token: 0x0600024A RID: 586 RVA: 0x00019108 File Offset: 0x00017308
        //		public IEnumerable<Trigger> GetAllTriggers()
        //		{
        //			foreach (ItemInstance item in this.Equipment)
        //			{
        //				foreach (Trigger t in item.AllTriggers)
        //				{
        //					yield return t;
        //				}
        //			}
        //			foreach (SkillInstance s in this.Skills)
        //			{
        //				foreach (Trigger t2 in s.Skill.Triggers)
        //				{
        //					if (s.level >= t2.Level)
        //					{
        //						yield return t2;
        //					}
        //				}
        //			}
        //			foreach (InternalSkillInstance s2 in this.InternalSkills)
        //			{
        //				foreach (Trigger t3 in s2.InternalSkill.Triggers)
        //				{
        //					if (s2.level >= t3.Level)
        //					{
        //						yield return t3;
        //					}
        //				}
        //			}
        //			yield break;
        //		}

        //		// Token: 0x0600024B RID: 587 RVA: 0x0001912C File Offset: 0x0001732C
        //		public int GetAdditionAttribute(string attribute)
        //		{
        //			string b = CommonSettings.AttributeToChinese(attribute);
        //			int num = 0;
        //			foreach (Trigger trigger in this.GetTriggers("attribute"))
        //			{
        //				if (trigger.Argvs[0] == b)
        //				{
        //					num += int.Parse(trigger.Argvs[1]);
        //				}
        //			}
        //			if (this.HasTalent("武学奇才"))
        //			{
        //				num *= 2;
        //			}
        //			return num;
        //		}

        //		// Token: 0x0600024C RID: 588 RVA: 0x000191D8 File Offset: 0x000173D8
        //		public int GetSkillTypeValue()
        //		{
        //			return this.AttributesFinal["quanzhang"] + this.AttributesFinal["jianfa"] + this.AttributesFinal["daofa"] + this.AttributesFinal["qimen"];
        //		}

        //		// Token: 0x0600024D RID: 589 RVA: 0x00019228 File Offset: 0x00017428
        //		public int GetMaxSkillTypeValue()
        //		{
        //			int[] source = new int[]
        //			{
        //				this.AttributesFinal["quanzhang"],
        //				this.AttributesFinal["jianfa"],
        //				this.AttributesFinal["daofa"],
        //				this.AttributesFinal["qimen"]
        //			};
        //			return source.Max();
        //		}

        //		// Token: 0x0600024E RID: 590 RVA: 0x00019290 File Offset: 0x00017490
        //		public string GetAttributeString(string attr)
        //		{
        //			return string.Format("{0}(+{1})", this.Attributes[attr], this.GetAdditionAttribute(attr));
        //		}

        //		// Token: 0x1700009D RID: 157
        //		// (get) Token: 0x0600024F RID: 591 RVA: 0x000192BC File Offset: 0x000174BC
        //		[XmlIgnore]
        //		public double Defence
        //		{
        //			get
        //			{
        //				double num = 150.0 + (10.0 + (double)this.AttributesFinal["dingli"] / 40.0 + (double)this.AttributesFinal["gengu"] / 70.0) * 8.0 * (double)(1f + this.GetEquippedInternalSkill().Defence);
        //				foreach (Trigger trigger in this.GetTriggers("defence"))
        //				{
        //					num += double.Parse(trigger.Argvs[0]);
        //				}
        //				double num2 = AttackLogic.defenceDescAttack(num);
        //				return (double)this.maxhp / (1.0 - num2) / 30.0;
        //			}
        //		}

        //		// Token: 0x1700009E RID: 158
        //		// (get) Token: 0x06000250 RID: 592 RVA: 0x000193C4 File Offset: 0x000175C4
        //		[XmlIgnore]
        //		public double Attack
        //		{
        //			get
        //			{
        //				double num = 1.0;
        //				num *= 4.0 + (double)this.AttributesFinal["bili"] / 120.0;
        //				num *= 2.0 + (double)this.GetMaxSkillTypeValue() / 200.0;
        //				num *= (double)(1f + this.GetEquippedInternalSkill().Attack);
        //				foreach (Trigger trigger in this.GetTriggers("attack"))
        //				{
        //					num += double.Parse(trigger.Argvs[0]) / 35.0;
        //				}
        //				double num2 = (double)this.AttributesFinal["fuyuan"] / 50.0 / 20.0 * (double)(1f + this.GetEquippedInternalSkill().Critical) + (double)this.CriticalProbabilityAdd();
        //				if (num2 > 1.0)
        //				{
        //					num2 = 1.0;
        //				}
        //				int num3 = 0;
        //				foreach (Trigger trigger2 in this.GetTriggers("critical"))
        //				{
        //					num3 += int.Parse(trigger2.Argvs[0]);
        //				}
        //				num *= 1.0 + num2 * (1.5 + (double)num3 / 100.0);
        //				double num4 = 0.0;
        //				foreach (SkillInstance skillInstance in this.Skills)
        //				{
        //					if ((double)skillInstance.Power > num4)
        //					{
        //						num4 = (double)skillInstance.Power;
        //					}
        //				}
        //				if (num4 == 0.0)
        //				{
        //					foreach (UniqueSkillInstance uniqueSkillInstance in this.GetEquippedInternalSkill().UniqueSkills)
        //					{
        //						if ((double)uniqueSkillInstance.Power > num4)
        //						{
        //							num4 = (double)uniqueSkillInstance.Power;
        //						}
        //					}
        //				}
        //				return num * num4;
        //			}
        //		}

        //		// Token: 0x06000251 RID: 593 RVA: 0x00019690 File Offset: 0x00017890
        //		public float CriticalProbabilityAdd()
        //		{
        //			float num = 0f;
        //			foreach (Trigger trigger in this.GetTriggers("criticalp"))
        //			{
        //				num += (float)((double)float.Parse(trigger.Argvs[0]) / 100.0);
        //			}
        //			foreach (Trigger trigger2 in this.GetTriggers("attack"))
        //			{
        //				num += (float)((double)int.Parse(trigger2.Argvs[1]) / 100.0);
        //			}
        //			return num;
        //		}

        //		// Token: 0x06000252 RID: 594 RVA: 0x00019790 File Offset: 0x00017990
        //		public bool AddExp(int add)
        //		{
        //			this.Exp += add;
        //			ItemInstance equipment = this.GetEquipment(4);
        //			if (equipment != null)
        //			{
        //				ItemSkill itemSkill = equipment.GetItemSkill();
        //				if (itemSkill.IsInternal)
        //				{
        //					bool flag = false;
        //					foreach (InternalSkillInstance internalSkillInstance in this.InternalSkills)
        //					{
        //						if (internalSkillInstance.Name.Equals(itemSkill.SkillName))
        //						{
        //							flag = true;
        //						}
        //						if (internalSkillInstance.Name.Equals(itemSkill.SkillName) && itemSkill.MaxLevel >= internalSkillInstance.Level)
        //						{
        //							internalSkillInstance.TryAddExp(add);
        //							flag = true;
        //						}
        //					}
        //					if (!flag && this.InternalSkills.Count < 5)
        //					{
        //						InternalSkillInstance internalSkillInstance2 = new InternalSkillInstance
        //						{
        //							name = itemSkill.SkillName,
        //							level = 1,
        //							Owner = this
        //						};
        //						internalSkillInstance2.RefreshUniquSkills();
        //						this.InternalSkills.Add(internalSkillInstance2);
        //						internalSkillInstance2.TryAddExp(add);
        //					}
        //				}
        //				else
        //				{
        //					bool flag2 = false;
        //					foreach (SkillInstance skillInstance in this.Skills)
        //					{
        //						if (skillInstance.Name.Equals(itemSkill.SkillName))
        //						{
        //							flag2 = true;
        //						}
        //						if (skillInstance.Skill.Name.Equals(itemSkill.SkillName) && itemSkill.MaxLevel >= skillInstance.Level)
        //						{
        //							skillInstance.TryAddExp(add);
        //							flag2 = true;
        //						}
        //					}
        //					if (!flag2 && this.Skills.Count < 10)
        //					{
        //						SkillInstance skillInstance2 = new SkillInstance
        //						{
        //							name = itemSkill.SkillName,
        //							level = 1,
        //							Owner = this
        //						};
        //						skillInstance2.RefreshUniquSkills();
        //						this.Skills.Add(skillInstance2);
        //						skillInstance2.TryAddExp(add);
        //					}
        //				}
        //			}
        //			bool result = false;
        //			if (this.Level >= 30)
        //			{
        //				this.Exp = 0;
        //			}
        //			while (this.Exp > this.LevelupExp && this.Level < 30)
        //			{
        //				this.level++;
        //				this.leftpoint += 2;
        //				this.maxhp += this.GrowTemplate.Attributes["hp"];
        //				if (this.maxhp > CommonSettings.MAX_HPMP)
        //				{
        //					this.maxhp = CommonSettings.MAX_HPMP;
        //				}
        //				this.maxmp += this.GrowTemplate.Attributes["mp"];
        //				if (this.maxmp > CommonSettings.MAX_HPMP)
        //				{
        //					this.maxmp = CommonSettings.MAX_HPMP;
        //				}
        //				if (this.Attributes["bili"] < 200)
        //				{
        //					this.bili += this.GrowTemplate.Attributes["bili"];
        //				}
        //				if (this.Attributes["fuyuan"] < 200)
        //				{
        //					this.fuyuan += this.GrowTemplate.Attributes["fuyuan"];
        //				}
        //				if (this.Attributes["gengu"] < 200)
        //				{
        //					this.gengu += this.GrowTemplate.Attributes["gengu"];
        //				}
        //				if (this.Attributes["dingli"] < 200)
        //				{
        //					this.dingli += this.GrowTemplate.Attributes["dingli"];
        //				}
        //				if (this.Attributes["shenfa"] < 200)
        //				{
        //					this.shenfa += this.GrowTemplate.Attributes["shenfa"];
        //				}
        //				if (this.Attributes["wuxing"] < 200)
        //				{
        //					this.wuxing += this.GrowTemplate.Attributes["wuxing"];
        //				}
        //				if (this.Attributes["quanzhang"] < 200)
        //				{
        //					this.quanzhang += this.GrowTemplate.Attributes["quanzhang"];
        //				}
        //				if (this.Attributes["jianfa"] < 200)
        //				{
        //					this.jianfa += this.GrowTemplate.Attributes["jianfa"];
        //				}
        //				if (this.Attributes["daofa"] < 200)
        //				{
        //					this.daofa += this.GrowTemplate.Attributes["daofa"];
        //				}
        //				if (this.Attributes["qimen"] < 200)
        //				{
        //					this.qimen += this.GrowTemplate.Attributes["qimen"];
        //				}
        //				if (this.bili > 300)
        //				{
        //					this.bili = 300;
        //				}
        //				if (this.fuyuan > 300)
        //				{
        //					this.fuyuan = 300;
        //				}
        //				if (this.gengu > 300)
        //				{
        //					this.gengu = 300;
        //				}
        //				if (this.dingli > 300)
        //				{
        //					this.dingli = 300;
        //				}
        //				if (this.shenfa > 300)
        //				{
        //					this.shenfa = 300;
        //				}
        //				if (this.wuxing > 300)
        //				{
        //					this.wuxing = 300;
        //				}
        //				if (this.quanzhang > 300)
        //				{
        //					this.quanzhang = 300;
        //				}
        //				if (this.jianfa > 300)
        //				{
        //					this.jianfa = 300;
        //				}
        //				if (this.daofa > 300)
        //				{
        //					this.daofa = 300;
        //				}
        //				if (this.qimen > 300)
        //				{
        //					this.qimen = 300;
        //				}
        //				result = true;
        //			}
        //			return result;
        //		}

        //		// Token: 0x06000253 RID: 595 RVA: 0x00019E0C File Offset: 0x0001800C
        //		public bool CanLearnTalent(string t, ref int need)
        //		{
        //			int talentCost = Resource.GetTalentCost(t);
        //			int num = this.Attributes["wuxue"];
        //			int totalWuxueCost = this.GetTotalWuxueCost();
        //			need = talentCost;
        //			return talentCost + totalWuxueCost <= num;
        //		}

        //		// Token: 0x06000254 RID: 596 RVA: 0x00019E44 File Offset: 0x00018044
        //		public int GetTotalWuxueCost()
        //		{
        //			int num = 0;
        //			foreach (string talent in this.Talents)
        //			{
        //				num += Resource.GetTalentCost(talent);
        //			}
        //			return num;
        //		}

        //		// Token: 0x06000255 RID: 597 RVA: 0x00019EB0 File Offset: 0x000180B0
        //		public void addRoundSkillLevel()
        //		{
        //			int round = RuntimeData.Instance.Round;
        //			int num = round / 2;
        //			if (num > 0)
        //			{
        //				foreach (SkillInstance skillInstance in this.Skills)
        //				{
        //					skillInstance.level += num;
        //					if (skillInstance.Level > 20)
        //					{
        //						skillInstance.level = 20;
        //					}
        //				}
        //				foreach (InternalSkillInstance internalSkillInstance in this.InternalSkills)
        //				{
        //					internalSkillInstance.level += num;
        //					if (internalSkillInstance.Level > 20)
        //					{
        //						internalSkillInstance.level = 20;
        //					}
        //				}
        //			}
        //		}

        //		// Token: 0x06000256 RID: 598 RVA: 0x00019FC0 File Offset: 0x000181C0
        //		public void addRandomTalentAndWeapons()
        //		{
        //			this.addRandomTalent();
        //		}

        //		// Token: 0x06000257 RID: 599 RVA: 0x00019FC8 File Offset: 0x000181C8
        //		private void addRandomTalent()
        //		{
        //			string text = string.Empty;
        //			int num = 0;
        //			if (RuntimeData.Instance.GameMode == "hard")
        //			{
        //				num = 1;
        //			}
        //			if (RuntimeData.Instance.GameMode == "crazy")
        //			{
        //				num = 3;
        //			}
        //			if (RuntimeData.Instance.GameMode == "crazy")
        //			{
        //				string enemyRandomTalentListCrazyAttack = CommonSettings.GetEnemyRandomTalentListCrazyAttack();
        //				string enemyRandomTalentListCrazyDefence = CommonSettings.GetEnemyRandomTalentListCrazyDefence();
        //				string enemyRandomTalentListCrazyOther = CommonSettings.GetEnemyRandomTalentListCrazyOther();
        //				this.Talents.Add(enemyRandomTalentListCrazyAttack);
        //				this.Talents.Add(enemyRandomTalentListCrazyDefence);
        //				this.Talents.Add(enemyRandomTalentListCrazyOther);
        //			}
        //			else
        //			{
        //				for (int i = 0; i < num; i++)
        //				{
        //					do
        //					{
        //						text = CommonSettings.GetEnemyRandomTalent(this.Female);
        //					}
        //					while (this.HasTalent(text));
        //					this.Talents.Add(text);
        //				}
        //			}
        //		}
    }
}
