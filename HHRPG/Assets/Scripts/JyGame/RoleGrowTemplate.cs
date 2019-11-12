using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000058 RID: 88
	[XmlType("grow_template")]
	public class RoleGrowTemplate : BasePojo
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0001A624 File Offset: 0x00018824
		public override string PK
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0001A62C File Offset: 0x0001882C
		public override void InitBind()
		{
			this.Attributes = new AttributeHelper(this);
		}

		// Token: 0x04000201 RID: 513
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x04000202 RID: 514
		[XmlAttribute]
		public int hp;

		// Token: 0x04000203 RID: 515
		[XmlAttribute]
		public int mp;

		// Token: 0x04000204 RID: 516
		[XmlAttribute]
		public int wuxing;

		// Token: 0x04000205 RID: 517
		[XmlAttribute]
		public int shenfa;

		// Token: 0x04000206 RID: 518
		[XmlAttribute]
		public int bili;

		// Token: 0x04000207 RID: 519
		[XmlAttribute]
		public int gengu;

		// Token: 0x04000208 RID: 520
		[XmlAttribute]
		public int fuyuan;

		// Token: 0x04000209 RID: 521
		[XmlAttribute]
		public int dingli;

		// Token: 0x0400020A RID: 522
		[XmlAttribute]
		public int quanzhang;

		// Token: 0x0400020B RID: 523
		[XmlAttribute]
		public int jianfa;

		// Token: 0x0400020C RID: 524
		[XmlAttribute]
		public int daofa;

		// Token: 0x0400020D RID: 525
		[XmlAttribute]
		public int qimen;

		// Token: 0x0400020E RID: 526
		[XmlAttribute]
		public int wuxue;

		// Token: 0x0400020F RID: 527
		[XmlIgnore]
		public AttributeHelper Attributes;
	}
}
