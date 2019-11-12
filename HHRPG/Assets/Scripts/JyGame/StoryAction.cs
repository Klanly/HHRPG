using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000065 RID: 101
	[XmlType("action")]
	public class StoryAction
	{
		// Token: 0x060002FF RID: 767 RVA: 0x0001C478 File Offset: 0x0001A678
		public static StoryAction CreateDialog(Role role, string msg)
		{
			return new StoryAction
			{
				type = "DIALOG",
				value = string.Format("{0}#{1}", role.Key, msg)
			};
		}

		// Token: 0x0400025B RID: 603
		[XmlAttribute]
		public string type;

		// Token: 0x0400025C RID: 604
		[XmlAttribute]
		public string value;
	}
}
