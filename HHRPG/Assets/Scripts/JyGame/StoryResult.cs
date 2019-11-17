using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	public class StoryResult
	{
		public string ret;

		public string type;

		public int value;

        /// <summary>
        /// 条件
        /// </summary>
		public List<Condition> Conditions;
	}
}
