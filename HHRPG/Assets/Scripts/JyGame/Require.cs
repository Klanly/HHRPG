using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000071 RID: 113
	[XmlType("require")]
	public class Require : BasePojo
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0001C6EC File Offset: 0x0001A8EC
		public override string PK
		{
			get
			{
				return this.Name + this.ArgvsString;
			}
		}

		// Token: 0x0400027C RID: 636
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x0400027D RID: 637
		[XmlAttribute("argvs")]
		public string ArgvsString;
	}
}
