using System;
using System.Xml.Serialization;

namespace JyGame
{
	public class Condition
	{
        public bool IsTrue
        {
            get
            {
                return TriggerLogic.judge(this);
            }
        }

        [XmlAttribute]
		public string type;

		[XmlAttribute]
		public string value;

		[XmlAttribute]
		public int number = -1;
	}
}
