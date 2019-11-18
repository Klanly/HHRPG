using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000051 RID: 81
	[XmlType("event")]
	public class MapEvent
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000210 RID: 528 RVA: 0x0001815C File Offset: 0x0001635C
		[XmlIgnore]
		public int probability
		{
			get
			{
				int? num = this.probabilityValue;
				int result;
				if (num == null)
				{
					result = 100;
				}
				else
				{
					int? num2 = this.probabilityValue;
					result = num2.Value;
				}
				return result;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00018194 File Offset: 0x00016394
		public bool IsRepeatOnce
		{
			get
			{
				return this.repeatValue == "once";
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000181A8 File Offset: 0x000163A8
		[XmlIgnore]
		public bool IsActive
		{
			get
			{
				if (this.IsRepeatOnce && RuntimeData.Instance.IsStoryFinished(this.value))
				{
					return false;
				}
				if (!Tools.ProbabilityTest((double)this.probability / 100.0))
				{
					return false;
				}
				foreach (Condition condition in this.Conditions)
				{
					if (!condition.IsTrue)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x040001C0 RID: 448
		[XmlAttribute]
		public string type;

		// Token: 0x040001C1 RID: 449
		[XmlAttribute]
		public string value;

		// Token: 0x040001C2 RID: 450
		[XmlAttribute]
		public string image;

		// Token: 0x040001C3 RID: 451
		[XmlAttribute("probability")]
		public int? probabilityValue;

		// Token: 0x040001C4 RID: 452
		[XmlAttribute]
		public int lv = -1;

		// Token: 0x040001C5 RID: 453
		[XmlAttribute]
		public string description;

		// Token: 0x040001C6 RID: 454
		[XmlAttribute("repeat")]
		public string repeatValue;

		// Token: 0x040001C7 RID: 455
		[XmlElement("condition")]
		public List<Condition> Conditions;
	}
}
