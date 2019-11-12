using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("skill")]
    public class Skill : BasePojo
    {
        public override string PK
        {
            get
            {
                return this.Name;
            }
        }

        //		// Token: 0x170000A6 RID: 166
        //		// (get) Token: 0x0600026D RID: 621 RVA: 0x0001A9E8 File Offset: 0x00018BE8
        //		public bool Tiaohe
        //		{
        //			get
        //			{
        //				return this.TiaoheValue == 1;
        //			}
        //		}

        //		// Token: 0x170000A7 RID: 167
        //		// (get) Token: 0x0600026F RID: 623 RVA: 0x0001AA00 File Offset: 0x00018C00
        //		// (set) Token: 0x0600026E RID: 622 RVA: 0x0001A9F4 File Offset: 0x00018BF4
        //		[XmlAttribute("covertype")]
        //		public int CoverType
        //		{
        //			get
        //			{
        //				return (this._coverType != -1) ? this._coverType : ((int)CommonSettings.GetDefaultCoverType(this.Type));
        //			}
        //			set
        //			{
        //				this._coverType = value;
        //			}
        //		}

        //		// Token: 0x170000A8 RID: 168
        //		// (get) Token: 0x06000270 RID: 624 RVA: 0x0001AA30 File Offset: 0x00018C30
        //		[XmlIgnore]
        //		public IEnumerable<Buff> Buffs
        //		{
        //			get
        //			{
        //				return Buff.Parse(this.buff);
        //			}
        //		}

        //		// Token: 0x06000271 RID: 625 RVA: 0x0001AA40 File Offset: 0x00018C40
        //		//private SkillLevelInfo GetSkillLevelInfo(int level)
        //		//{
        //		//	foreach (SkillLevelInfo skillLevelInfo in this.Levels)
        //		//	{
        //		//		if (skillLevelInfo.Level == level)
        //		//		{
        //		//			return skillLevelInfo;
        //		//		}
        //		//	}
        //		//	return null;
        //		//}

        //		// Token: 0x06000272 RID: 626 RVA: 0x0001AAB8 File Offset: 0x00018CB8
        //		public float GetPower(int level)
        //		{
        //			SkillLevelInfo skillLevelInfo = this.GetSkillLevelInfo(level);
        //			if (skillLevelInfo != null)
        //			{
        //				return skillLevelInfo.Power;
        //			}
        //			return this.BasePower + (float)(level - 1) * this.Step;
        //		}

        //		// Token: 0x06000273 RID: 627 RVA: 0x0001AAEC File Offset: 0x00018CEC
        //		public int GetCoverSize(int level)
        //		{
        //			SkillLevelInfo skillLevelInfo = this.GetSkillLevelInfo(level);
        //			if (skillLevelInfo != null)
        //			{
        //				return skillLevelInfo.CoverSize;
        //			}
        //			float dSize = new SkillCoverTypeHelper((SkillCoverType)this.CoverType).dSize;
        //			return (level > 10) ? ((int)(1f + dSize * 10f)) : ((int)(1f + dSize * (float)level));
        //		}

        //		// Token: 0x06000274 RID: 628 RVA: 0x0001AB48 File Offset: 0x00018D48
        //		public SkillCoverType GetCoverType(int level)
        //		{
        //			SkillLevelInfo skillLevelInfo = this.GetSkillLevelInfo(level);
        //			if (skillLevelInfo != null)
        //			{
        //				return (SkillCoverType)skillLevelInfo.CoverType;
        //			}
        //			return (SkillCoverType)this.CoverType;
        //		}

        //		// Token: 0x06000275 RID: 629 RVA: 0x0001AB70 File Offset: 0x00018D70
        //		public int GetCastSize(int level)
        //		{
        //			SkillCoverTypeHelper skillCoverTypeHelper = new SkillCoverTypeHelper(this.GetCoverType(level));
        //			int baseCastSize = skillCoverTypeHelper.baseCastSize;
        //			float dCastSize = skillCoverTypeHelper.dCastSize;
        //			return (level > 10) ? ((int)((float)baseCastSize + dCastSize * 10f)) : ((int)((float)baseCastSize + dCastSize * (float)level));
        //		}

        //		// Token: 0x06000276 RID: 630 RVA: 0x0001ABB8 File Offset: 0x00018DB8
        //		public string GetAnimationName(int level)
        //		{
        //			SkillLevelInfo skillLevelInfo = this.GetSkillLevelInfo(level);
        //			if (skillLevelInfo != null)
        //			{
        //				return skillLevelInfo.Animation;
        //			}
        //			return this.Animation;
        //		}

        //		// Token: 0x06000277 RID: 631 RVA: 0x0001ABE0 File Offset: 0x00018DE0
        //		public int GetCooldown(int level)
        //		{
        //			SkillLevelInfo skillLevelInfo = this.GetSkillLevelInfo(level);
        //			if (skillLevelInfo != null)
        //			{
        //				return skillLevelInfo.Cd;
        //			}
        //			return this.Cd;
        //		}

        //		// Token: 0x06000278 RID: 632 RVA: 0x0001AC08 File Offset: 0x00018E08
        //		public int GetLevelupExp(int currentLevel)
        //		{
        //			return (int)((float)currentLevel / 4f * (this.Hard + 1f) / 4f * 15f * 8f);
        //		}

        //		// Token: 0x170000A9 RID: 169
        //		// (get) Token: 0x06000279 RID: 633 RVA: 0x0001AC40 File Offset: 0x00018E40
        //		public string SuitInfo
        //		{
        //			get
        //			{
        //				if (this.Tiaohe)
        //				{
        //					return "阴阳调和";
        //				}
        //				if (this.Suit == 0f)
        //				{
        //					return "无适性";
        //				}
        //				if (this.Suit > 0f)
        //				{
        //					return string.Format("阳{0}%", this.Suit * 100f);
        //				}
        //				if (this.Suit < 0f)
        //				{
        //					return string.Format("阴{0}%", -this.Suit * 100f);
        //				}
        //				return "错误适性";
        //			}
        //		}

        //		// Token: 0x0600027A RID: 634 RVA: 0x0001ACD4 File Offset: 0x00018ED4
        //		public override void InitBind()
        //		{
        //			foreach (UniqueSkill uniqueSkill in this.UniqueSkills)
        //			{
        //				ResourceManager.Add<UniqueSkill>(uniqueSkill.PK, uniqueSkill);
        //			}
        //		}

        // Token: 0x04000219 RID: 537
        [XmlAttribute("name")]
        public string Name;

        // Token: 0x0400021A RID: 538
        [XmlAttribute("tiaohe")]
        public int TiaoheValue = -1;

        // Token: 0x0400021B RID: 539
        [XmlAttribute("type")]
        public int Type;

        // Token: 0x0400021C RID: 540
        private int _coverType = -1;

        // Token: 0x0400021D RID: 541
        [XmlAttribute("suit")]
        public float Suit;

        // Token: 0x0400021E RID: 542
        [XmlAttribute("hard")]
        public float Hard;

        // Token: 0x0400021F RID: 543
        [XmlAttribute("info")]
        public string Info;

        // Token: 0x04000220 RID: 544
        [XmlAttribute("audio")]
        public string Audio;

        // Token: 0x04000221 RID: 545
        [XmlAttribute("basepower")]
        public float BasePower;

        // Token: 0x04000222 RID: 546
        [XmlAttribute("step")]
        public float Step;

        // Token: 0x04000223 RID: 547
        [XmlAttribute("animation")]
        public string Animation;

        // Token: 0x04000224 RID: 548
        [XmlAttribute("cd")]
        public int Cd;

        // Token: 0x04000225 RID: 549
        [XmlAttribute]
        public string icon = string.Empty;

        // Token: 0x04000226 RID: 550
        [XmlAttribute("buff")]
        public string buff;

        // Token: 0x04000227 RID: 551
        //[XmlElement("level")]
        //public List<SkillLevelInfo> Levels = new List<SkillLevelInfo>();

        //// Token: 0x04000228 RID: 552
        //[XmlElement("trigger")]
        //public List<Trigger> Triggers = new List<Trigger>();

        //// Token: 0x04000229 RID: 553
        //[XmlElement("unique")]
        //public List<UniqueSkill> UniqueSkills = new List<UniqueSkill>();
    }
}
