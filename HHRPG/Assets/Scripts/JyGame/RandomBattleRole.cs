using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000035 RID: 53
	[XmlType("random")]
	public class RandomBattleRole
	{
		// Token: 0x0400011C RID: 284
		[XmlElement("role")]
		public List<BattleRole> randomRoles = new List<BattleRole>();
	}
}
