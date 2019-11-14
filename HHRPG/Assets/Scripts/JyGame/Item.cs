using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("item")]
    public class Item : BasePojo
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute]
        public string desc;

        [XmlAttribute]
        public string pic;

        [XmlAttribute]
        public int type;

        [XmlAttribute]
        public int level;

        [XmlAttribute]
        public int price;

        [XmlAttribute]
        public bool drop;

        [XmlAttribute]
        public string talent = string.Empty;

        [XmlAttribute]
        public string CanzhangSkill;

        //[XmlElement("require")]
        //public List<Require> Requires = new List<Require>();

        //[XmlElement("trigger")]
        //public List<Trigger> Triggers = new List<Trigger>();

        [XmlAttribute("cd")]
        public int Cooldown;

        public override string PK
        {
            get
            {
                return this.Name;
            }
        }

        [XmlIgnore]
        public string[] Talents
        {
            get
            {
                return this.talent.Split(new char[]
                {
                            '#'
                }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static Item GetItem(string name)
        {
            if (name.EndsWith("残章"))
            {
                string text = name.Replace("残章", string.Empty);
                return new Item
                {
                    Name = name,
                    type = 10,
                    pic = "物品.剑谱",
                    CanzhangSkill = text,
                    desc = "【稀有】神秘的武学残章，能够永久提高" + text + "的等级上限1级。\n注：本物品将被自动使用，提高全存档的该项武学等级上限。",
                    price = 200
                };
            }
            return ResourceManager.Get<Item>(name);
        }

        //public ItemInstance Generate(bool setRandomTrigger = false)
        //{
        //    ItemInstance itemInstance = new ItemInstance();
        //    itemInstance.Name = this.Name;
        //    if (setRandomTrigger)
        //    {
        //        if (Tools.ProbabilityTest(0.1))
        //        {
        //            itemInstance.AddRandomTriggers(4);
        //        }
        //        else if (Tools.ProbabilityTest(0.2))
        //        {
        //            itemInstance.AddRandomTriggers(3);
        //        }
        //        else if (Tools.ProbabilityTest(0.4))
        //        {
        //            itemInstance.AddRandomTriggers(2);
        //        }
        //        else
        //        {
        //            itemInstance.AddRandomTriggers(1);
        //        }
        //    }
        //    return itemInstance;
        //}
    }
}
