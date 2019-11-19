using System;
using UnityEngine;

namespace JyGame
{
	public class AudioManager : MonoBehaviour
	{
        public AudioSource audioMgr;

        public AudioSource[] effectChannels;

        private string currentMusicKey = string.Empty;

        private static AudioManager instance;

        private static int effectChannelIndex;

        public static AudioManager Instance
		{
			get
			{
				if (!RuntimeData.Instance.IsInited)
				{
					RuntimeData.Instance.Init();
				}
				if (AudioManager.instance == null)
				{
					GameObject original = Resources.Load<GameObject>("UI/AudioManagerObj");
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
					AudioManager.instance = gameObject.GetComponent<AudioManager>();
				}
				return AudioManager.instance;
			}
		}

		private void Awake()
		{
			if (AudioManager.instance != null && AudioManager.instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				AudioManager.instance = this;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		private void Start()
		{
			//this.Mute(!Configer.IsMusicOn);
			//this.MuteEffect(!Configer.IsEffectOn);
		}

		public void Play(string key)
		{
			if (!this.currentMusicKey.Equals(key))
			{
                string filePath = "Audios/" + key;
                 AudioClip music = Resources.Load(filePath) as AudioClip;
                if (music == null)
                {
                    return;
                }
                this.audioMgr.clip = music;
                this.audioMgr.Play();
				this.currentMusicKey = key;
			}
		}

		public void PlayEffect(string key)
		{
			AudioManager.effectChannelIndex++;
			if (AudioManager.effectChannelIndex >= this.effectChannels.Length)
			{
				AudioManager.effectChannelIndex = 0;
			}
			//AudioClip music = Resource.GetMusic(key);
			//if (music == null)
			//{
			//	return;
			//}
			//this.effectChannels[AudioManager.effectChannelIndex].clip = music;
			this.effectChannels[AudioManager.effectChannelIndex].Play();
		}

		public void PlayRandomEffect(string[] paths)
		{
			this.PlayEffect(paths[Tools.GetRandomInt(0, paths.Length - 1)]);
		}

		public void Stop()
		{
			this.audioMgr.Stop();
			this.currentMusicKey = string.Empty;
			Debug.Log("Stop background music");
		}

		public void Mute(bool isMute)
		{
			this.audioMgr.mute = isMute;
		}

		public void MuteEffect(bool isMute)
		{
			foreach (AudioSource audioSource in this.effectChannels)
			{
				audioSource.mute = isMute;
			}
		}
	}
}
