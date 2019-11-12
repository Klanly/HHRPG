using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000036 RID: 54
	[XmlType("role")]
	public class BattleRole
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00014F4C File Offset: 0x0001314C
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00014F9C File Offset: 0x0001319C
		[XmlIgnore]
		public Role role
		{
			get
			{
				if (this._role != null)
				{
					return this._role;
				}
				if (!string.IsNullOrEmpty(this.PredefinedKey))
				{
					this._role = ResourceManager.Get<Role>(this.PredefinedKey).Clone();
					return this._role;
				}
				return null;
			}
			set
			{
				this._role = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00014FA8 File Offset: 0x000131A8
		public bool FaceRight
		{
			get
			{
				return this.Face == 1;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00014FB4 File Offset: 0x000131B4
		public bool IsRandom
		{
			get
			{
				return this.random_level != -1;
			}
		}

		// Token: 0x0400011D RID: 285
		[XmlAttribute("key")]
		public string PredefinedKey;

		// Token: 0x0400011E RID: 286
		[XmlIgnore]
		public bool IsPlayerPickedRole;

		// Token: 0x0400011F RID: 287
		[XmlIgnore]
		private Role _role;

		// Token: 0x04000120 RID: 288
		[XmlAttribute("team")]
		public int Team = 1;

		// Token: 0x04000121 RID: 289
		[XmlAttribute("x")]
		public int X;

		// Token: 0x04000122 RID: 290
		[XmlAttribute("y")]
		public int Y;

		// Token: 0x04000123 RID: 291
		[XmlAttribute("face")]
		public int Face = 1;

		// Token: 0x04000124 RID: 292
		[XmlAttribute("level")]
		public int Level;

		// Token: 0x04000125 RID: 293
		[XmlAttribute("name")]
		public string Name;

		// Token: 0x04000126 RID: 294
		[XmlAttribute("animation")]
		public string Animation;

		// Token: 0x04000127 RID: 295
		[XmlAttribute("boss")]
		public bool IsBoss;

		// Token: 0x04000128 RID: 296
		[XmlIgnore]
		public int random_level = -1;

		// Token: 0x04000129 RID: 297
		[XmlIgnore]
		public string random_name;
	}
}
