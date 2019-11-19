using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	public class MapRole
	{
        public string description;

        public List<MapEvent> Events;

        public string pic;

        public string name;

        public MapEvent GetActiveEvent()
        {
            foreach (MapEvent mapEvent in this.Events)
            {
                if (mapEvent.IsActive)
                {
                    return mapEvent;
                }
            }
            return null;
        }

        [XmlIgnore]
        public bool IsActive
        {
            get
            {
                return this.GetActiveEvent() != null;
            }
        }

        [XmlIgnore]
		public string Name
		{
			get
			{
				Role role = ResourceManager.Get<Role>(this.name);
				if (role != null)
				{
					//return CommonSettings.getRoleName(this.name);
				}
				return this.name.TrimEnd(new char[]
				{
					'1',
					'2',
					'3',
					'4',
					'5',
					'6',
					'7',
					'8',
					'9',
					'0'
				});
			}
			set
			{
				this.name = value;
			}
		}

		[XmlIgnore]
		public string roleKey
		{
			get
			{
				return this.name;
			}
		}
	}
}
