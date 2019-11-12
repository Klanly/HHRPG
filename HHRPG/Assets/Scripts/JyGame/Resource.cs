using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

namespace JyGame
{
    [XmlType("resource")]
    public class Resource : BasePojo
    {
        [XmlAttribute("key")]
        public string Key;

        [XmlAttribute("value")]
        public string Value;

        [XmlAttribute("icon")]
        public string Icon;

        private static List<string> suggestTips = new List<string>();


        private static bool suggestTipInited = false;
        public override string PK
        {
            get
            {
                return this.Key;
            }
        }

        //		public static Sprite GetZhujueHead()
        //		{
        //			return Resource.GetImage(RuntimeData.Instance.Team[0].Head, false);
        //		}

        //		// Token: 0x0600021F RID: 543 RVA: 0x00018398 File Offset: 0x00016598
        //		public static string GetRandomSuggestTip()
        //		{
        //			if (!Resource.suggestTipInited)
        //			{
        //				foreach (Resource resource in ResourceManager.GetAll<Resource>())
        //				{
        //					if (resource.Key.StartsWith("小贴士"))
        //					{
        //						Resource.suggestTips.Add(resource.Value);
        //					}
        //				}
        //				Resource.suggestTipInited = true;
        //			}
        //			if (Resource.suggestTips.Count == 0)
        //			{
        //				Resource.suggestTipInited = false;
        //				return string.Empty;
        //			}
        //			return Resource.suggestTips[Tools.GetRandomInt(0, Resource.suggestTips.Count - 1)];
        //		}

        //		// Token: 0x06000220 RID: 544 RVA: 0x00018460 File Offset: 0x00016660
        //		public static Sprite GetIcon(string iconName)
        //		{
        //			if (CommonSettings.MOD_EDITOR_MODE)
        //			{
        //				return ModEditorResourceManager.GetSprite("Icons/" + iconName);
        //			}
        //			return Resources.Load<Sprite>("Icons/" + iconName);
        //		}

        //		// Token: 0x06000221 RID: 545 RVA: 0x0001849C File Offset: 0x0001669C
        //		public static Sprite GetBattleBg(string key)
        //		{
        //			if (CommonSettings.MOD_EDITOR_MODE)
        //			{
        //				return ModEditorResourceManager.GetSprite("BattleBg/" + key);
        //			}
        //			return AssetBundleManager.GetBattleBg(key);
        //		}

        //		// Token: 0x06000222 RID: 546 RVA: 0x000184CC File Offset: 0x000166CC
        //		public static Sprite GetImage(string key, bool forceLoadFromResource = false)
        //		{
        //			Resource resource = ResourceManager.Get<Resource>(key);
        //			if (resource == null)
        //			{
        //				return null;
        //			}
        //			string text = resource.Value.Split(new char[]
        //			{
        //				'.'
        //			})[0];
        //			if (CommonSettings.MOD_EDITOR_MODE && !forceLoadFromResource)
        //			{
        //				return ModEditorResourceManager.GetSprite(text);
        //			}
        //			if (key.StartsWith("地图."))
        //			{
        //				return AssetBundleManager.GetMap(text.Split(new char[]
        //				{
        //					'/'
        //				}).Last<string>());
        //			}
        //			return Resources.Load<Sprite>(text);
        //		}

        //		// Token: 0x06000223 RID: 547 RVA: 0x00018550 File Offset: 0x00016750
        //		private IEnumerator LoadTextureFromURL(string url, Action<Texture2D> cb)
        //		{
        //			WWW www = new WWW(url);
        //			yield return www;
        //			if (string.IsNullOrEmpty(www.error))
        //			{
        //				cb(www.texture);
        //				www.Dispose();
        //			}
        //			yield break;
        //		}

        //		// Token: 0x06000224 RID: 548 RVA: 0x00018580 File Offset: 0x00016780
        //		public static AudioClip GetMusic(string key)
        //		{
        //			Resource resource = ResourceManager.Get<Resource>(key);
        //			if (resource == null)
        //			{
        //				Debug.Log("load invalid music, key=" + key);
        //				return null;
        //			}
        //			string text = resource.Value.Split(new char[]
        //			{
        //				'.'
        //			})[0];
        //			string url = text.Split(new char[]
        //			{
        //				'/'
        //			}).Last<string>();
        //			if (CommonSettings.MOD_EDITOR_MODE)
        //			{
        //				return ModEditorResourceManager.GetAudioClip(text);
        //			}
        //			return AssetBundleManager.GetAudio(url);
        //		}

        //		// Token: 0x06000225 RID: 549 RVA: 0x000185F8 File Offset: 0x000167F8
        //		public static string GetLiezhuan(Role role)
        //		{
        //			Resource resource;
        //			if (role.Key == "主角")
        //			{
        //				resource = ResourceManager.Get<Resource>("人物.主角");
        //			}
        //			else if (role.Key == "女主")
        //			{
        //				resource = ResourceManager.Get<Resource>("人物.女主");
        //			}
        //			else
        //			{
        //				resource = ResourceManager.Get<Resource>("人物." + role.Name);
        //			}
        //			if (resource == null)
        //			{
        //				return null;
        //			}
        //			return resource.Value;
        //		}

        //		// Token: 0x06000226 RID: 550 RVA: 0x00018674 File Offset: 0x00016874
        //		public static string GetTalentDesc(string talent)
        //		{
        //			Resource resource = ResourceManager.Get<Resource>("天赋." + talent);
        //			if (resource == null)
        //			{
        //				return null;
        //			}
        //			return resource.Value.Split(new char[]
        //			{
        //				'#'
        //			})[1];
        //		}

        //		// Token: 0x06000227 RID: 551 RVA: 0x000186B4 File Offset: 0x000168B4
        //		public static int GetTalentCost(string talent)
        //		{
        //			Resource resource = ResourceManager.Get<Resource>("天赋." + talent);
        //			if (resource == null)
        //			{
        //				return 0;
        //			}
        //			return int.Parse(resource.Value.Split(new char[]
        //			{
        //				'#'
        //			})[0]);
        //		}

        //		// Token: 0x06000228 RID: 552 RVA: 0x000186F8 File Offset: 0x000168F8
        //		public static string GetTalentInfo(string name, bool displayCost = true)
        //		{
        //			string talentDesc = Resource.GetTalentDesc(name);
        //			if (displayCost)
        //			{
        //				return string.Format("【{0}】(消耗武学常识:{1}){2}", name, Resource.GetTalentCost(name), talentDesc);
        //			}
        //			return string.Format("【{0}】{1}", name, talentDesc);
        //		}
    }
}
