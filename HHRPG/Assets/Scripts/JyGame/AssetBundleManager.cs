using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace JyGame
{
    public class AssetBundleManager
    {
        public static AssetBundle MapAssets = null;

        public static AssetBundle BattleAssets = null;

        public static AssetBundle AudioAssets = null;

        public static AssetBundle XmlAssets = null;

        public static AssetBundle CGAssets = null;

        public static WWW CurrentWWW = null;

        public static string CurrentLoadingAssetsInfo = string.Empty;

        /// <summary>
        /// 是否完成初始化
        /// </summary>
        public static bool IsInited = false;

        /// <summary>
        /// 失败
        /// </summary>
        public static bool IsFailed = false;

        private static MonoBehaviour _parent;

        /// <summary>
        /// 通用回调
        /// </summary>
        private static CommonSettings.VoidCallBack _callback;

        private static List<FileInfo> _tobeLoadResources = new List<FileInfo>();

        private static string[] avaliableExtensions = new string[]
        {
                    ".jpg",
                    ".png",
                    ".xml",
                    ".ogg",
                    ".mp3",
                    ".wav"
        };

        private static int _currentLoadResource = 0;

        //        public static string baseUrl
        //		{
        //			get
        //			{
        //				if (Application.platform == RuntimePlatform.Android)
        //				{
        //					return "jar:file://" + Application.dataPath + "!/assets/";
        //				}
        //				if (Application.platform == RuntimePlatform.IPhonePlayer)
        //				{
        //					return "file://" + Application.dataPath + "/Raw/";
        //				}
        //				if (Application.platform == RuntimePlatform.WindowsPlayer || Application.isEditor)
        //				{
        //					return "file://" + Application.dataPath + "/StreamingAssets/";
        //				}
        //				if (Application.isWebPlayer)
        //				{
        //					return "StreamingAssets/";
        //				}
        //				return "file://" + Application.dataPath + "/StreamingAssets/";
        //			}
        //		}

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="callback"></param>
        public static void Init(MonoBehaviour parent, CommonSettings.VoidCallBack callback)
        {
            AssetBundleManager._parent = parent;
            AssetBundleManager._callback = callback;
            if (CommonSettings.MOD_EDITOR_MODE)
            {
                AssetBundleManager.LoadResource("Assets/Mod/Audios");
                AssetBundleManager.LoadResource("Assets/Mod/BattleBg");
                AssetBundleManager.LoadResource("Assets/Mod/CGs");
                AssetBundleManager.LoadResource("Assets/Mod/Heads");
                AssetBundleManager.LoadResource("Assets/Mod/Icons");
                AssetBundleManager.LoadResource("Assets/Mod/Items");
                AssetBundleManager.LoadResource("Assets/Mod/Maps");
            }   
        }

        public static void LoadResource(string dir)
        {
            foreach (FileInfo fileInfo in new DirectoryInfo(dir).GetFiles())
            {
                if (AssetBundleManager.avaliableExtensions.Contains(fileInfo.Extension))
                {
                    AssetBundleManager._tobeLoadResources.Add(fileInfo);
                }
            }
            AssetBundleManager._currentLoadResource = 0;
            AssetBundleManager.LoadNextResource();
        }

        public static void LoadNextResource()
        {
            if (AssetBundleManager._currentLoadResource >= AssetBundleManager._tobeLoadResources.Count)
            {
                AssetBundleManager._callback();
                return;
            }
            FileInfo fileInfo = AssetBundleManager._tobeLoadResources[AssetBundleManager._currentLoadResource];
            if (AssetBundleManager._tobeLoadResources.Count > 0)
            {
                ResourceManager.progress = (float)AssetBundleManager._currentLoadResource / (float)AssetBundleManager._tobeLoadResources.Count;
                ResourceManager.detail = "正在载入 " + fileInfo.DirectoryName.Split(new char[]
                {
                            '\\'
                }).Last<string>() + "\\" + fileInfo.Name;
            }
            if (fileInfo.Extension == ".png" || fileInfo.Extension == ".jpg")
            {
                AssetBundleManager._parent.StartCoroutine(ModEditorResourceManager.LoadSprite(AssetBundleManager._parent.GetComponent<LoadingUI>(), fileInfo.DirectoryName.Split(new char[]
                {
                            '\\'
                }).Last<string>(), fileInfo, delegate
                {
                    AssetBundleManager.LoadNextResource();
                }));
            }
            else if (fileInfo.Extension == ".ogg")
            {
                AssetBundleManager._parent.StartCoroutine(ModEditorResourceManager.LoadAudio(AssetBundleManager._parent.GetComponent<LoadingUI>(), fileInfo.DirectoryName.Split(new char[]
                {
                            '\\'
                }).Last<string>(), fileInfo, delegate
                {
                    AssetBundleManager.LoadNextResource();
                }));
            }
            AssetBundleManager._currentLoadResource++;
        }

        //		// Token: 0x0600001D RID: 29 RVA: 0x00002634 File Offset: 0x00000834
        //		public static Sprite GetMap(string url)
        //		{
        //			if (AssetBundleManager.MapAssets != null)
        //			{
        //				return AssetBundleManager.MapAssets.LoadAsset<Sprite>(url);
        //			}
        //			return null;
        //		}

        //		// Token: 0x0600001E RID: 30 RVA: 0x00002654 File Offset: 0x00000854
        //		public static Sprite GetBattleBg(string url)
        //		{
        //			if (AssetBundleManager.BattleAssets != null)
        //			{
        //				return AssetBundleManager.BattleAssets.LoadAsset<Sprite>(url);
        //			}
        //			return null;
        //		}

        //		// Token: 0x0600001F RID: 31 RVA: 0x00002674 File Offset: 0x00000874
        //		public static AudioClip GetAudio(string url)
        //		{
        //			if (AssetBundleManager.AudioAssets != null)
        //			{
        //				return AssetBundleManager.AudioAssets.LoadAsset<AudioClip>(url);
        //			}
        //			return null;
        //		}

        //		// Token: 0x06000020 RID: 32 RVA: 0x00002694 File Offset: 0x00000894
        //		public static Sprite GetCG(string url)
        //		{
        //			if (AssetBundleManager.CGAssets != null)
        //			{
        //				return AssetBundleManager.CGAssets.LoadAsset<Sprite>(url);
        //			}
        //			return null;
        //		}

        //		// Token: 0x06000021 RID: 33 RVA: 0x000026B4 File Offset: 0x000008B4
        //		public static string GetXml(string url)
        //		{
        //			if (AssetBundleManager.XmlAssets != null)
        //			{
        //				return (AssetBundleManager.XmlAssets.LoadAsset(url) as TextAsset).text;
        //			}
        //			return null;
        //		}
    }
}
