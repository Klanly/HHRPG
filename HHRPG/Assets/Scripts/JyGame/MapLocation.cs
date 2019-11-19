using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000050 RID: 80
	[XmlType("location")]
	public class MapLocation : MapRole
	{
		// Token: 0x0600020B RID: 523 RVA: 0x00018048 File Offset: 0x00016248
		public string getName()
		{
			if (this.name.Equals("女主"))
			{
				//return RuntimeData.Instance.femaleName;
			}
			return this.name;
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0001807C File Offset: 0x0001627C
		[XmlIgnore]
		public int X
		{
			get
			{
				return this.x * 1140 * 2 / 800 + 18;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00018098 File Offset: 0x00016298
		[XmlIgnore]
		public int Y
		{
			get
			{
				return -this.y * 640 * 2 / 600 - 8;
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x000180B4 File Offset: 0x000162B4
		public string GetImageKey()
		{
			//foreach (MapEvent mapEvent in this.Events)
			//{
			//	if (!string.IsNullOrEmpty(mapEvent.image) && mapEvent.type == "map")
			//	{
			//		return mapEvent.image;
			//	}
			//}
			return string.Empty;
		}

		// Token: 0x040001BE RID: 446
		[XmlAttribute]
		public int x;

		// Token: 0x040001BF RID: 447
		[XmlAttribute]
		public int y;
	}
}
