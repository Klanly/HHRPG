using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000033 RID: 51
	[XmlType("condition")]
	public class AoyiCondition
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00014E84 File Offset: 0x00013084
		[XmlIgnore]
		public int level
		{
			get
			{
				return (this.levelValue != null) ? int.Parse(this.levelValue) : 0;
			}
		}

		// Token: 0x0400010F RID: 271
		[XmlAttribute]
		public string type;

		// Token: 0x04000110 RID: 272
		[XmlAttribute]
		public string value;

		// Token: 0x04000111 RID: 273
		[XmlAttribute]
		public string levelValue;
	}
}
