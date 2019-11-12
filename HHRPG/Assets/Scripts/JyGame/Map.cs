using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("map")]
    public class Map : BasePojo
    {
       
        public override string PK
        {
            get
            {
                return this.Name;
            }
        }

        //		// Token: 0x06000205 RID: 517 RVA: 0x00017F30 File Offset: 0x00016130
        //		public Music GetRandomMusic()
        //		{
        //			if (this.Musics.Count == 0)
        //			{
        //				return null;
        //			}
        //			return this.Musics[Tools.GetRandomInt(0, this.Musics.Count - 1)];
        //		}

        //		// Token: 0x17000083 RID: 131
        //		// (get) Token: 0x06000206 RID: 518 RVA: 0x00017F70 File Offset: 0x00016170
        //		public List<MapLocation> Locations
        //		{
        //			get
        //			{
        //				this.init();
        //				return this.locations;
        //			}
        //		}

        //		// Token: 0x17000084 RID: 132
        //		// (get) Token: 0x06000207 RID: 519 RVA: 0x00017F80 File Offset: 0x00016180
        //		public List<MapRole> MapRoles
        //		{
        //			get
        //			{
        //				this.init();
        //				return this.mapRoles;
        //			}
        //		}

        //		// Token: 0x06000208 RID: 520 RVA: 0x00017F90 File Offset: 0x00016190
        //		private void init()
        //		{
        //			if (!this.initFlag)
        //			{
        //				foreach (MapLocation mapLocation in this.MapUnits)
        //				{
        //					if (mapLocation.x >= 0 && mapLocation.y >= 0)
        //					{
        //						this.locations.Add(mapLocation);
        //					}
        //					else
        //					{
        //						this.mapRoles.Add(mapLocation);
        //					}
        //				}
        //				this.initFlag = true;
        //			}
        //		}

        //		// Token: 0x040001B5 RID: 437
        //		private bool initFlag;

        [XmlAttribute("name")]
        public string Name;

        //		// Token: 0x040001B7 RID: 439
        //		[XmlAttribute("pic")]
        //		public string Pic;

        //		// Token: 0x040001B8 RID: 440
        //		[XmlAttribute("desc")]
        //		public string Desc;

        //		// Token: 0x040001B9 RID: 441
        //		[XmlArrayItem(typeof(Music))]
        //		[XmlArray("musics")]
        //		public List<Music> Musics;

        //		// Token: 0x040001BA RID: 442
        //		[XmlElement("mapunit")]
        //		public List<MapLocation> MapUnits;

        //		// Token: 0x040001BB RID: 443
        //		private List<MapLocation> locations = new List<MapLocation>();

        //		// Token: 0x040001BC RID: 444
        //		private List<MapRole> mapRoles = new List<MapRole>();
    }
}
