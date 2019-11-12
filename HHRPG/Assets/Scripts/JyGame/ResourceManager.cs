using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace JyGame
{
    public class ResourceManager
    {
        private static bool _inited = false;

        private static string _detail = string.Empty;

        private static float _progress = 0f;

        private static List<string> visitedUri = new List<string>();

        private static Dictionary<Type, Dictionary<string, object>> _values = new Dictionary<Type, Dictionary<string, object>>();

        public static void ResetInitFlag()
        {
            ResourceManager._inited = false;
        }

        public static void Init()
        {
            if (ResourceManager._inited)
            {
                return;
            }
            ResourceManager.Clear();//读表
            //ResourceManager.LoadResource<Resource>("resource.xml", "root/resource");
            //ResourceManager.LoadResource<Battle>("battles.xml", "root/battle");
            //ResourceManager.LoadResource<Skill>("skills.xml", "root/skill");
            //ResourceManager.LoadResource<InternalSkill>("internal_skills.xml", "root/internal_skill");
            //ResourceManager.LoadResource<SpecialSkill>("special_skills.xml", "root/special_skill");
            ResourceManager.LoadResource<Role>("roles.xml", "root/role");
            //ResourceManager.LoadResource<Aoyi>("aoyis.xml", "root/aoyi");
            //ResourceManager.LoadResource<Story>("storys.xml", "root/story");
            //ResourceManager.LoadResource<Story>("storysPY.xml", "root/story");
            //ResourceManager.LoadResource<Story>("storysCG.xml", "root/story");
            //ResourceManager.LoadResource<Map>("maps.xml", "root/map");
            //ResourceManager.LoadResource<Item>("items.xml", "root/item");
            //ResourceManager.LoadResource<ItemTrigger>("item_triggers.xml", "root/item_trigger");
            //ResourceManager.LoadResource<GlobalTrigger>("globaltrigger.xml", "root/trigger");
            //ResourceManager.LoadResource<Tower>("towers.xml", "root/tower");
            //ResourceManager.LoadResource<RoleGrowTemplate>("grow_templates.xml", "root/grow_template");
            //ResourceManager.LoadResource<AnimationNode>("animations.xml", "root/animation");
            //ResourceManager.LoadResource<Shop>("shops.xml", "root/shop");
            //ResourceManager.LoadResource<Menpai>("menpai.xml", "root/menpai");
            //ResourceManager.LoadResource<Task>("newbie.xml", "root/task");
            //ResourceManager.LoadResource<JYTouch>("touch.xml", "root/touch");
            ResourceManager._inited = true;
        }

        //		public static IEnumerator Init2(CommonSettings.VoidCallBack callback)
        //		{
        //			if (ResourceManager._inited)
        //			{
        //				yield return 0;
        //			}
        //			ResourceManager.Clear();
        //			ResourceManager.LoadResource<Resource>("resource.xml", "root/resource");
        //			ResourceManager.detail = "正在加载战斗设定..";
        //			ResourceManager.progress = 0f;
        //			ResourceManager.LoadResource<Battle>("battles.xml", "root/battle");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载技能设定..";
        //			ResourceManager.progress = 0.1f;
        //			ResourceManager.LoadResource<Skill>("skills.xml", "root/skill");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载内功技能设定..";
        //			ResourceManager.progress = 0.2f;
        //			ResourceManager.LoadResource<InternalSkill>("internal_skills.xml", "root/internal_skill");
        //			yield return 0;
        //			ResourceManager.progress = 0.25f;
        //			ResourceManager.detail = "正在加载特殊技能设定..";
        //			ResourceManager.LoadResource<SpecialSkill>("special_skills.xml", "root/special_skill");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载角色设定..";
        //			ResourceManager.progress = 0.3f;
        //			ResourceManager.LoadResource<Role>("roles.xml", "root/role");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载奥义设定..";
        //			ResourceManager.progress = 0.35f;
        //			ResourceManager.LoadResource<Aoyi>("aoyis.xml", "root/aoyi");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载剧本设定..";
        //			ResourceManager.progress = 0.5f;
        //			ResourceManager.LoadResource<Story>("storys.xml", "root/story");
        //			ResourceManager.LoadResource<Story>("storysPY.xml", "root/story");
        //			ResourceManager.LoadResource<Story>("storysCG.xml", "root/story");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载地图设定..";
        //			ResourceManager.progress = 0.7f;
        //			ResourceManager.LoadResource<Map>("maps.xml", "root/map");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载物品设定..";
        //			ResourceManager.progress = 0.9f;
        //			ResourceManager.LoadResource<Item>("items.xml", "root/item");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载物品属性设定..";
        //			ResourceManager.progress = 0.93f;
        //			ResourceManager.LoadResource<ItemTrigger>("item_triggers.xml", "root/item_trigger");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载触发器设定..";
        //			ResourceManager.progress = 0.95f;
        //			ResourceManager.LoadResource<GlobalTrigger>("globaltrigger.xml", "root/trigger");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载天关设定..";
        //			ResourceManager.progress = 0.96f;
        //			ResourceManager.LoadResource<Tower>("towers.xml", "root/tower");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载角色模板..";
        //			ResourceManager.progress = 0.98f;
        //			ResourceManager.LoadResource<RoleGrowTemplate>("grow_templates.xml", "root/grow_template");
        //			yield return 0;
        //			ResourceManager.detail = "正在加载商店设定..";
        //			ResourceManager.progress = 0.99f;
        //			ResourceManager.LoadResource<Shop>("shops.xml", "root/shop");
        //			yield return 0;
        //			ResourceManager.LoadResource<AnimationNode>("animations.xml", "root/animation");
        //			ResourceManager.LoadResource<Menpai>("menpai.xml", "root/menpai");
        //			ResourceManager.LoadResource<Task>("newbie.xml", "root/task");
        //			ResourceManager.LoadResource<JYTouch>("touch.xml", "root/touch");
        //			ResourceManager._inited = true;
        //			if (callback != null)
        //			{
        //				callback();
        //			}
        //			yield return 0;
        //			yield break;
        //		}

        /// <summary>
        /// 详情
        /// </summary>
        public static string detail
        {
            get
            {
                return ResourceManager._detail;
            }
            set
            {
                ResourceManager._detail = value;
            }
        }

        /// <summary>
        /// 进度
        /// </summary>
        public static float progress
        {
            get
            {
                return ResourceManager._progress;
            }
            set
            {
                ResourceManager._progress = value;
            }
        }

        public static T Get<T>(string key)
        {
            foreach (Type type in ResourceManager._values.Keys)
            {
                if (typeof(T) == type && ResourceManager._values[type].ContainsKey(key))
                {
                    return (T)((object)ResourceManager._values[type][key]);
                }
            }
            return default(T);
        }

        //		// Token: 0x06000098 RID: 152 RVA: 0x00005F90 File Offset: 0x00004190
        //		public static IEnumerable<T> GetAll<T>()
        //		{
        //			if (ResourceManager._values.ContainsKey(typeof(T)))
        //			{
        //				return ResourceManager._values[typeof(T)].Values.Cast<T>();
        //			}
        //			return null;
        //		}

        //		// Token: 0x06000099 RID: 153 RVA: 0x00005FD8 File Offset: 0x000041D8
        //		public static T GetRandom<T>()
        //		{
        //			return (T)((object)ResourceManager._values[typeof(T)].Values.ToList<object>()[Tools.GetRandomInt(0, ResourceManager._values[typeof(T)].Count - 1)]);
        //		}

        //		// Token: 0x0600009A RID: 154 RVA: 0x00006030 File Offset: 0x00004230
        //		public static T GetRandomInCondition<T>(CommonSettings.JudgeCallback judgeCallback, int retryTime = 100)
        //		{
        //			int num = 0;
        //			for (;;)
        //			{
        //				num++;
        //				if (num > retryTime)
        //				{
        //					break;
        //				}
        //				T random = ResourceManager.GetRandom<T>();
        //				if (judgeCallback(random))
        //				{
        //					return random;
        //				}
        //			}
        //			return default(T);
        //		}

        public static void LoadResource<T>(string uri, string nodepath) where T : BasePojo
        {
            if (ResourceManager.visitedUri.Contains(uri))
            {
                return;
            }
            ResourceManager.visitedUri.Add(uri);
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                if (CommonSettings.SECURE_XML)
                {
                    string path = "Scripts/Secure/" + uri.Split(new char[]
                    {
                                '.'
                    })[0];
                   
                    string input = Resources.Load(path).ToString();
                    xmlDocument.LoadXml(input);
                }
                Dictionary<string, object> dictionary = null;
                if (ResourceManager._values.ContainsKey(typeof(T)))
                {
                    dictionary = ResourceManager._values[typeof(T)];
                }
                else
                {
                    dictionary = new Dictionary<string, object>();
                }
                foreach (object obj in xmlDocument.SelectNodes(nodepath))
                {
                    XmlNode xmlNode = (XmlNode)obj;
                    T t = BasePojo.Create<T>(xmlNode.OuterXml);
                    if (dictionary.ContainsKey(t.PK))
                    {
                        Debug.LogError("重复key:" + t.PK + ",xml=" + uri);
                    }
                    else
                    {
                        dictionary.Add(t.PK, t);
                    }
                }
                if (!ResourceManager._values.ContainsKey(typeof(T)))
                {
                    ResourceManager._values.Add(typeof(T), dictionary);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("xml载入错误:" + uri);
                Debug.LogError(ex.ToString());
            }
        }

        private static void Clear()
        {
            ResourceManager._values.Clear();
            ResourceManager.visitedUri.Clear();
        }

        //		public static void Add<T>(string pk, object obj)
        //		{
        //			Dictionary<string, object> dictionary;
        //			if (ResourceManager._values.ContainsKey(typeof(T)))
        //			{
        //				dictionary = ResourceManager._values[typeof(T)];
        //			}
        //			else
        //			{
        //				dictionary = new Dictionary<string, object>();
        //			}
        //			dictionary[pk] = obj;
        //			if (!ResourceManager._values.ContainsKey(typeof(T)))
        //			{
        //				ResourceManager._values.Add(typeof(T), dictionary);
        //			}
        //		}
    }
}
