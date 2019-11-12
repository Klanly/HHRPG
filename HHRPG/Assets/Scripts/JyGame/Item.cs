using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("item")]
    public class Item : BasePojo
    {

        public override string PK
        {
            get
            {
                return this.Name;
            }
        }

        //		// Token: 0x1700006A RID: 106
        //		// (get) Token: 0x060001CF RID: 463 RVA: 0x000161C0 File Offset: 0x000143C0
        //		[XmlIgnore]
        //		public string[] Talents
        //		{
        //			get
        //			{
        //				return this.talent.Split(new char[]
        //				{
        //					'#'
        //				}, StringSplitOptions.RemoveEmptyEntries);
        //			}
        //		}

        //		// Token: 0x060001D0 RID: 464 RVA: 0x000161DC File Offset: 0x000143DC
        //		public static Item GetItem(string name)
        //		{
        //			if (name.EndsWith("残章"))
        //			{
        //				string text = name.Replace("残章", string.Empty);
        //				return new Item
        //				{
        //					Name = name,
        //					type = 10,
        //					pic = "物品.剑谱",
        //					CanzhangSkill = text,
        //					desc = "【稀有】神秘的武学残章，能够永久提高" + text + "的等级上限1级。\n注：本物品将被自动使用，提高全存档的该项武学等级上限。",
        //					price = 200
        //				};
        //			}
        //			return ResourceManager.Get<Item>(name);
        //		}

        //		public ItemInstance Generate(bool setRandomTrigger = false)
        //		{
        //			ItemInstance itemInstance = new ItemInstance();
        //			itemInstance.Name = this.Name;
        //			if (setRandomTrigger)
        //			{
        //				if (Tools.ProbabilityTest(0.1))
        //				{
        //					itemInstance.AddRandomTriggers(4);
        //				}
        //				else if (Tools.ProbabilityTest(0.2))
        //				{
        //					itemInstance.AddRandomTriggers(3);
        //				}
        //				else if (Tools.ProbabilityTest(0.4))
        //				{
        //					itemInstance.AddRandomTriggers(2);
        //				}
        //				else
        //				{
        //					itemInstance.AddRandomTriggers(1);
        //				}
        //			}
        //			return itemInstance;
        //		}

        [XmlAttribute("name")]
        public string Name;

        //		// Token: 0x04000187 RID: 391
        //		[XmlAttribute]
        //		public string desc;

        //		// Token: 0x04000188 RID: 392
        //		[XmlAttribute]
        //		public string pic;

        //		// Token: 0x04000189 RID: 393
        //		[XmlAttribute]
        //		public int type;

        //		// Token: 0x0400018A RID: 394
        //		[XmlAttribute]
        //		public int level;

        //		// Token: 0x0400018B RID: 395
        //		[XmlAttribute]
        //		public int price;

        //		// Token: 0x0400018C RID: 396
        //		[XmlAttribute]
        //		public bool drop;

        //		// Token: 0x0400018D RID: 397
        //		[XmlAttribute]
        //		public string talent = string.Empty;

        //		// Token: 0x0400018E RID: 398
        //		[XmlAttribute]
        //		public string CanzhangSkill;

        //		// Token: 0x0400018F RID: 399
        //		[XmlElement("require")]
        //		public List<Require> Requires = new List<Require>();

        //		// Token: 0x04000190 RID: 400
        //		[XmlElement("trigger")]
        //		public List<Trigger> Triggers = new List<Trigger>();

        //		// Token: 0x04000191 RID: 401
        //		[XmlAttribute("cd")]
        //		public int Cooldown;
    }
}
