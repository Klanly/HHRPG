using System;

namespace JyGame
{
	// Token: 0x02000057 RID: 87
	public class AttributeHelper
	{
		// Token: 0x0600025A RID: 602 RVA: 0x0001A220 File Offset: 0x00018420
		public AttributeHelper(Role Owner)
		{
			this.owner = Owner;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0001A230 File Offset: 0x00018430
		public AttributeHelper(RoleGrowTemplate template)
		{
			this.template = template;
		}

		// Token: 0x170000A0 RID: 160
		public int this[string key]
		{
			get
			{
				if (this.owner != null)
				{
					switch (key)
					{
					//case "hp":
					//	return this.owner.hp;
					//case "maxhp":
					//	return this.owner.maxhp;
					//case "mp":
					//	return this.owner.mp;
					//case "maxmp":
					//	return this.owner.maxmp;
					//case "gengu":
					//	return this.owner.gengu;
					//case "bili":
					//	return this.owner.bili;
					//case "fuyuan":
					//	return this.owner.fuyuan;
					//case "shenfa":
					//	return this.owner.shenfa;
					//case "dingli":
					//	return this.owner.dingli;
					//case "wuxing":
					//	return this.owner.wuxing;
					//case "quanzhang":
					//	return this.owner.quanzhang;
					//case "jianfa":
					//	return this.owner.jianfa;
					//case "daofa":
					//	return this.owner.daofa;
					//case "qimen":
					//	return this.owner.qimen;
					//case "female":
					//	return this.owner.FemaleValue;
					//case "wuxue":
					//	return this.owner.wuxue;
					}
					return -1;
				}
				if (this.template != null)
				{
					switch (key)
					{
					case "hp":
						return this.template.hp;
					case "mp":
						return this.template.mp;
					case "gengu":
						return this.template.gengu;
					case "bili":
						return this.template.bili;
					case "fuyuan":
						return this.template.fuyuan;
					case "shenfa":
						return this.template.shenfa;
					case "dingli":
						return this.template.dingli;
					case "wuxing":
						return this.template.wuxing;
					case "quanzhang":
						return this.template.quanzhang;
					case "jianfa":
						return this.template.jianfa;
					case "daofa":
						return this.template.daofa;
					case "qimen":
						return this.template.qimen;
					case "wuxue":
						return this.template.wuxue;
					}
					return -1;
				}
				return -1;
			}
		}

		// Token: 0x040001FD RID: 509
		private Role owner;

		// Token: 0x040001FE RID: 510
		private RoleGrowTemplate template;
	}
}
