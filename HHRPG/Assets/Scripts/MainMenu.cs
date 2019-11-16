using JyGame;
using System;
using System.Collections;
using System.Collections.Generic;
//using cn.sharesdk.unity3d;
//using Umeng;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YouYou;

public class MainMenu : MonoBehaviour
{
    private Role makeRole;

    private int makeMoney;

    private List<Item> makeItems;

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
        RuntimeData.Instance.Init();
        RuntimeData.Instance.gameEngine.NewGame();
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
        SceneManager.LoadScene("MainMenu");
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

    private void Start()
    {
        //if (!MainMenu.startFlag)
        //{
        //    MainMenu.startFlag = true;
        //}
        //this.uiCanvas.gameObject.SetActive(false);
       // this.versionCheckCanvas.gameObject.SetActive(true);
       // this.confirmButtonObj.gameObject.SetActive(false);
       // this.versionTextObj.GetComponent<Text>().text = string.Format("V{0}", "1.0.0.5");//版本号

        //this.ShowMainMenu();//显示主菜单
    }

    /// <summary>
    /// 显示主选单
    /// </summary>
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

    private void Update()
    {
    }
}
