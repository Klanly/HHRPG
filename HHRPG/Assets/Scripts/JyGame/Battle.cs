using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000034 RID: 52
	[XmlType("battle")]
	public class Battle : BasePojo
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00014EB4 File Offset: 0x000130B4
		public override string PK
		{
			get
			{
				return this.Key;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00014EBC File Offset: 0x000130BC
		public List<string> mustKeys
		{
			get
			{
				if (this.MustStr != null)
				{
					return new List<string>(this.MustStr.Split(new char[]
					{
						'#'
					}));
				}
				return null;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00014EF4 File Offset: 0x000130F4
		[XmlIgnore]
		public bool IsArena
		{
			get
			{
				return this.Key.StartsWith("arena");
			}
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00014F08 File Offset: 0x00013108
		public Battle Clone()
		{
			return BasePojo.Create<Battle>(this.Xml);
		}

		// Token: 0x04000112 RID: 274
		[XmlAttribute("key")]
		public string Key;

		// Token: 0x04000113 RID: 275
		[XmlAttribute("map")]
		public string Map;

		// Token: 0x04000114 RID: 276
		[XmlAttribute("mapkey")]
		public string MapKey;

		// Token: 0x04000115 RID: 277
		[XmlAttribute("music")]
		public string Music;

		// Token: 0x04000116 RID: 278
		[XmlAttribute("must")]
		public string MustStr;

		// Token: 0x04000117 RID: 279
		[XmlAttribute("forceAI")]
		public bool ForceAI;

		// Token: 0x04000118 RID: 280
		[XmlArray("roles")]
		[XmlArrayItem(typeof(BattleRole))]
		public List<BattleRole> Roles;

		// Token: 0x04000119 RID: 281
		[XmlArrayItem(typeof(StoryAction))]
		[XmlArray("story")]
		public List<StoryAction> StoryActions;

		// Token: 0x0400011A RID: 282
		[XmlElement("random")]
		public RandomBattleRole randomBattleRoles;

		// Token: 0x0400011B RID: 283
		[XmlAttribute("bonus")]
		public bool Bonus = true;
	}
}
