using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace JyGame
{
	[XmlType("trigger")]
	public class GlobalTrigger : BasePojo
	{
        private string _pk;

        [XmlAttribute]
        public string story;

        [XmlElement("condition")]
        public List<Condition> Conditions;

        public GlobalTrigger()
		{
			this._pk = Guid.NewGuid().ToString();
		}

		public override string PK
		{
			get
			{
				return this._pk;
			}
		}

		public static GlobalTrigger GetCurrentTrigger()
		{
            //if (RuntimeData.Instance.HasFlag(CommonSettings.flagNoGlobalEvent))
            //{
            //    Debug.LogError("调用了未定义的story:" + CommonSettings.flagNoGlobalEvent);
            //    return null;
            //}
            //foreach (GlobalTrigger globalTrigger in ResourceManager.GetAll<GlobalTrigger>())
            //{
            //    //if (!RuntimeData.Instance.KeyValues.ContainsKey(globalTrigger.story))
            //    //{
            //    //    bool flag = true;
            //    //    foreach (Condition condition in globalTrigger.Conditions)
            //    //    {
            //    //        if (!TriggerLogic.judge(condition))
            //    //        {
            //    //            flag = false;
            //    //            break;
            //    //        }
            //    //    }
            //    //    if (flag)
            //    //    {
            //    //        return globalTrigger;
            //    //    }
            //    //}
            //}
            return null;
		}
	}
}
