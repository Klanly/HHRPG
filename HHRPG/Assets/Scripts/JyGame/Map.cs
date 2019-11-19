using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
    [XmlType("map")]
    public class Map : BasePojo
    {
        private bool initFlag;

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("pic")]
        public string Pic;

        [XmlAttribute("desc")]
        public string Desc;

        public string Bg;

        //[XmlArrayItem(typeof(Music))]
        //[XmlArray("musics")]
        //public List<Music> Musics;

        [XmlElement("mapunit")]
        public List<MapLocation> MapUnits;

        private List<MapLocation> locations = new List<MapLocation>();

        private List<MapRole> mapRoles = new List<MapRole>();

        public override string PK
        {
            get
            {
                return this.Name;
            }
        }

        //		public Music GetRandomMusic()
        //		{
        //			if (this.Musics.Count == 0)
        //			{
        //				return null;
        //			}
        //			return this.Musics[Tools.GetRandomInt(0, this.Musics.Count - 1)];
        //		}

        public List<MapLocation> Locations
        {
            get
            {
                //this.init();
                return this.locations;
            }
        }

        public List<MapRole> MapRoles
        {
            get
            {
                //this.init();
                return this.mapRoles;
            }
        }

        private void init()
        {
            if (!this.initFlag)
            {
                //foreach (MapLocation mapLocation in this.MapUnits)
                //{
                //    if (mapLocation.x >= 0 && mapLocation.y >= 0)
                //    {
                //        this.locations.Add(mapLocation);
                //    }
                //    else
                //    {
                //        this.mapRoles.Add(mapLocation);
                //    }
                //}
                //this.initFlag = true;
            }
        }
    }
}
