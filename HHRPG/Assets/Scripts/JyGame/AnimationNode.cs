using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x0200002F RID: 47
	[XmlType("animation")]
	public class AnimationNode : BasePojo
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00014D00 File Offset: 0x00012F00
		public override string PK
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00014D08 File Offset: 0x00012F08
		public AnimationGroup GetGroup(string name)
		{
			foreach (AnimationGroup animationGroup in this.groups)
			{
				if (animationGroup.name == name)
				{
					return animationGroup;
				}
			}
			return null;
		}

		// Token: 0x040000FE RID: 254
		[XmlAttribute]
		public string name;

		// Token: 0x040000FF RID: 255
		[XmlElement("group")]
		public List<AnimationGroup> groups;
	}
}
