using System;
using System.Collections;
using System.Collections.Generic;
//using JyGame;
using UnityEngine;
using UnityEngine.UI;


public class LoadingUI : MonoBehaviour
{
    public static string LoadingLevel = "MainMenu";

    public GameObject ProgressSliderObj;

    public GameObject ProgressTextObj;

    public GameObject DetailTextObj;

    public GameObject BackgroundObj;

    public GameObject SuggestTipObj;

    public GameObject JumpButtonObj;

    private static List<string> _randomMaps = new List<string>();

    private static List<string> _suggestTips = new List<string>();

    public static bool IsResourceLoaded = false;

    private AsyncOperation async;

    private void Start()
    {
        //this.ShowTipsAndBg();
        //if (LoadingUI.LoadingLevel == "Battle")
        //{
        //    //Battle battleSelectRole_GeneratedBattle = RuntimeData.Instance.gameEngine.BattleSelectRole_GeneratedBattle;
        //    //base.StartCoroutine(ResourcePool.Load(battleSelectRole_GeneratedBattle, delegate
        //    //{
        //    //	base.StartCoroutine(this.LoadScene());
        //    //}));
        //}
        //else if (LoadingUI.LoadingLevel == "MainMenu")
        //{
        //    //base.StartCoroutine(ResourceManager.Init2(delegate
        //    //{
        //    //    base.StartCoroutine(this.LoadScene());
        //    //}));
        //}
        //else
        //{
        //    base.StartCoroutine(this.LoadSceneWithProgress());
        //}
    }

    public static void Load(string sceneName)
	{
		LoadingUI.LoadingLevel = sceneName;
		Application.LoadLevel("Loading");
	}

	public Slider ProgressSlider
	{
		get
		{
			return this.ProgressSliderObj.GetComponent<Slider>();
		}
	}

	public Text ProgressText
	{
		get
		{
			return this.ProgressTextObj.GetComponent<Text>();
		}
	}

	public Text DetailText
	{
		get
		{
			return this.DetailTextObj.GetComponent<Text>();
		}
	}

    /// <summary>
    /// 显示提示和背景
    /// </summary>
	private void ShowTipsAndBg()
	{
		if (LoadingUI._randomMaps.Count > 0)
		{
			//this.BackgroundObj.GetComponent<Image>().sprite = Resource.GetImage(LoadingUI._randomMaps[Tools.GetRandomInt(0, LoadingUI._randomMaps.Count - 1)], false);
		}
		if (LoadingUI._suggestTips.Count > 0)
		{
			//this.SuggestTipObj.GetComponent<Text>().text = LoadingUI._suggestTips[Tools.GetRandomInt(0, LoadingUI._suggestTips.Count - 1)];
			this.SuggestTipObj.SetActive(true);
		}
		else
		{
			this.SuggestTipObj.SetActive(false);
		}
	}

	private IEnumerator LoadScene()
	{
		this.async = Application.LoadLevelAsync(LoadingUI.LoadingLevel);
		yield return this.async;
		yield break;
	}

	private IEnumerator LoadSceneWithProgress()
	{
		this.DetailText.text = "正在努力为您加载..";
		AsyncOperation op = Application.LoadLevelAsync(LoadingUI.LoadingLevel);
		while (!op.isDone)
		{
			this.ProgressSlider.value = op.progress;
			this.ProgressText.text = string.Format("{0:F0}%", op.progress * 100f);
			yield return 0;
		}
		yield break;
	}

	//private void LoadAssetBundles(CommonSettings.VoidCallBack callback)
	//{
	//	if (!CommonSettings.MOD_EDITOR_MODE)
	//	{
	//		this.loadingAssetBundle = true;
	//	}
	//	AssetBundleManager.Init(this, callback);
	//}

	private void Update()
	{
		float num;
        if (LoadingUI.LoadingLevel == "MainMenu")
        {
            //num = ResourceManager.progress;
            //this.DetailText.text = ResourceManager.detail;
            //this.ProgressText.text = string.Format("{0:F0}%", num * 100f);
            //this.ProgressSlider.value = num;
        }
        else if (LoadingUI.LoadingLevel == "Battle")
        {
            //num = ResourcePool.GetLoadProgress();
            this.DetailText.text = "正在载入战斗...";
            //this.ProgressText.text = string.Format("{0:F0}%", num * 100f);
            //this.ProgressSlider.value = num;
        }
    }

	public void Show(float progress, string msg)
	{
		this.DetailText.text = msg;
		this.ProgressText.text = string.Format("{0:F0}%", progress * 100f);
		this.ProgressSlider.value = progress;
	}
}
