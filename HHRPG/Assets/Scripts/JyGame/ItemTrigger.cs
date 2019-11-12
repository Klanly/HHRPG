using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000049 RID: 73
	[XmlType("item_trigger")]
	public class ItemTrigger : BasePojo
	{
		// Token: 0x060001FA RID: 506 RVA: 0x000176D8 File Offset: 0x000158D8
		public ItemTrigger()
		{
			this._pk = Guid.NewGuid().ToString();
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0001770C File Offset: 0x0001590C
		public override string PK
		{
			get
			{
				return this._pk;
			}
		}

		// Token: 0x040001A3 RID: 419
		private string _pk;

		// Token: 0x040001A4 RID: 420
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x040001A5 RID: 421
		[XmlAttribute("minlevel")]
		public int MinLevel = -1;

		// Token: 0x040001A6 RID: 422
		[XmlAttribute("maxlevel")]
		public int MaxLevel = -1;

		// Token: 0x040001A7 RID: 423
		[XmlElement("trigger")]
		public List<ITTrigger> Triggers;
	}
}
