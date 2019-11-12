using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("shop")]
    public class Shop : BasePojo
    {

        public override string PK
        {
            get
            {
                return this.Name;
            }
        }

        //		// Token: 0x170000A3 RID: 163
        //		// (get) Token: 0x06000262 RID: 610 RVA: 0x0001A658 File Offset: 0x00018858
        //		// (set) Token: 0x06000263 RID: 611 RVA: 0x0001A678 File Offset: 0x00018878
        //		[XmlAttribute]
        //		public string key
        //		{
        //			get
        //			{
        //				if (string.IsNullOrEmpty(this._key))
        //				{
        //					return this.Name;
        //				}
        //				return this._key;
        //			}
        //			set
        //			{
        //				this._key = value;
        //			}
        //		}

        //		// Token: 0x06000264 RID: 612 RVA: 0x0001A684 File Offset: 0x00018884
        //		public Dictionary<ItemInstance, int> GetAvaliableSales()
        //		{
        //			Dictionary<ItemInstance, int> dictionary = new Dictionary<ItemInstance, int>();
        //			foreach (ShopSale shopSale in this.Sales)
        //			{
        //				string key = "shopBuyKey_" + this.key + shopSale.name;
        //				if (shopSale.limit != -1)
        //				{
        //					int num = 0;
        //					if (RuntimeData.Instance.KeyValues.ContainsKey(key))
        //					{
        //						num = int.Parse(RuntimeData.Instance.KeyValues[key]);
        //					}
        //					if (num < shopSale.limit)
        //					{
        //						dictionary.Add(new ItemInstance
        //						{
        //							Name = shopSale.name
        //						}, shopSale.limit - num);
        //					}
        //				}
        //				else
        //				{
        //					dictionary.Add(new ItemInstance
        //					{
        //						Name = shopSale.name
        //					}, -1);
        //				}
        //			}
        //			return dictionary;
        //		}

        //		// Token: 0x06000265 RID: 613 RVA: 0x0001A790 File Offset: 0x00018990
        //		public ShopSale GetSale(ItemInstance item)
        //		{
        //			foreach (ShopSale shopSale in this.Sales)
        //			{
        //				if (item.Name == shopSale.name)
        //				{
        //					return shopSale;
        //				}
        //			}
        //			return null;
        //		}

        //		// Token: 0x06000266 RID: 614 RVA: 0x0001A810 File Offset: 0x00018A10
        //		public void BuyItem(string itemName, int count = 1)
        //		{
        //			string key = "shopBuyKey_" + this.key + itemName;
        //			if (RuntimeData.Instance.KeyValues.ContainsKey(key))
        //			{
        //				int num = int.Parse(RuntimeData.Instance.KeyValues[key]);
        //				num += count;
        //				RuntimeData.Instance.KeyValues[key] = num.ToString();
        //			}
        //			else
        //			{
        //				RuntimeData.Instance.KeyValues[key] = count.ToString();
        //			}
        //		}

        [XmlAttribute("name")]
        public string Name;

        //		// Token: 0x04000211 RID: 529
        //		[XmlAttribute]
        //		public string pic;

        //		// Token: 0x04000212 RID: 530
        //		[XmlAttribute]
        //		public string music;

        //		// Token: 0x04000213 RID: 531
        //		private string _key = string.Empty;

        //		// Token: 0x04000214 RID: 532
        //		[XmlElement("sale")]
        //		public List<ShopSale> Sales;
    }
}
