using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000030 RID: 48
	[XmlType("group")]
	public class AnimationGroup
	{
		// Token: 0x04000100 RID: 256
		[XmlAttribute]
		public string name;

		// Token: 0x04000101 RID: 257
		//[XmlElement("image")]
		//public List<AnimationImage> images;
	}
}
