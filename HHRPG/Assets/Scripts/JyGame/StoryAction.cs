using System;
using System.Xml.Serialization;

namespace JyGame
{
	[XmlType("action")]
	public class StoryAction
	{
		public static StoryAction CreateDialog(Role role, string msg)
		{
			return new StoryAction
			{
				type = "DIALOG",
				value = string.Format("{0}#{1}", role.Key, msg)
			};
		}

		[XmlAttribute]
		public string type;

		[XmlAttribute]
		public string value;
	}
}
