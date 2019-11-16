using System;
using System.Xml.Serialization;

namespace JyGame
{
	public class StoryAction
	{
        public string type;

        public string value;

        public static StoryAction CreateDialog(Role role, string msg)
		{
			return new StoryAction
			{
				type = "DIALOG",
				value = string.Format("{0}#{1}", role.Key, msg)
			};
		}
	}
}
