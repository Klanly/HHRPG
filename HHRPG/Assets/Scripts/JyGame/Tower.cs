using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x0200006C RID: 108
	[XmlType("tower")]
	public class Tower : BasePojo
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000309 RID: 777 RVA: 0x0001C528 File Offset: 0x0001A728
		public override string PK
		{
			get
			{
				return this.Key;
			}
		}

		// Token: 0x0400026D RID: 621
		[XmlAttribute("key")]
		public string Key;

		// Token: 0x0400026E RID: 622
		[XmlAttribute("desc")]
		public string Desc;

		// Token: 0x0400026F RID: 623
		//[XmlElement("map")]
		//public List<TowerMap> Maps = new List<TowerMap>();

		// Token: 0x04000270 RID: 624
		[XmlElement("condition")]
		public List<Condition> Conditions = new List<Condition>();
	}
}
