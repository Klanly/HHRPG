using System;
using System.Collections;
//using cn.sharesdk.unity3d;
//using Umeng;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject savePanelObj;

    public GameObject musicPanelObj;

    public GameObject logoObj;

    public GameObject infoTextObj;

    public GameObject versionTextObj;

    public GameObject confirmButtonObj;

    public GameObject uiCanvas;

    public GameObject versionCheckCanvas;

    public GameObject buttonShareObj;

    public GameObject messageBoxObj;

    public GameObject dotImageObj;

    private static bool startFlag;

    public GameObject ClearAllConfirmPanelObj;

    private int _clearAllCount;

    private static bool _mod_editor_checked;

    public static bool Touched;


    private void Start()
    {
        //执行预加载数据
        //if (CommonSettings.MOD_EDITOR_MODE)
        //{
        //    if (!MainMenu._mod_editor_checked)
        //    {
        //        ResourceChecker.CheckAll(new FileLogger());
        //        MainMenu._mod_editor_checked = true;
        //    }
        //}
        //GameObject.Find("ButtonIOSPinglun").SetActive(false);
        //if (Application.isMobilePlatform)
        //{
        //    this.shareTextObj.GetComponent<Text>().text = "分享给朋友";
        //}
        //else
        //{
        //    this.shareTextObj.GetComponent<Text>().text = "分享/下载手机版";
        //}
        //if (!MainMenu.startFlag)
        //{
        //    if (Application.platform == RuntimePlatform.IPhonePlayer)
        //    {
        //        Analytics.StartWithAppKeyAndChannelId("5598d48c67e58e429f0015f4", "IPhone");
        //    }
        //    else if (Application.platform == RuntimePlatform.Android)
        //    {
        //        Analytics.StartWithAppKeyAndChannelId("5593b1ab67e58e880a000d12", "Android");
        //    }
        //    ShareSDK.setCallbackObjectName("MainMenu");
        //    if (Application.platform == RuntimePlatform.IPhonePlayer)
        //    {
        //        ShareSDK.open("88ec7d211838");
        //    }
        //    else if (Application.platform == RuntimePlatform.Android)
        //    {
        //    }
        //    MainMenu.startFlag = true;
        //}
        //this.uiCanvas.gameObject.SetActive(false);
        //this.versionCheckCanvas.gameObject.SetActive(true);
        //this.confirmButtonObj.gameObject.SetActive(false);
        //this.versionTextObj.GetComponent<Text>().text = string.Format("V{0}", "1.0.0.5");
        //if (CommonSettings.MOD_EDITOR_MODE)
        //{
        //    Text component = this.versionTextObj.GetComponent<Text>();
        //    component.text += " MOD开发版";
        //}
        //if (GlobalData.ShareTag == 0 && Application.isMobilePlatform)
        //{
        //    this.dotImageObj.SetActive(true);
        //}
        //else
        //{
        //    this.dotImageObj.SetActive(false);
        //}
        //this.ShowMainMenu();
    }

    /// <summary>
    /// 新游戏
    /// </summary>
    public void OnNewGame()
    {
        //新建角色  读取陪住初始数据
        //RuntimeData.Instance.Init();
        //LoadingUI.Load("RollRole");
        Player player = new Player();

        Player.CurrentPlayer = player;
    }

    private void OnRegisterSuccess(PlayerResult result)
    {
        //var gameInstance = GameInstance.Singleton;
        //eventRegister.Invoke();
    }

    private void OnError(string error)
    {
        //var gameInstance = GameInstance.Singleton;
        //gameInstance.OnGameServiceError(error);
        //eventError.Invoke();
    }

    /// <summary>
    /// 读档
    /// </summary>
    public void OnLoad()
    {
        //this.savePanelObj.GetComponent<SavePanelUI>().Show(SavePanelMode.LOAD);
    }

    //public void OnMusic()
    //{
    //	this.musicPanelObj.GetComponent<MusicPanelUI>().Show();
    //}

    //public void OnGameFinButton()
    //{
    //	Application.LoadLevel("MainMenu");
    //}

    //public void OnDebugClearAll()
    //{
    //	if (CommonSettings.DEBUG_CONSOLE)
    //	{
    //		PlayerPrefs.DeleteAll();
    //	}
    //	else
    //	{
    //		this._clearAllCount++;
    //		if (this._clearAllCount > 10)
    //		{
    //			this.ClearAllConfirmPanelObj.SetActive(true);
    //		}
    //	}
    //}

    /// <summary>
    /// 确认删除
    /// </summary>
    public void OnConfirmClear()
    {
        //PlayerPrefs.DeleteAll();
        //this.ClearAllConfirmPanelObj.SetActive(false);
    }

    /// <summary>
    /// 取消删除
    /// </summary>
    public void OnCancelClear()
    {
        //this.ClearAllConfirmPanelObj.SetActive(false);
        //this._clearAllCount = 0;
    }

    /// <summary>
    /// 显示主菜单
    /// </summary>
    private void ShowMainMenu()
    {
        //this.uiCanvas.gameObject.SetActive(true);
        //this.versionCheckCanvas.gameObject.SetActive(false);
        //if (!RuntimeData.Instance.IsInited)
        //{
        //    RuntimeData.Instance.Init();
        //}
        //AudioManager.Instance.Play("音乐.武侠回忆");
    }

    private void Update()
    {
    }
}
