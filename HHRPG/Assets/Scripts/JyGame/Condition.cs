using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000067 RID: 103
	[XmlType("condition")]
	public class Condition
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0001C4C8 File Offset: 0x0001A6C8
		//[XmlIgnore]
		//public bool IsTrue
		//{
		//	get
		//	{
		//		return TriggerLogic.judge(this);
		//	}
		//}

		// Token: 0x04000261 RID: 609
		[XmlAttribute]
		public string type;

		// Token: 0x04000262 RID: 610
		[XmlAttribute]
		public string value;

		// Token: 0x04000263 RID: 611
		[XmlAttribute]
		public int number = -1;
	}
}
