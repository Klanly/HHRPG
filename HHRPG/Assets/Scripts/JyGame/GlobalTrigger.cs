using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000042 RID: 66
	[XmlType("trigger")]
	public class GlobalTrigger : BasePojo
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x00015FB8 File Offset: 0x000141B8
		public GlobalTrigger()
		{
			this._pk = Guid.NewGuid().ToString();
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00015FE0 File Offset: 0x000141E0
		public override string PK
		{
			get
			{
				return this._pk;
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00015FE8 File Offset: 0x000141E8
		public static GlobalTrigger GetCurrentTrigger()
		{
			//if (RuntimeData.Instance.HasFlag(CommonSettings.flagNoGlobalEvent))
			//{
			//	return null;
			//}
			//foreach (GlobalTrigger globalTrigger in ResourceManager.GetAll<GlobalTrigger>())
			//{
			//	if (!RuntimeData.Instance.KeyValues.ContainsKey(globalTrigger.story))
			//	{
			//		bool flag = true;
			//		foreach (Condition condition in globalTrigger.Conditions)
			//		{
			//			if (!TriggerLogic.judge(condition))
			//			{
			//				flag = false;
			//				break;
			//			}
			//		}
			//		if (flag)
			//		{
			//			return globalTrigger;
			//		}
			//	}
			//}
			return null;
		}

		// Token: 0x0400016C RID: 364
		private string _pk;

		// Token: 0x0400016D RID: 365
		[XmlAttribute]
		public string story;

		// Token: 0x0400016E RID: 366
		[XmlElement("condition")]
		public List<Condition> Conditions;
	}
}
