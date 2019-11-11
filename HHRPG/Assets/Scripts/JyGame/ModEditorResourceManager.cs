using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JyGame
{
	
	public class ModEditorResourceManager
	{
        public static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

        public static Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();

        public static Sprite GetSprite(string path)
		{
			if (ModEditorResourceManager.sprites.ContainsKey(path))
			{
				return ModEditorResourceManager.sprites[path];
			}
			return null;
		}

		public static AudioClip GetAudioClip(string path)
		{
			if (ModEditorResourceManager.audios.ContainsKey(path))
			{
				return ModEditorResourceManager.audios[path];
			}
			return null;
		}

		public static IEnumerator LoadSprite(LoadingUI ui, string dir, FileInfo file, CommonSettings.VoidCallBack callback)
		{
			WWW www = new WWW("file://" + file.FullName);
			yield return www;
			if (!string.IsNullOrEmpty(www.error))
			{
				Debug.LogError(www.error);
			}
			else
			{
				string key = dir + "/" + file.Name.Split(new char[]
				{
					'.'
				})[0];
				if (!ModEditorResourceManager.sprites.ContainsKey(key))
				{
					Sprite tmp = Sprite.Create(www.texture, new Rect(0f, 0f, (float)www.texture.width, (float)www.texture.height), new Vector2(0f, 0f), 1f);
					ModEditorResourceManager.sprites.Add(key, tmp);
				}
				callback();
			}
			www.Dispose();
			yield break;
		}

		public static IEnumerator LoadAudio(LoadingUI ui, string dir, FileInfo file, CommonSettings.VoidCallBack callback)
		{
			WWW www = new WWW("file://" + file.FullName);
			yield return www;
			if (!string.IsNullOrEmpty(www.error))
			{
				Debug.LogError(www.error);
			}
			else
			{
				string key = dir + "/" + file.Name.Split(new char[]
				{
					'.'
				})[0];
				if (!ModEditorResourceManager.audios.ContainsKey(key))
				{
					ModEditorResourceManager.audios.Add(key, www.GetAudioClip());
				}
				callback();
			}
			www.Dispose();
			yield break;
		}
	}
}
