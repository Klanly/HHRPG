using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000053 RID: 83
	[XmlType("menpai")]
	public class Menpai : BasePojo
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600021A RID: 538 RVA: 0x0001834C File Offset: 0x0001654C
		public override string PK
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x040001CC RID: 460
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x040001CD RID: 461
		[XmlAttribute("bg")]
		public string Background;

		// Token: 0x040001CE RID: 462
		[XmlAttribute("pic")]
		public string Pic;

		// Token: 0x040001CF RID: 463
		[XmlAttribute]
		public string story;

		// Token: 0x040001D0 RID: 464
		[XmlAttribute]
		public string shifu;

		// Token: 0x040001D1 RID: 465
		[XmlAttribute]
		public string wuxue;

		// Token: 0x040001D2 RID: 466
		[XmlAttribute]
		public string zhuxiu;

		// Token: 0x040001D3 RID: 467
		[XmlAttribute]
		public string tedian;

		// Token: 0x040001D4 RID: 468
		[XmlAttribute]
		public string info;
	}
}
