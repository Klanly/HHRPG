using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000043 RID: 67
	[XmlType("internal_skill")]
	public class InternalSkill : BasePojo
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00016118 File Offset: 0x00014318
		public override string PK
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00016120 File Offset: 0x00014320
		//public override void InitBind()
		//{
		//	foreach (UniqueSkill uniqueSkill in this.UniqueSkills)
		//	{
		//		ResourceManager.Add<UniqueSkill>(uniqueSkill.PK, uniqueSkill);
		//	}
		//}

		// Token: 0x0400016F RID: 367
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x04000170 RID: 368
		[XmlAttribute("info")]
		public string Info;

		// Token: 0x04000171 RID: 369
		[XmlAttribute("yin")]
		public int Yin;

		// Token: 0x04000172 RID: 370
		[XmlAttribute("yang")]
		public int Yang;

		// Token: 0x04000173 RID: 371
		[XmlAttribute("attack")]
		public float Attack;

		// Token: 0x04000174 RID: 372
		[XmlAttribute("critical")]
		public float Critical;

		// Token: 0x04000175 RID: 373
		[XmlAttribute("defence")]
		public float Defence;

		// Token: 0x04000176 RID: 374
		[XmlAttribute("hard")]
		public float Hard;

		// Token: 0x04000177 RID: 375
		[XmlAttribute]
		public string icon = string.Empty;

		// Token: 0x04000178 RID: 376
		//[XmlElement("trigger")]
		//public List<Trigger> Triggers = new List<Trigger>();

		//// Token: 0x04000179 RID: 377
		//[XmlElement("unique")]
		//public List<UniqueSkill> UniqueSkills = new List<UniqueSkill>();
	}
}
