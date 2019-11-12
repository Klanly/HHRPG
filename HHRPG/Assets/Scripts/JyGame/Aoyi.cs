using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000032 RID: 50
	[XmlType("aoyi")]
	public class Aoyi : BasePojo
	{
		// Token: 0x0600018B RID: 395 RVA: 0x00014DEC File Offset: 0x00012FEC
		public Aoyi()
		{
			this._pk = Guid.NewGuid().ToString();
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00014E20 File Offset: 0x00013020
		public override string PK
		{
			get
			{
				return this._pk;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00014E28 File Offset: 0x00013028
		[XmlIgnore]
		public IEnumerable<Buff> Buffs
		{
			get
			{
				return Buff.Parse(this.buff);
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00014E38 File Offset: 0x00013038
		public float GetStartSkillHard()
		{
			Skill skill = ResourceManager.Get<Skill>(this.start);
			if (skill != null)
			{
				return skill.Hard;
			}
			//UniqueSkill uniqueSkill = ResourceManager.Get<UniqueSkill>(this.start);
			//if (uniqueSkill != null)
			//{
			//	return uniqueSkill.Hard;
			//}
			return 100f;
		}

		// Token: 0x04000106 RID: 262
		private string _pk;

		// Token: 0x04000107 RID: 263
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x04000108 RID: 264
		[XmlAttribute]
		public string start;

		// Token: 0x04000109 RID: 265
		[XmlAttribute]
		public int level;

		// Token: 0x0400010A RID: 266
		[XmlAttribute]
		public float probability;

		// Token: 0x0400010B RID: 267
		[XmlAttribute]
		public string buff;

		// Token: 0x0400010C RID: 268
		[XmlAttribute]
		public string animation;

		// Token: 0x0400010D RID: 269
		[XmlAttribute]
		public float addPower;

		// Token: 0x0400010E RID: 270
		[XmlElement("condition")]
		public List<AoyiCondition> Conditions = new List<AoyiCondition>();
	}
}
