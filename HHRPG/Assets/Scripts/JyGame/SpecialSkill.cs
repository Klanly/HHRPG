using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000063 RID: 99
	[XmlType("special_skill")]
	public class SpecialSkill : BasePojo
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0001C424 File Offset: 0x0001A624
		public override string PK
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060002FA RID: 762 RVA: 0x0001C42C File Offset: 0x0001A62C
		public bool HitSelf
		{
			get
			{
				return this.HitSelfValue == 1;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0001C438 File Offset: 0x0001A638
		[XmlIgnore]
		public IEnumerable<Buff> Buffs
		{
			get
			{
				return Buff.Parse(this.BuffValue);
			}
		}

		// Token: 0x0400024B RID: 587
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x0400024C RID: 588
		[XmlAttribute("info")]
		public string Info;

		// Token: 0x0400024D RID: 589
		[XmlAttribute("castsize")]
		public int CastSize;

		// Token: 0x0400024E RID: 590
		[XmlAttribute("coversize")]
		public int CoverSize;

		// Token: 0x0400024F RID: 591
		[XmlAttribute("audio")]
		public string Audio;

		// Token: 0x04000250 RID: 592
		[XmlAttribute("covertype")]
		public int CoverType;

		// Token: 0x04000251 RID: 593
		[XmlAttribute("animation")]
		public string Animation;

		// Token: 0x04000252 RID: 594
		[XmlAttribute("costMp")]
		public int CostMp;

		// Token: 0x04000253 RID: 595
		[XmlAttribute("cd")]
		public int Cd;

		// Token: 0x04000254 RID: 596
		[XmlAttribute("costball")]
		public int CostBall;

		// Token: 0x04000255 RID: 597
		[XmlAttribute("hitself")]
		public int HitSelfValue = -1;

		// Token: 0x04000256 RID: 598
		[XmlAttribute("buff")]
		public string BuffValue;

		// Token: 0x04000257 RID: 599
		[XmlAttribute]
		public string icon = string.Empty;
	}
}
