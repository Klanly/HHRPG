using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000070 RID: 112
	[XmlType("trigger")]
	public class Trigger : BasePojo
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0001C584 File Offset: 0x0001A784
		public override string PK
		{
			get
			{
				string str = this.Name + "_" + this.ArgvsString;
				return str + "_" + this.Level.ToString();
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600030F RID: 783 RVA: 0x0001C5C0 File Offset: 0x0001A7C0
		[XmlIgnore]
		public List<string> Argvs
		{
			get
			{
				return new List<string>(this.ArgvsString.Split(new char[]
				{
					','
				}));
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0001C5E0 File Offset: 0x0001A7E0
		public override string ToString()
		{
			if (this.Name == "AddBuff")
			{
				return string.Empty;
			}
			if (this.Name == "talent")
			{
				string text = this.Argvs[0];
				return string.Format("天赋 {0}(被动生效)\n{1}", text, ResourceManager.Get<Resource>("天赋." + text).Value.Split(new char[]
				{
					'#'
				})[1]);
			}
			if (this.Name == "eq_talent")
			{
				string text2 = this.Argvs[0];
				return string.Format("天赋 {0}(装备生效)\n{1}", text2, ResourceManager.Get<Resource>("天赋." + text2).Value.Split(new char[]
				{
					'#'
				})[1]);
			}
			string value = ResourceManager.Get<Resource>("ItemTrigger." + this.Name).Value;
			return string.Format(value, this.Argvs.ToArray());
		}

		// Token: 0x04000279 RID: 633
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x0400027A RID: 634
		[XmlAttribute("argvs")]
		public string ArgvsString;

		// Token: 0x0400027B RID: 635
		[XmlAttribute("lv")]
		public int Level = -1;
	}
}
