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
        Reset();
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
       // this.versionTextObj.GetComponent<Text>().text = string.Format("V{0}", "1.0.0.5");

        //this.ShowMainMenu();
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

    private void Reset()
    {
        this.MakeBeginningCondition();
        //this.MakeRandomCondition();
        //this.ShowBeginningCondition();
    }

    /// <summary>
    /// 显示角色信息
    /// </summary>
    private void ShowBeginningCondition()
    {
        //this.rolePanel.Show(this.makeRole, null, true);
    }

    // Token: 0x06000572 RID: 1394 RVA: 0x00030620 File Offset: 0x0002E820
    private void MakeRandomCondition()
    {
        string[] array = new string[]
        {
                "gengu",
                "bili",
                "fuyuan",
                "shenfa",
                "dingli",
                "wuxing",
                "quanzhang",
                "jianfa",
                "daofa",
                "qimen"
        };
        for (int i = 0; i < 3; i++)
        {
            //int randomInt = Tools.GetRandomInt(0, array.Length - 1);
            //string type = array[randomInt];
            //CommonSettings.adjustAttr(this.makeRole, type, 10);
        }
        for (int j = 0; j < 10; j++)
        {
            //int randomInt2 = Tools.GetRandomInt(0, array.Length - 1);
            //string type2 = array[randomInt2];
           // CommonSettings.adjustAttr(this.makeRole, type2, 1);
        }
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    private void MakeBeginningCondition()
    {      
        this.makeRole = ResourceManager.Get<Role>("主角").Clone();
        this.makeMoney = 100;
        this.makeItems = new List<Item>();
        //this.makeItems.Add(Item.GetItem("小还丹"));
        // this.makeItems.Add(Item.GetItem("小还丹"));
        // this.makeItems.Add(Item.GetItem("小还丹"));
        //switch (this.results[0])
        //{
        //    case 0:
        //        this.makeMoney += 5000;
        //       // CommonSettings.adjustAttr(this.makeRole, "bili", -5);
        //        //this.makeItems.Add(Item.GetItem("黑玉断续膏"));
        //        //this.makeItems.Add(Item.GetItem("九转熊蛇丸"));
        //        //this.makeItems.Add(Item.GetItem("金丝道袍"));
        //        //this.makeItems.Add(Item.GetItem("金头箍"));
        //        //this.makeRole.Animation = "zydx";
        //        break;
        //    case 1:
        //        {
        //            //CommonSettings.adjustAttr(this.makeRole, "shenfa", 15);
        //            //CommonSettings.adjustAttr(this.makeRole, "dingli", -2);
        //            //CommonSettings.adjustAttr(this.makeRole, "quanzhang", 15);
        //            Role role = this.makeRole;
        //           // role.TalentValue += "#猎人";
        //           // this.makeRole.Animation = "caoyuan";
        //            break;
        //        }
        //    case 2:
        //        //CommonSettings.adjustAttr(this.makeRole, "fuyuan", 3);
        //        //CommonSettings.adjustAttr(this.makeRole, "bili", -3);
        //        //CommonSettings.adjustAttr(this.makeRole, "dingli", 2);
        //        //CommonSettings.adjustAttr(this.makeRole, "wuxing", 20);
        //        //CommonSettings.adjustAttr(this.makeRole, "jianfa", 2);
        //        //CommonSettings.adjustAttr(this.makeRole, "gengu", 2);
        //      //  this.makeItems.Add(Item.GetItem("银手镯"));
        //        this.makeMoney += 100;
        //       // this.makeRole.Animation = "huodu";
        //        break;
        //    case 3:
        //        //CommonSettings.adjustAttr(this.makeRole, "fuyuan", -5);
        //        //CommonSettings.adjustAttr(this.makeRole, "bili", 12);
        //        //CommonSettings.adjustAttr(this.makeRole, "daofa", 15);
        //        //CommonSettings.adjustAttr(this.makeRole, "qimen", 12);
        //        //this.makeItems.Add(Item.GetItem("草帽"));
        //       // this.makeRole.Animation = "shijing";
        //        this.makeMoney = 0;
        //        break;
        //    case 4:
        //        {
        //            //CommonSettings.adjustAttr(this.makeRole, "wuxing", 35);
        //            //CommonSettings.adjustAttr(this.makeRole, "dingli", 10);
        //            //CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //            Role role2 = this.makeRole;
        //          //  role2.TalentValue += "#神经病";
        //           // this.makeRole.Animation = "fengzi";
        //            break;
        //        }
        //    case 5:
        //        //CommonSettings.adjustAttr(this.makeRole, "wuxing", 20);
        //        //CommonSettings.adjustAttr(this.makeRole, "bili", 1);
        //        //CommonSettings.adjustAttr(this.makeRole, "shenfa", -10);
        //        //CommonSettings.adjustAttr(this.makeRole, "gengu", -5);
        //        //this.makeRole.Animation = "xiake";
        //        break;
        //}
        //switch (this.results[1])
        //{
        //    case 0:
        //        this.makeMoney += 1000;
        //        break;
        //    case 1:
        //      //  CommonSettings.adjustAttr(this.makeRole, "fuyuan", 15);
        //        break;
        //    case 2:
        //      //  CommonSettings.adjustAttr(this.makeRole, "dingli", 15);
        //        break;
        //    case 3:
        //      //  CommonSettings.adjustAttr(this.makeRole, "shenfa", 15);
        //        break;
        //    case 4:
        //        {
        //            Role role3 = this.makeRole;
        //            //role3.TalentValue += "#自我主义";
        //            break;
        //        }
        //}
        //switch (this.results[2])
        //{
        //    case 0:
        //       // CommonSettings.adjustAttr(this.makeRole, "dingli", 9);
        //        break;
        //    case 1:
        //       // CommonSettings.adjustAttr(this.makeRole, "gengu", 6);
        //       // CommonSettings.adjustAttr(this.makeRole, "bili", 6);
        //        break;
        //    case 2:
        //      //  CommonSettings.adjustAttr(this.makeRole, "wuxing", 10);
        //        break;
        //    case 3:
        //      //  CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //        break;
        //    case 4:
        //        {
        //            Role role4 = this.makeRole;
        //         //   role4.TalentValue += "#好色";
        //            break;
        //        }
        //}
        //switch (this.results[3])
        //{
        //    case 0:
        //        //CommonSettings.adjustAttr(this.makeRole, "quanzhang", 10);
        //        break;
        //    case 1:
        //      //  CommonSettings.adjustAttr(this.makeRole, "jianfa", 10);
        //        break;
        //    case 2:
        //       // CommonSettings.adjustAttr(this.makeRole, "daofa", 20);
        //        break;
        //    case 3:
        //       // CommonSettings.adjustAttr(this.makeRole, "qimen", 20);
        //        break;
        //}
        //switch (this.results[4])
        //{
        //    case 0:
        //      //  CommonSettings.adjustAttr(this.makeRole, "wuxing", 5);
        //        break;
        //    case 1:
        //       // CommonSettings.adjustAttr(this.makeRole, "dingli", 5);
        //        break;
        //    case 2:
        //       // CommonSettings.adjustAttr(this.makeRole, "fuyuan", 5);
        //       // CommonSettings.adjustAttr(this.makeRole, "gengu", 5);
        //        break;
        //    case 3:
        //       // CommonSettings.adjustAttr(this.makeRole, "quanzhang", 6);
        //       // CommonSettings.adjustAttr(this.makeRole, "bili", 6);
        //        break;
        //    case 4:
        //       // CommonSettings.adjustAttr(this.makeRole, "dingli", 10);
        //        break;
        //}
        //switch (this.results[5])
        //{
        //    case 0:
        //       // CommonSettings.adjustAttr(this.makeRole, "wuxing", 5);
        //       // CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //        break;
        //    case 1:
        //       // CommonSettings.adjustAttr(this.makeRole, "wuxing", -10);
        //       // CommonSettings.adjustAttr(this.makeRole, "fuyuan", 15);
        //       // CommonSettings.adjustAttr(this.makeRole, "bili", 5);
        //        break;
        //    case 2:
        //      //  CommonSettings.adjustAttr(this.makeRole, "wuxing", 5);
        //      //  CommonSettings.adjustAttr(this.makeRole, "dingli", 5);
        //        break;
        //    case 3:
        //      //  CommonSettings.adjustAttr(this.makeRole, "wuxing", 10);
        //        break;
        //    case 4:
        //      //  CommonSettings.adjustAttr(this.makeRole, "jianfa", 10);
        //      //  CommonSettings.adjustAttr(this.makeRole, "dingli", 10);
        //        break;
        //}
        //switch (this.results[6])
        //{
        //    case 0:
        //      //  CommonSettings.adjustAttr(this.makeRole, "bili", 10);
        //      //  CommonSettings.adjustAttr(this.makeRole, "quanzhang", 9);
        //        break;
        //    case 1:
        //      //  CommonSettings.adjustAttr(this.makeRole, "fuyuan", 30);
        //        break;
        //    case 2:
        //      //  CommonSettings.adjustAttr(this.makeRole, "wuxing", 13);
        //      //  CommonSettings.adjustAttr(this.makeRole, "jianfa", 5);
        //      //  CommonSettings.adjustAttr(this.makeRole, "daofa", 5);
        //      //  CommonSettings.adjustAttr(this.makeRole, "quanzhang", 5);
        //       // CommonSettings.adjustAttr(this.makeRole, "qimen", 5);
        //        break;
        //    case 3:
        //       // CommonSettings.adjustAttr(this.makeRole, "gengu", 20);
        //        break;
        //    case 4:
        //      //  this.makeRole.InternalSkills[0].level = 20;
        //      //  CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //     //   this.makeItems.Add(Item.GetItem("松果"));
        //     //   this.makeItems.Add(Item.GetItem("松果"));
        //     //   this.makeItems.Add(Item.GetItem("松果"));
        //        break;
        //    case 5:
        //        //this.makeItems.Add(Item.GetItem("天王保命丹"));
        //        //this.makeItems.Add(Item.GetItem("天王保命丹"));
        //        //this.makeItems.Add(Item.GetItem("天王保命丹"));
        //        //this.makeItems.Add(Item.GetItem("天王保命丹"));
        //        //this.makeItems.Add(Item.GetItem("天王保命丹"));
        //        //this.makeItems.Add(Item.GetItem("天王保命丹"));
        //        break;
        //}
        //if (RuntimeData.Instance.Round == 1)
        //{
        //    switch (this.results[7])
        //    {
        //        case 0:
        //            RuntimeData.Instance.GameMode = "normal";
        //            RuntimeData.Instance.FriendlyFire = false;
        //            break;
        //        case 1:
        //            RuntimeData.Instance.GameMode = "hard";
        //            RuntimeData.Instance.FriendlyFire = true;
        //            break;
        //        case 2:
        //            RuntimeData.Instance.GameMode = "crazy";
        //            RuntimeData.Instance.FriendlyFire = true;
        //            break;
        //    }
        //}
        //else
        //{
        //    int num = this.results[7];
        //    if (num != 0)
        //    {
        //        if (num == 1)
        //        {
        //            RuntimeData.Instance.GameMode = "crazy";
        //            RuntimeData.Instance.FriendlyFire = true;
        //        }
        //    }
        //    else
        //    {
        //        RuntimeData.Instance.GameMode = "hard";
        //        RuntimeData.Instance.FriendlyFire = true;
        //    }
        //}
        //List<string> list = new List<string>();
        //List<string> list2 = new List<string>();
        //list.Clear();
        //list2.Clear();
        //switch (RuntimeData.Instance.Round)
        //{
        //    case 1:
        //        //if (RuntimeData.Instance.GameMode == "normal")
        //        //{
        //        //    //this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //        //    //this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //        //    //this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //        //    //this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //        //    //this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //        //}
        //        break;
        //    case 2:
        //        list.Add("佛光普照");
        //        list.Add("百变千幻云雾十三式秘籍");
        //        list.Add("反两仪刀法");
        //        list.Add("伏魔杖法");
        //        list2.Add("灭仙爪");
        //        list2.Add("倚天剑");
        //        list2.Add("屠龙刀");
        //        list2.Add("打狗棒");
        //        //this.makeItems.Add(Item.GetItem(list[Tools.GetRandomInt(0, list.Count) % list.Count]));
        //        //this.makeItems.Add(Item.GetItem(list2[Tools.GetRandomInt(0, list2.Count) % list2.Count]));
        //        break;
        //    case 3:
        //        list.Add("隔空取物");
        //        list.Add("妙手仁心");
        //        list.Add("飞向天际");
        //        list.Add("血刀");
        //        list2.Add("仙丽雅的项链");
        //        list2.Add("李延宗的项链");
        //        list2.Add("王语嫣的武学概要");
        //        list2.Add("神木王鼎");
        //        //this.makeItems.Add(Item.GetItem(list[Tools.GetRandomInt(0, list.Count) % list.Count]));
        //        //this.makeItems.Add(Item.GetItem(list2[Tools.GetRandomInt(0, list2.Count) % list2.Count]));
        //        break;
        //    default:
        //        list.Add("碎裂的怒吼");
        //        list.Add("沾衣十八跌");
        //        list.Add("灵心慧质");
        //        list.Add("不老长春功法");
        //        list2.Add("仙丽雅的项链");
        //        list2.Add("李延宗的项链");
        //        list2.Add("王语嫣的武学概要");
        //        list2.Add("神木王鼎");
        //        //this.makeItems.Add(Item.GetItem(list[Tools.GetRandomInt(0, list.Count) % list.Count]));
        //        //this.makeItems.Add(Item.GetItem(list2[Tools.GetRandomInt(0, list2.Count) % list2.Count]));
        //        break;
        //}
        //string[] array = RuntimeData.Instance.TrialRoles.Split(new char[]
        //{
        //        '#'
        //});
        //int num2 = array.Length;
        List<string> list3 = new List<string>();
        //if (num2 >= 3)
        //{
        //    if (num2 >= 3 && num2 < 6)
        //    {
        //        //this.makeItems.Add(Item.GetItem("王母蟠桃"));
        //        //this.makeItems.Add(Item.GetItem("道家仙丹"));
        //    }
        //    else if (num2 >= 6 && num2 < 9)
        //    {
        //        //this.makeItems.Add(Item.GetItem("灵心慧质"));
        //        //this.makeItems.Add(Item.GetItem("妙手仁心"));
        //    }
        //    else if (num2 >= 9 && num2 < 12)
        //    {
        //        //this.makeItems.Add(Item.GetItem("素心神剑心得"));
        //        //this.makeItems.Add(Item.GetItem("太极心得手抄本"));
        //        //this.makeItems.Add(Item.GetItem("乾坤大挪移心法"));
        //    }
        //    else if (num2 >= 12 && num2 < 15)
        //    {
        //        //this.makeItems.Add(Item.GetItem("沾衣十八跌"));
        //        //this.makeItems.Add(Item.GetItem("易筋经"));
        //        //this.makeItems.Add(Item.GetItem("厚黑学"));
        //    }
        //    else if (num2 >= 15 && num2 < 20)
        //    {
        //       // this.makeItems.Add(Item.GetItem("武穆遗书"));
        //       // this.makeItems.Add(Item.GetItem("笑傲江湖曲"));
        //    }
        //    else if (num2 >= 20)
        //    {
        //       // this.makeItems.Add(Item.GetItem("真葵花宝典"));
        //    }
        //}
    }

    private void JumpSelectCallback(int rst)
    {
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
        if (rst == 0)
        {
            //RuntimeData.Instance.gameEngine.NewGame();
        }
        else
        {
           // RuntimeData.Instance.gameEngine.NewGameJump();
        }
        base.gameObject.SetActive(false);
    }

    // Token: 0x06000575 RID: 1397 RVA: 0x00031904 File Offset: 0x0002FB04
    public void okButton_Click()
    {
        this.JumpSelectCallback(1);
    }

    // Token: 0x06000576 RID: 1398 RVA: 0x00031910 File Offset: 0x0002FB10
    public void resetButton_Click()
    {
        //AudioManager.Instance.PlayEffect("音效.装备");
        this.Reset();
    }

    public GameObject MultiSelectItemObj;

    private List<string> heads = new List<string>
        {
            "头像.主角",
            "头像.主角3",
            "头像.主角4",
            "头像.魔君",
            "头像.全冠清",
            "头像.李白",
            "头像.林平之瞎",
            "头像.侠客2",
            "头像.归辛树",
            "头像.狄云",
            "头像.独孤求败",
            "头像.陈近南",
            "头像.石中玉",
            "头像.商宝震",
            "头像.尹志平",
            "头像.流浪汉",
            "头像.梁发",
            "头像.卓一航",
            "头像.烟霞神龙",
            "头像.双手开碑",
            "头像.流星赶月",
            "头像.盖七省",
            "头像.公子1",
            "头像.主角2"
        };

    // Token: 0x040003F2 RID: 1010
    private List<int> results = new List<int>();

    // Token: 0x040003F3 RID: 1011
    private Role makeRole;

    // Token: 0x040003F4 RID: 1012
    private int makeMoney;

    // Token: 0x040003F5 RID: 1013
    private List<Item> makeItems;
}
