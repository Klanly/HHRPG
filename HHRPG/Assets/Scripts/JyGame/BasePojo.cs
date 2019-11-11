using System;
using System.Xml.Serialization;

namespace JyGame
{
	// Token: 0x02000020 RID: 32
	public abstract class BasePojo
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600012E RID: 302
		public abstract string PK { get; }

		// Token: 0x0600012F RID: 303 RVA: 0x00010B6C File Offset: 0x0000ED6C
		public virtual void InitBind()
		{
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00010B70 File Offset: 0x0000ED70
		public static T Create<T>(string xml) where T : BasePojo
		{
            //T t = Tools.LoadObjectFromXML<T>(xml);
            //t.InitBind();
            //t.Xml = xml;
            //return t;
            return null;
        }

        // Token: 0x040000B9 RID: 185
        [XmlIgnore]
		public string Xml = string.Empty;
	}
}
