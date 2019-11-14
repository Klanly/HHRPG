using JyGame;
using System;
using System.Collections;
using System.Collections.Generic;
//using cn.sharesdk.unity3d;
//using Umeng;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        this.MakeBeginningCondition();
        SceneManager.LoadScene("ManageScene");
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

    /// <summary>
    /// 创建角色
    /// </summary>
    private void MakeBeginningCondition()
    {      
        this.makeRole = ResourceManager.Get<Role>("主角").Clone();//赋值
        this.makeMoney = 100;
        this.makeItems = new List<Item>();
        this.makeItems.Add(Item.GetItem("小还丹"));
        this.makeItems.Add(Item.GetItem("小还丹"));
        this.makeItems.Add(Item.GetItem("小还丹"));

        if (RuntimeData.Instance.Round == 1)
        {
            RuntimeData.Instance.GameMode = "normal";
            RuntimeData.Instance.FriendlyFire = false;
        }
        else
        {
            RuntimeData.Instance.GameMode = "normal";
            RuntimeData.Instance.FriendlyFire = false;
        }

        RuntimeData.Instance.Money = this.makeMoney;
        RuntimeData.Instance.Team.Clear();
        RuntimeData.Instance.Follow.Clear();
        RuntimeData.Instance.Team.Add(this.makeRole);
        //RuntimeData.Instance.Items.Clear();
        foreach (Item item in this.makeItems)
        {
            Item item2 = item;
            // RuntimeData.Instance.addItem(item2, 1);
        }
        List<string> list = new List<string>();
        list.Clear();
        //switch (RuntimeData.Instance.Round)
        //{
        //    case 1:
        //        break;
        //    case 2:
        //        list.Add("鲁连荣");
        //        list.Add("冲虚道长");
        //        list.Add("方证大师");
        //        list.Add("灭绝师太");
        //        list.Add("张翠山");
        //        list.Add("宋远桥");
        //        list.Add("韦一笑");
        //        list.Add("仪清");
        //        list.Add("何太冲");
        //        list.Add("哑仆");
        //        list.Add("温方达");
        //        list.Add("温方义");
        //        list.Add("温方山");
        //        list.Add("温方施");
        //        list.Add("温方悟");
        //        list.Add("安小慧");
        //        list.Add("阿九");
        //        break;
        //    case 3:
        //        list.Add("紫衫龙王");
        //        list.Add("白眉鹰王");
        //        list.Add("商剑鸣");
        //        list.Add("杨逍");
        //        list.Add("范遥");
        //        list.Add("霍都");
        //        list.Add("孙不二");
        //        list.Add("龙岛主");
        //        list.Add("木岛主");
        //        list.Add("善勇");
        //        break;
        //    case 4:
        //        list.Add("白自在");
        //        list.Add("向问天");
        //        list.Add("丁春秋");
        //        list.Add("成昆");
        //        list.Add("段延庆");
        //        list.Add("丘处机");
        //        list.Add("欧阳锋");
        //        break;
        //    default:
        //        list.Add("任我行");
        //        list.Add("王重阳");
        //        list.Add("林朝英");
        //        list.Add("归辛树");
        //        list.Add("玉真子");
        //        list.Add("慕容博");
        //        list.Add("卓一航");
        //        list.Add("谢逊");
        //        list.Add("虚竹");
        //        break;
        //}
        if (list.Count > 0)
        {
            //RuntimeData.Instance.Team.Add(ResourceManager.Get<Role>(list[Tools.GetRandomInt(0, list.Count) % list.Count]).Clone());
        }
        RuntimeData.Instance.gameEngine.NewGameJump();
    }
}
