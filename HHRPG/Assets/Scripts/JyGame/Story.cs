using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000064 RID: 100
	[XmlType("story")]
	public class Story : BasePojo
	{
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0001C468 File Offset: 0x0001A668
		public override string PK
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x04000258 RID: 600
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x04000259 RID: 601
		[XmlElement("action")]
		public List<StoryAction> Actions = new List<StoryAction>();

		// Token: 0x0400025A RID: 602
		//[XmlElement("result")]
		//public List<StoryResult> Results = new List<StoryResult>();
	}
}
