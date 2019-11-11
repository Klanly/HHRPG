using JyGame;
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

    public void OnLoad()
    {
       // this.savePanelObj.GetComponent<SavePanelUI>().Show(SavePanelMode.LOAD);
    }

    public void OnMusic()
    {
        //this.musicPanelObj.GetComponent<MusicPanelUI>().Show();
    }

    public void OnDeveloper()
    {
        //RuntimeData.Instance.gameEngine.SwitchGameScene("story", "aboutus_main");
    }

    public void OnGameFinButton()
    {
        Application.LoadLevel("MainMenu");
    }

    public void OnDebugClearAll()
    {
        if (CommonSettings.DEBUG_CONSOLE)
        {
            PlayerPrefs.DeleteAll();
        }
        else
        {
            this._clearAllCount++;
            if (this._clearAllCount > 10)
            {
                this.ClearAllConfirmPanelObj.SetActive(true);
            }
        }
    }

    public void OnConfirmClear()
    {
        PlayerPrefs.DeleteAll();
        this.ClearAllConfirmPanelObj.SetActive(false);
    }

    public void OnCancelClear()
    {
        this.ClearAllConfirmPanelObj.SetActive(false);
        this._clearAllCount = 0;
    }

    public void OnIOSPinglunClicked()
    {
        //Tools.openURL("itms-apps://ax.itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id=1021093037");
    }

    private void Start()
    {
        if (CommonSettings.MOD_EDITOR_MODE)
        {
            if (!MainMenu._mod_editor_checked)
            {
               // ResourceChecker.CheckAll(new FileLogger());
                MainMenu._mod_editor_checked = true;
            }
            //this.copyRightTextObj.GetComponent<Text>().text = "版权声明：金庸群侠传X（MOD编辑版）所有非官方发布的MOD，MOD作者负有全部责任。涉及的游戏内容、素材、发布行为，均与汉家松鼠工作室无关。";
        }
        GameObject.Find("ButtonIOSPinglun").SetActive(false);
        if (Application.isMobilePlatform)
        {
            //this.shareTextObj.GetComponent<Text>().text = "分享给朋友";
        }
        else
        {
           // this.shareTextObj.GetComponent<Text>().text = "分享/下载手机版";
        }
        if (!MainMenu.startFlag)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //Analytics.StartWithAppKeyAndChannelId("5598d48c67e58e429f0015f4", "IPhone");
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                //Analytics.StartWithAppKeyAndChannelId("5593b1ab67e58e880a000d12", "Android");
            }
            //ShareSDK.setCallbackObjectName("MainMenu");
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //ShareSDK.open("88ec7d211838");
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
            }
            MainMenu.startFlag = true;
        }
        this.uiCanvas.gameObject.SetActive(false);
        this.versionCheckCanvas.gameObject.SetActive(true);
        this.confirmButtonObj.gameObject.SetActive(false);
        this.versionTextObj.GetComponent<Text>().text = string.Format("V{0}", "1.0.0.5");
        if (CommonSettings.MOD_EDITOR_MODE)
        {
            Text component = this.versionTextObj.GetComponent<Text>();
            component.text += " MOD开发版";
        }
        //if (GlobalData.ShareTag == 0 && Application.isMobilePlatform)
        //{
        //    this.dotImageObj.SetActive(true);
        //}
        //else
        //{
        //    this.dotImageObj.SetActive(false);
        //}
        this.ShowMainMenu();
    }

    //private void ShareResultHandler(ResponseState state, PlatformType type, Hashtable shareInfo, Hashtable error, bool end)
    //{
    //    if (state == ResponseState.Success)
    //    {
    //        if (GlobalData.ShareTag == 0)
    //        {
    //            this.messageBoxObj.GetComponent<MessageBoxUI>().Show("分享成功", "获得20元宝", Color.yellow, null, "确认");
    //            GlobalData.Yuanbao += 20;
    //            GlobalData.ShareTag++;
    //        }
    //        else
    //        {
    //            this.messageBoxObj.GetComponent<MessageBoxUI>().Show("分享成功", "感谢您对于游戏的支持！", Color.yellow, null, "确认");
    //            GlobalData.ShareTag++;
    //        }
    //    }
    //    else
    //    {
    //        this.messageBoxObj.GetComponent<MessageBoxUI>().Show("分享失败", "请重试", Color.red, null, "确认");
    //    }
    //    if (GlobalData.ShareTag == 0 && Application.isMobilePlatform)
    //    {
    //        this.dotImageObj.SetActive(true);
    //    }
    //    else
    //    {
    //        this.dotImageObj.SetActive(false);
    //    }
    //}

    private void ShowMainMenu()
    {
        this.uiCanvas.gameObject.SetActive(true);
        this.versionCheckCanvas.gameObject.SetActive(false);
        if (!RuntimeData.Instance.IsInited)
        {
            RuntimeData.Instance.Init();
        }
        //AudioManager.Instance.Play("音乐.武侠回忆");
    }

    private void JudgeVersion(string versionInfo)
    {
        if (versionInfo.Contains("1.0.0.5"))
        {
            this.ShowMainMenu();
        }
        else
        {
            this.infoTextObj.GetComponent<Text>().text = "当前版本已过期，请更新版本。\n安卓设备需要重新下载并安装APK，网页版需要刷新页面。（存档不会删除）\n详情请访问游戏官网 <color='red'>http://www.jy-x.com</color>";
        }
    }

    private IEnumerator TouchServer(CommonSettings.StringCallBack callback)
    {
        string uuid = string.Concat(new string[]
        {
            SystemInfo.operatingSystem,
            "_",
            SystemInfo.deviceUniqueIdentifier,
            "_",
            SystemInfo.deviceName,
            "_1.0.0.5"
        });
        uuid = uuid.Replace(" ", string.Empty);
        string url = "http://www.jy-x.com/jygame/touchserver/touch.php?id=" + WWW.EscapeURL(uuid);
        Debug.Log(url);
        WWW www = new WWW(url);
        MainMenu.Touched = true;
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            callback(www.text);
            www.Dispose();
        }
        else
        {
            this.infoTextObj.GetComponent<Text>().text = "网络连接出错，点击重试";
            this.confirmButtonObj.gameObject.SetActive(true);
            base.StartCoroutine(this.TouchServer(new CommonSettings.StringCallBack(this.JudgeVersion)));
        }
        yield break;
    }

    public void ErrorConfirmButtonClicked()
    {
        this.confirmButtonObj.gameObject.SetActive(false);
        this.infoTextObj.GetComponent<Text>().text = "正在校验版本，请稍后....";
    }

    public void OnFourmClicked()
    {
        //Tools.openURL("http://tieba.baidu.com/f?ie=utf-8&kw=%E6%B1%89%E5%AE%B6%E6%9D%BE%E9%BC%A0");
    }

    public void OnHomepageClicked()
    {
        //Tools.openURL("http://www.jy-x.com");
    }

    private void Update()
    {
    }

    public void Share()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("app_id", "1104678535");
                hashtable.Add("app_key", "ypJWDImxjGsRUkLy");
                //ShareSDK.setPlatformConfig(PlatformType.QZone, hashtable);
                //ShareSDK.setPlatformConfig(PlatformType.QQ, hashtable);
                Hashtable hashtable2 = new Hashtable();
                hashtable2.Add("app_id", "wx97e4029b896a420f");
                hashtable2.Add("app_key", "9963a345d03f80c4f499df3eb799977a");
                //ShareSDK.setPlatformConfig(PlatformType.WeChatFav, hashtable2);
                //ShareSDK.setPlatformConfig(PlatformType.WeChatSession, hashtable2);
                //ShareSDK.setPlatformConfig(PlatformType.WeChatTimeline, hashtable2);
            }
            Hashtable hashtable3 = new Hashtable();
            hashtable3["title"] = "《金庸群侠传X》—高自由度独立游戏，可玩一百遍！";
            hashtable3["content"] = "高自由度！开放地图，随意探索；高养成性！50+可加入队友，共闯江湖；高策略性！经典战棋，特色天赋组合；高代入感！原创剧情，金庸江湖。";
            hashtable3["description"] = "高自由度！开放地图，随意探索；高养成性！50+可加入队友，共闯江湖；高策略性！经典战棋，特色天赋组合；高代入感！原创剧情，金庸江湖。";
            hashtable3["image"] = "http://www.jy-x.com/jygame/share.png";
            hashtable3["url"] = "http://www.jy-x.com/jygame/share.html";
            hashtable3["type"] = Convert.ToString(2);
            hashtable3["site"] = "金庸群侠传X";
            //ShareResultEvent resultHandler = new ShareResultEvent(this.ShareResultHandler);
            //ShareSDK.showShareMenu(null, hashtable3, 100, 100, MenuArrowDirection.Up, resultHandler);
        }
        else
        {
           // this.sharePanelObj.SetActive(true);
        }
    }
}
