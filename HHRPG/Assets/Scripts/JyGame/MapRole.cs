using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000052 RID: 82
	[XmlType("maprole")]
	public class MapRole
	{
		// Token: 0x06000214 RID: 532 RVA: 0x00018264 File Offset: 0x00016464
		//public MapEvent GetActiveEvent()
		//{
		//	foreach (MapEvent mapEvent in this.Events)
		//	{
		//		if (mapEvent.IsActive)
		//		{
		//			return mapEvent;
		//		}
		//	}
		//	return null;
		//}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000215 RID: 533 RVA: 0x000182D8 File Offset: 0x000164D8
		//[XmlIgnore]
		//public bool IsActive
		//{
		//	get
		//	{
		//		return this.GetActiveEvent() != null;
		//	}
		//}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000216 RID: 534 RVA: 0x000182E8 File Offset: 0x000164E8
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00018330 File Offset: 0x00016530
		[XmlIgnore]
		public string Name
		{
			get
			{
				Role role = ResourceManager.Get<Role>(this.name);
				if (role != null)
				{
					//return CommonSettings.getRoleName(this.name);
				}
				return this.name.TrimEnd(new char[]
				{
					'1',
					'2',
					'3',
					'4',
					'5',
					'6',
					'7',
					'8',
					'9',
					'0'
				});
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000218 RID: 536 RVA: 0x0001833C File Offset: 0x0001653C
		[XmlIgnore]
		public string roleKey
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x040001C8 RID: 456
		[XmlAttribute]
		public string description;

		// Token: 0x040001C9 RID: 457
		[XmlElement("event")]
		//public List<MapEvent> Events;

		// Token: 0x040001CA RID: 458
		[XmlAttribute]
		public string pic;

		// Token: 0x040001CB RID: 459
		[XmlAttribute]
		public string name;
	}
}
