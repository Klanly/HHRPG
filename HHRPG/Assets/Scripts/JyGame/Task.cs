using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	[XmlType("task")]
	public class Task : BasePojo
	{
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0001C4D8 File Offset: 0x0001A6D8
		public override string PK
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x04000264 RID: 612
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x04000265 RID: 613
		[XmlAttribute("description")]
		public string Desc;

		// Token: 0x04000266 RID: 614
		//[XmlElement("location")]
		//public List<TaskLocation> Locations;

		// Token: 0x04000267 RID: 615
		//[XmlElement("finish")]
		//public List<TaskFinish> Finishes;

		// Token: 0x04000268 RID: 616
		//[XmlElement("result")]
		//public StoryResult Result;
	}
}
