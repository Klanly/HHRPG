using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x0200004C RID: 76
	[XmlType("touch")]
	public class JYTouch : BasePojo
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00017EF8 File Offset: 0x000160F8
		public override string PK
		{
			get
			{
				return this.Key;
			}
		}

		// Token: 0x040001AE RID: 430
		[XmlAttribute("key")]
		public string Key;

		// Token: 0x040001AF RID: 431
		[XmlAttribute("pic")]
		public string Pic;

		// Token: 0x040001B0 RID: 432
		//[XmlElement("zone")]
		//public List<TouchZone> zones;
	}
}
