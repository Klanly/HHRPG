using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JyGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YouYou;

public class MapUI : MonoBehaviour
{
    private static Sprite prevSprite;

    public GameObject BigMap;

    public GameObject LocationObjPrefab;

    public GameObject EventConfirmPanel;

    /// <summary>
    /// 大地图面板
    /// </summary>
    public GameObject BigMapPanel;

    public GameObject MapPanel;

    public GameObject MapRolePanel;

    public GameObject MapRoleObjPrefab;

    public GameObject LocationInfoText;

    public GameObject TimeInfoText;

    public GameObject DialogPanel;

    public GameObject ButtonPanel;

    public GameObject BackgroundImage;

    public GameObject SelectPanel;

    public GameObject ItemPanel;

    public GameObject LogPanel;

    public GameObject NameInputPanel;

    public GameObject UIStatePanelNickText;

    public GameObject UIStatePanelZhoumuText;

    public GameObject UIStatePanelHeadImage;

    public GameObject RoleSelectPanelObj;

    public GameObject TeamPanelObj;

    public GameObject RolePanel;

    public GameObject MultiSelectItemObj;

    public GameObject SystemPanelObj;

    public GameObject ItemDetailPanelObj;

    public GameObject MessageBoxUIObj;

    public GameObject MoneyTextObj;

    public GameObject YuanbaoTextObj;

    public GameObject InfoPanelObj;

    public GameObject RoleStatePanelObj;

    public GameObject AchievementPanelObj;

    public GameObject SkillSelectPanelObj;

    public GameObject MapDescriptionPanelObj;

    /// <summary>
    /// 建议面板
    /// </summary>
    public GameObject SuggestPanelObj;

    public GameObject DailyAwardObj;

    private Story _story;

    private int storyActionIndex;

    private string _storyResult = "0";

    private bool jumpDialogFlag;

    private Map _map;

    public MessageBoxUI messageBox
    {
        get
        {
            return this.MessageBoxUIObj.GetComponent<MessageBoxUI>();
        }
    }

    //// Token: 0x17000159 RID: 345
    //// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00028000 File Offset: 0x00026200
    //public SelectMenu selectMenu
    //{
    //	get
    //	{
    //		return this.SelectPanel.transform.FindChild("SelectMenu").GetComponent<SelectMenu>();
    //	}
    //}

    //// Token: 0x1700015A RID: 346
    //// (get) Token: 0x060004C9 RID: 1225 RVA: 0x0002801C File Offset: 0x0002621C
    //public ItemMenu itemMenu
    //{
    //	get
    //	{
    //		return this.ItemPanel.GetComponent<ItemMenu>();
    //	}
    //}

    //// Token: 0x1700015B RID: 347
    //// (get) Token: 0x060004CA RID: 1226 RVA: 0x0002802C File Offset: 0x0002622C
    //public LogMenu logMenu
    //{
    //	get
    //	{
    //		return this.LogPanel.transform.FindChild("LogMenu").GetComponent<LogMenu>();
    //	}
    //}

    //// Token: 0x1700015C RID: 348
    //// (get) Token: 0x060004CB RID: 1227 RVA: 0x00028048 File Offset: 0x00026248
    //public NameInputPanel nameInputPanel
    //{
    //	get
    //	{
    //		return this.NameInputPanel.GetComponent<NameInputPanel>();
    //	}
    //}

    //public RoleSelectMenu roleSelectMenu
    //{
    //	get
    //	{
    //		return this.RoleSelectPanelObj.transform.FindChild("RoleMenu").GetComponent<RoleSelectMenu>();
    //	}
    //}

    public void LoadMap(int mapName)
	{
		//this.RoleStatePanelObj.GetComponent<RoleStatePanelUI>().Refresh();//角色状态
		//GlobalTrigger currentTrigger = GlobalTrigger.GetCurrentTrigger();
  //      if (currentTrigger != null)
  //      {
  //          //this.LoadStory(currentTrigger.story);
  //          return;
  //      }
        RuntimeData.Instance.CurrentBigMap = mapName.ToString();
        this.Init();
        base.StartCoroutine(this.DrawMap(mapName));
    }

	private void SetMapUIElementVisiable(bool isVisiable)
	{
		this.InfoPanelObj.SetActive(isVisiable);
		this.ButtonPanel.SetActive(isVisiable);
		this.MapPanel.SetActive(isVisiable);
		this.RoleStatePanelObj.SetActive(isVisiable);
	}

	public void LoadStory(int storyID)
	{
        StoryEntity storyEntity = GameEntry.DataTable.DataTableManager.StoryDBModel.Get(storyID);
        Story story = new Story();
        string[] array = storyEntity.Action.Split(',');
        for (int i = 0; i < array.Length; i++)
        {
            string[] array2 =array[i].Split('_');
            StoryAction sa = new StoryAction();
            sa.value = array2[0];
            sa.type = array2[1];
            story.Actions.Add(sa);
        }

        string[] array3 = storyEntity.Result.Split(',');
        for (int i = 0; i < array3.Length; i++)
        {
            string[] array4 = array3[i].Split('_');
            StoryResult sr = new StoryResult();        
            sr.value = array4[0].ToInt();
            sr.type = array4[1];
            sr.ret = array4[2];
            story.Results.Add(sr);
        }

        this.LoadStory(story, null);
    }

	public void LoadStory(Story story, CommonSettings.VoidCallBack callback = null)
	{
        this._story = story;
        this.storyActionIndex = 0;
        this._storyResult = "0";
        //this.SuggestPanelObj.SetActive(false);//关闭建议面板
        //背景图片
        //if ((this.BackgroundImage != null || this.BackgroundImage.GetComponent<Image>().sprite == null) && MapUI.prevSprite != null)
        //{
        //	//float alpha = (float)CommonSettings.timeOpacity[RuntimeData.Instance.Date.Hour / 2];
        //	//this.SetBackground(MapUI.prevSprite, alpha);
        //	this.BigMapPanel.SetActive(false);
        //}
        //this.SetMapUIElementVisiable(false);
        this.ExecuteNextStoryAction(callback);
    }

	public void LoadSelection(string title, List<string> opts, CommonSettings.IntCallBack callback, string roleKey = "汉家松鼠")
	{
		StoryAction storyAction = new StoryAction();
		storyAction.type = "SELECT";
		storyAction.value = roleKey + "#" + title;
		foreach (string text in opts)
		{
			string str = text;
			StoryAction storyAction2 = storyAction;
			storyAction2.value = storyAction2.value + "#" + str;
		}
		this.LoadSelection(storyAction, callback);
	}

	public void LoadSelection(StoryAction selection, CommonSettings.IntCallBack callback)
	{
		//this.selectMenu.Clear();
		string[] array = selection.value.Split(new char[]
		{
			'#'
		});
		string text = array[0];
		if (text == "主角")
		{
			//this.SelectPanel.transform.FindChild("HeadImage").GetComponent<Image>().sprite = Resource.GetZhujueHead();
		}
		else
		{
			//this.SelectPanel.transform.FindChild("HeadImage").GetComponent<Image>().sprite = Resource.GetImage(ResourceManager.Get<Role>(text).Head, false);
		}
		string text2 = array[1];
		this.SelectPanel.transform.FindChild("TitleText").GetComponent<Text>().text = text2;
		for (int i = 2; i < array.Length; i++)
		{
			int index = i - 2;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MultiSelectItemObj);
			string text3 = array[i];
			text3 = text3.Replace("[[red:", "<color='red'>").Replace("[[yellow:", "<color='yellow'>").Replace("]]", "</color>");
			gameObject.transform.FindChild("Text").GetComponent<Text>().text = text3;
			gameObject.GetComponent<Button>().onClick.AddListener(delegate()
			{
				this.SelectPanel.SetActive(false);
				//this.selectMenu.Hide();
				callback(index);
			});
			//this.selectMenu.AddItem(gameObject);
		}
		this.SelectPanel.SetActive(true);
		//this.selectMenu.Show(null);
	}

    /// <summary>
    /// 执行下次故事激活
    /// </summary>
    /// <param name="callback"></param>
	public void ExecuteNextStoryAction(CommonSettings.VoidCallBack callback = null)
	{
        if (this._story == null || this._story.Actions == null)
        {
            return;
        }
        this.storyActionIndex++;
		if (this.storyActionIndex > this._story.Actions.Count)//故事完成
		{
			this.jumpDialogFlag = false;//跳过对话
			if (callback == null)
			{
				this.StoryFinished();
			}
			else
			{
				callback();
			}
			return;
		}
		this.ExecuteAction(this._story.Actions[this.storyActionIndex - 1], callback);
	}

    /// <summary>
    /// 跳过对话
    /// </summary>
    /// <param name="callback"></param>
	public void JumpDialogs(CommonSettings.VoidCallBack callback = null)
	{
		this.jumpDialogFlag = true;
		this.ExecuteNextStoryAction(callback);
	}

    private void ExecuteAction(StoryAction action, CommonSettings.VoidCallBack callback = null)
    {
        string[] array;
        if (action.value.Contains("#"))
        {
            array = action.value.Split(new char[]
            {
                '#'
            });
        }
        else
        {
            array = new string[]
            {
                action.value
            };
        }
        if (action.type != "DIALOG")
        {
            this.jumpDialogFlag = false;
        }
        string type = action.type;
        switch (type)
        {
            case "DIALOG":
                if (this.jumpDialogFlag)
                {
                    this.ExecuteNextStoryAction(callback);
                }
                else
                {
                    this.ShowDialog(action, callback);
                }
                return;
            case "SUGGEST":
                {
                    string text = array[0];
                    this.messageBox.Show("提示", text, Color.white, delegate
                    {
                        this.ExecuteNextStoryAction(callback);
                    }, "确认");
                    return;
                }
            case "SHOP":
                //RuntimeData.Instance.gameEngine.SwitchGameScene("shop", array[0]);
                //RuntimeData.Instance.StoryFinish(this._story.Name, "0");
                return;
            case "SHAKE":
                Camera.main.transform.DOShakePosition(0.5f, 10f, 10, 90f, false);
                this.ExecuteNextStoryAction(callback);
                return;
            case "SELECT":
                {
                    //this.selectMenu.Clear();
                    string text2 = array[0];
                    if (text2 == "主角")
                    {
                        //this.SelectPanel.transform.FindChild("HeadImage").GetComponent<Image>().sprite = Resource.GetZhujueHead();
                    }
                    else
                    {
                        //this.SelectPanel.transform.FindChild("HeadImage").GetComponent<Image>().sprite = Resource.GetImage(ResourceManager.Get<Role>(text2).Head, false);
                    }
                    string text3 = array[1];
                    this.SelectPanel.transform.FindChild("TitleText").GetComponent<Text>().text = text3;
                    for (int i = 2; i < array.Length; i++)
                    {
                        int index = i - 2;
                        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MultiSelectItemObj);
                        string text4 = array[i];
                        text4 = text4.Replace("[[red:", "<color='red'>").Replace("[[yellow:", "<color='yellow'>").Replace("]]", "</color>");
                        gameObject.transform.FindChild("Text").GetComponent<Text>().text = text4;
                        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
                        {
                            this.SelectPanel.SetActive(false);
                    //this.selectMenu.Hide();
                    this._storyResult = index.ToString();
                            this.ExecuteNextStoryAction(callback);
                        });
                        //this.selectMenu.AddItem(gameObject);
                    }
                    this.SelectPanel.SetActive(true);
                    //this.selectMenu.Show(null);
                    return;
                }
            case "SET_MAP":
                RuntimeData.Instance.CurrentBigMap = action.value;
                this.ExecuteNextStoryAction(callback);
                return;
            case "BACKGROUND":
                {
                    //this.BigMapPanel.SetActive(false);//关闭大地图
                    string key = array[0];
                    Debug.Log("更换了背景"+ key);
                    //Sprite image = Resource.GetImage(key, false);
                    //if (image != null)
                    //{
                    //    this.SetBackground(image, 1f);//设置背景
                    //}
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "BATTLE":
                RuntimeData.Instance.gameEngine.CurrentSceneType = "battle";
                //RuntimeData.Instance.gameEngine.CurrentSceneValue = action.value;
                //RuntimeData.Instance.gameEngine.battleType = BattleType.Common;
                RuntimeData.Instance.gameEngine.BattleSelectRole_CurrentForbbidenKeys.Clear();
                //RuntimeData.Instance.gameEngine.BattleSelectRole_CurrentCancelCallback = null;
                //RuntimeData.Instance.gameEngine.BattleSelectRole_BattleCallback = delegate(string rst)
                //{
                //	if (callback == null)
                //	{
                //		this._storyResult = rst;
                //		this.StoryFinished();
                //	}
                //	else
                //	{
                //		callback();
                //	}
                //};
                Application.LoadLevel("BattleSelectRole");
                return;
            case "TOUCH":
                //RuntimeData.Instance.gameEngine.touchCallBack = delegate (string rst)
                //{
                //    if (callback == null)
                //    {
                //        this._storyResult = rst;
                //        Debug.Log(this._storyResult);
                //        this.StoryFinished();
                //    }
                //    else
                //    {
                //        callback();
                //    }
                //};
                RuntimeData.Instance.gameEngine.touchKey = array[0];
                LoadingUI.Load("Touch");
                return;
            case "SELECT_MENPAI":
                //RuntimeData.Instance.gameEngine.SwitchGameScene("menpai", string.Empty);
                return;
            case "MUSIC":
                {
                    string key2 = array[0];
                    Debug.Log("播放了" + key2);
                    //AudioManager.Instance.Play(key2);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "JOIN":
                {
                    string value = action.value;
                    //string roleName = CommonSettings.getRoleName(value);
                    //RuntimeData.Instance.addTeamMember(value, roleName);
                    string text5 = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance = RuntimeData.Instance;
                    //string log = instance.Log;
                //    instance.Log = string.Concat(new string[]
                //    {
                //log,
                //text5,
                //"，【",
                //roleName,
                //"】加入队伍。\r\n"
                //    });
                //    this.ShowDialog(value, "【" + roleName + "】加入队伍。", callback);
                    return;
                }
            case "LEAVE":
                {
                    string value2 = action.value;
                    //string roleName2 = CommonSettings.getRoleName(value2);
                    //RuntimeData.Instance.removeTeamMember(value2);
                    string text6 = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance2 = RuntimeData.Instance;
                    //string log = instance2.Log;
                    //instance2.Log = string.Concat(new string[]
                    //    {
                    //log,
                    //text6,
                    //"，【",
                    //roleName2,
                    //"】离开。\r\n"
                    //    });
                    //    this.ShowDialog(value2, "【" + roleName2 + "】离开队伍。", callback);
                    return;
                }
            case "LEAVE_ALL":
                {
                    //RuntimeData.Instance.removeAllTeamMember();
                    string str = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance3 = RuntimeData.Instance;
                    //instance3.Log = instance3.Log + str + "，【全体队友离开队伍。\r\n";
                   // this.ShowDialog("主角", "全体队友离开队伍。", callback);
                    return;
                }
            case "FOLLOW":
                {
                    string value3 = action.value;
                    //string roleName3 = CommonSettings.getRoleName(value3);
                   // RuntimeData.Instance.addFollowMember(value3, roleName3);
                    string text7 = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance4 = RuntimeData.Instance;
                    //string log = instance4.Log;
                    // instance4.Log = string.Concat(new string[]
                    //    {
                    //log,
                    //text7,
                    //"，【",
                    //roleName3,
                    //"】随队行动（非战斗角色）。\r\n"
                    //    });
                    //    string text8 = "【" + roleName3 + "】随队行动（非战斗角色）。";
                    //    this.messageBox.Show("提示", text8, Color.white, delegate
                    //    {
                    //        this.ExecuteNextStoryAction(callback);
                    //    }, "确认");
                    return;
                }
            case "LEAVE_FOLLOW":
                {
                    string value4 = action.value;
                    //string roleName4 = CommonSettings.getRoleName(value4);
                    //RuntimeData.Instance.removeFollowMember(value4);
                    string text9 = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance5 = RuntimeData.Instance;
                    //string log = instance5.Log;
                    //    instance5.Log = string.Concat(new string[]
                    //    {
                    //log,
                    //text9,
                    //"，【",
                    //roleName4,
                    //"】离开（非战斗角色）。\r\n"
                    //    });
                    //    string text10 = "【" + roleName4 + "】离开队伍。（非战斗角色）";
                    //    this.messageBox.Show("提示", text10, Color.white, delegate
                    //    {
                    //        this.ExecuteNextStoryAction(callback);
                    //    }, "确认");
                    return;
                }
            case "HAOGAN":
                {
                    string text11 = "女主";
                    int num2;
                    if (array.Length == 1)
                    {
                        num2 = int.Parse(array[0]);
                    }
                    else
                    {
                        text11 = array[0];
                        num2 = int.Parse(array[1]);
                    }
                   // RuntimeData.Instance.addHaogan(num2, text11);
                    Debug.Log("haogan:" + text11 + num2);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "DAODE":
                {
                    int num3 = int.Parse(action.value);
                    Debug.Log("daode:" + num3.ToString());
                    //RuntimeData.Instance.Daode = RuntimeData.Instance.Daode + num3;
                    if (num3 > 0)
                    {
                        //this.ShowDialog("主角", "道德值提高" + num3 + "点", callback);
                    }
                    else
                    {
                        //this.ShowDialog("主角", "道德值降低" + -num3 + "点", callback);
                    }
                    return;
                }
            case "ITEM":
                {
                    string text12 = array[0];
                    int num4 = 1;
                    if (array.Length > 1)
                    {
                        num4 = int.Parse(array[1]);
                    }
                    if (num4 > 0)
                    {
                        RuntimeData.Instance.addItem(Item.GetItem(text12), num4);
                    //    this.ShowDialog("主角", string.Concat(new object[]
                    //    {
                    //"得到 ",
                    //text12,
                    //" x ",
                    //Math.Abs(num4)
                    //    }), callback);
                        //AudioManager.Instance.PlayEffect("音效.升级");
                    }
                    else
                    {
                        RuntimeData.Instance.addItem(Item.GetItem(text12), num4);
                    //    this.ShowDialog("主角", string.Concat(new object[]
                    //    {
                    //"失去 ",
                    //text12,
                    //" x ",
                    //Math.Abs(num4)
                    //    }), callback);
                        //AudioManager.Instance.PlayEffect("音效.装备");
                    }
                    return;
                }
            case "NEWBIE":
                {
                    RuntimeData.Instance.NewbieTask = action.value;
                    Task task = ResourceManager.Get<Task>(action.value);
                    //RuntimeData.Instance.AddLog("接到新手任务：" + task.Desc);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "LOG":
                {
                    string text13 = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance6 = RuntimeData.Instance;
                   // string log = instance6.Log;
                //    instance6.Log = string.Concat(new string[]
                //    {
                //log,
                //text13,
                //"，",
                //action.value,
                //"\r\n"
                //    });
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "MENPAI":
                {
                    string text14 = string.Concat(new string[]
                    {
                "江湖",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Year],
                "年",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Month],
                "月",
                //Tools.chineseNumber[RuntimeData.Instance.Date.Day],
                "日"
                    });
                    RuntimeData instance7 = RuntimeData.Instance;
                    //string log = instance7.Log;
                //    instance7.Log = string.Concat(new string[]
                //    {
                //log,
                //text14,
                //"，加入",
                //action.value,
                //"。\r\n"
                //    });
                    //RuntimeData.Instance.Menpai = action.value;
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "NICK":
                //GlobalData.addNick(action.value);
                //RuntimeData.Instance.CurrentNick = action.value;
                this.UIStatePanelNickText.GetComponent<Text>().text = action.value;
                //this.ShowDialog("主角", "获得称号：【" + action.value + "】！", callback);
                return;
            case "COST_MONEY":
                {
                    int num5 = int.Parse(action.value);
                    RuntimeData.Instance.Money = RuntimeData.Instance.Money - num5;
                    //this.ShowDialog("主角", "失去 " + num5.ToString() + " 两银子。", callback);
                    return;
                }
            case "GET_MONEY":
                {
                    int num6 = int.Parse(action.value);
                    RuntimeData.Instance.Money = RuntimeData.Instance.Money + num6;
                    //this.ShowDialog("主角", "得到 " + num6.ToString() + " 两银子。", callback);
                    return;
                }
            case "YUANBAO":
                {
                    int num7 = int.Parse(action.value);
                    //RuntimeData.Instance.Yuanbao += num7;
                    if (num7 > 0)
                    {
                        //this.ShowDialog("主角", "得到元宝" + num7, callback);
                    }
                    else
                    {
                        //this.ShowDialog("主角", "失去元宝" + Math.Abs(num7), callback);
                    }
                    return;
                }
            case "COST_ITEM":
                {
                    string text15 = array[0];
                    int num8 = int.Parse(array[1]);
                    RuntimeData.Instance.addItem(Item.GetItem(text15), -num8);
                //    this.ShowDialog("主角", string.Concat(new object[]
                //    {
                //"失去 ",
                //text15,
                //" x ",
                //num8
                //    }), callback);
                    return;
                }
            case "COST_DAY":
                {
                    int num9 = int.Parse(action.value);
                    //RuntimeData.Instance.Date = RuntimeData.Instance.Date.AddDays((double)num9);
                    //this.ShowDialog("主角", "一共用了" + num9 + "天...", callback);
                    return;
                }
            case "COST_HOUR":
                {
                    int num10 = int.Parse(action.value);
                    //RuntimeData.Instance.Date = RuntimeData.Instance.Date.AddHours((double)num10);
                    //this.ShowDialog("主角", "过了" + num10 + "个时辰...", callback);
                    return;
                }
            case "GET_POINT":
                {
                    string text16 = array[0];
                    int num11 = int.Parse(array[1]);
                    foreach (Role role in RuntimeData.Instance.Team)
                    {
                        if (role.Key == text16)
                        {
                            role.leftpoint += num11;
                            if (role.leftpoint < 0)
                            {
                                role.leftpoint = 0;
                            }
                        }
                    }
                    //string roleName5 = CommonSettings.getRoleName(text16);
                    if (num11 > 0)
                    {
                        //this.ShowDialog(text16, roleName5 + "属性分配点增加【" + num11.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text16, roleName5 + "属性分配点减少【" + (-num11).ToString() + "】！", callback);
                    }
                    return;
                }
            case "MINUS_MAXPOINTS":
                {
                    string text17 = array[0];
                    int num12 = int.Parse(array[1]);
                    float num13 = (float)num12 * 0.1f;
                    bool flag = false;
                    foreach (Role role2 in RuntimeData.Instance.Team)
                    {
                        if (role2.Key == text17)
                        {
                            role2.maxhp = (int)((float)role2.maxhp * num13);
                            role2.maxmp = (int)((float)role2.maxmp * num13);
                            role2.leftpoint = (int)((float)role2.leftpoint * num13);
                            role2.quanzhang = (int)((float)role2.quanzhang * num13);
                            role2.jianfa = (int)((float)role2.jianfa * num13);
                            role2.daofa = (int)((float)role2.daofa * num13);
                            role2.qimen = (int)((float)role2.qimen * num13);
                            role2.bili = (int)((float)role2.bili * num13);
                            role2.shenfa = (int)((float)role2.shenfa * num13);
                            role2.dingli = (int)((float)role2.dingli * num13);
                            role2.fuyuan = (int)((float)role2.fuyuan * num13);
                            role2.wuxing = (int)((float)role2.wuxing * num13);
                            role2.gengu = (int)((float)role2.gengu * num13);
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName6 = CommonSettings.getRoleName(text17);
                    //this.ShowDialog(text17, roleName6 + "气血、内力、全属性降为【" + num12.ToString() + "成】！", callback);
                    return;
                }
            case "URL":
                {
                    string url = array[0];
                    //Tools.openURL(url);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "UPGRADE.MAXHP":
                {
                    string text18 = array[0];
                    int num14 = int.Parse(array[1]);
                    bool flag2 = false;
                    foreach (Role role3 in RuntimeData.Instance.Team)
                    {
                        if (role3.Key == text18)
                        {
                            role3.maxhp += num14;
                            if (role3.maxhp <= 100)
                            {
                                role3.maxhp = 100;
                            }
                            //if (role3.maxhp > CommonSettings.MAX_HPMP)
                            //{
                            //    role3.maxhp = CommonSettings.MAX_HPMP;
                            //}
                            role3.hp = role3.maxhp;
                            flag2 = true;
                        }
                    }
                    if (!flag2)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName7 = CommonSettings.getRoleName(text18);
                    if (num14 > 0)
                    {
                        //this.ShowDialog(text18, roleName7 + "气血上限增加【" + num14.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text18, roleName7 + "气血上限减少【" + (-num14).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.MAXMP":
                {
                    string text19 = array[0];
                    int num15 = int.Parse(array[1]);
                    bool flag3 = false;
                    foreach (Role role4 in RuntimeData.Instance.Team)
                    {
                        if (role4.Key == text19)
                        {
                            role4.maxmp += num15;
                            if (role4.maxmp <= 100)
                            {
                                role4.maxmp = 100;
                            }
                            //if (role4.maxmp > CommonSettings.MAX_HPMP)
                            //{
                            //    role4.maxmp = CommonSettings.MAX_HPMP;
                            //}
                            role4.mp = role4.maxmp;
                            flag3 = true;
                        }
                    }
                    if (!flag3)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName8 = CommonSettings.getRoleName(text19);
                    if (num15 > 0)
                    {
                        //this.ShowDialog(text19, roleName8 + "内力上限增加【" + num15.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text19, roleName8 + "内力上限减少【" + (-num15).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.根骨":
                {
                    string text20 = array[0];
                    int num16 = int.Parse(array[1]);
                    bool flag4 = false;
                    foreach (Role role5 in RuntimeData.Instance.Team)
                    {
                        if (role5.Key == text20)
                        {
                            role5.gengu += num16;
                            flag4 = true;
                        }
                    }
                    if (!flag4)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName9 = CommonSettings.getRoleName(text20);
                    if (num16 > 0)
                    {
                        //this.ShowDialog(text20, roleName9 + "根骨增加【" + num16.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text20, roleName9 + "根骨减少【" + (-num16).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.身法":
                {
                    string text21 = array[0];
                    int num17 = int.Parse(array[1]);
                    bool flag5 = false;
                    foreach (Role role6 in RuntimeData.Instance.Team)
                    {
                        if (role6.Key == text21)
                        {
                            role6.shenfa += num17;
                            flag5 = true;
                        }
                    }
                    if (!flag5)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName10 = CommonSettings.getRoleName(text21);
                    if (num17 > 0)
                    {
                        //this.ShowDialog(text21, roleName10 + "身法增加【" + num17.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text21, roleName10 + "身法减少【" + (-num17).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.悟性":
                {
                    string text22 = array[0];
                    int num18 = int.Parse(array[1]);
                    bool flag6 = false;
                    foreach (Role role7 in RuntimeData.Instance.Team)
                    {
                        if (role7.Key == text22)
                        {
                            role7.wuxing += num18;
                            flag6 = true;
                        }
                    }
                    if (!flag6)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName11 = CommonSettings.getRoleName(text22);
                    if (num18 > 0)
                    {
                        //this.ShowDialog(text22, roleName11 + "悟性增加【" + num18.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text22, roleName11 + "悟性减少【" + (-num18).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.臂力":
                {
                    string text23 = array[0];
                    int num19 = int.Parse(array[1]);
                    bool flag7 = false;
                    foreach (Role role8 in RuntimeData.Instance.Team)
                    {
                        if (role8.Key == text23)
                        {
                            role8.bili += num19;
                            flag7 = true;
                        }
                    }
                    if (!flag7)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName12 = CommonSettings.getRoleName(text23);
                    if (num19 > 0)
                    {
                        //this.ShowDialog(text23, roleName12 + "臂力增加【" + num19.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text23, roleName12 + "臂力减少【" + (-num19).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.福缘":
                {
                    string text24 = array[0];
                    int num20 = int.Parse(array[1]);
                    bool flag8 = false;
                    foreach (Role role9 in RuntimeData.Instance.Team)
                    {
                        if (role9.Key == text24)
                        {
                            role9.fuyuan += num20;
                            flag8 = true;
                        }
                    }
                    if (!flag8)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName13 = CommonSettings.getRoleName(text24);
                    if (num20 > 0)
                    {
                        //this.ShowDialog(text24, roleName13 + "福缘增加【" + num20.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text24, roleName13 + "福缘减少【" + (-num20).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.定力":
                {
                    string text25 = array[0];
                    int num21 = int.Parse(array[1]);
                    bool flag9 = false;
                    foreach (Role role10 in RuntimeData.Instance.Team)
                    {
                        if (role10.Key == text25)
                        {
                            role10.dingli += num21;
                            flag9 = true;
                        }
                    }
                    if (!flag9)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName14 = CommonSettings.getRoleName(text25);
                    if (num21 > 0)
                    {
                        //this.ShowDialog(text25, roleName14 + "定力增加【" + num21.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text25, roleName14 + "定力减少【" + (-num21).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.拳掌":
                {
                    string text26 = array[0];
                    int num22 = int.Parse(array[1]);
                    bool flag10 = false;
                    foreach (Role role11 in RuntimeData.Instance.Team)
                    {
                        if (role11.Key == text26)
                        {
                            role11.quanzhang += num22;
                            flag10 = true;
                        }
                    }
                    if (!flag10)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName15 = CommonSettings.getRoleName(text26);
                    if (num22 > 0)
                    {
                        //this.ShowDialog(text26, roleName15 + "拳掌增加【" + num22.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text26, roleName15 + "拳掌减少【" + (-num22).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.剑法":
                {
                    string text27 = array[0];
                    int num23 = int.Parse(array[1]);
                    bool flag11 = false;
                    foreach (Role role12 in RuntimeData.Instance.Team)
                    {
                        if (role12.Key == text27)
                        {
                            role12.jianfa += num23;
                            flag11 = true;
                        }
                    }
                    if (!flag11)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName16 = CommonSettings.getRoleName(text27);
                    if (num23 > 0)
                    {
                        //this.ShowDialog(text27, roleName16 + "剑法增加【" + num23.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text27, roleName16 + "剑法减少【" + (-num23).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.刀法":
                {
                    string text28 = array[0];
                    int num24 = int.Parse(array[1]);
                    bool flag12 = false;
                    foreach (Role role13 in RuntimeData.Instance.Team)
                    {
                        if (role13.Key == text28)
                        {
                            role13.daofa += num24;
                            flag12 = true;
                        }
                    }
                    if (!flag12)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName17 = CommonSettings.getRoleName(text28);
                    if (num24 > 0)
                    {
                        //this.ShowDialog(text28, roleName17 + "刀法增加【" + num24.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text28, roleName17 + "刀法减少【" + (-num24).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.奇门":
                {
                    string text29 = array[0];
                    int num25 = int.Parse(array[1]);
                    bool flag13 = false;
                    foreach (Role role14 in RuntimeData.Instance.Team)
                    {
                        if (role14.Key == text29)
                        {
                            role14.qimen += num25;
                            flag13 = true;
                        }
                    }
                    if (!flag13)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //string roleName18 = CommonSettings.getRoleName(text29);
                    if (num25 > 0)
                    {
                        //this.ShowDialog(text29, roleName18 + "奇门增加【" + num25.ToString() + "】！", callback);
                    }
                    else
                    {
                        //this.ShowDialog(text29, roleName18 + "奇门减少【" + (-num25).ToString() + "】！", callback);
                    }
                    return;
                }
            case "UPGRADE.SKILL":
                {
                    string text30 = array[0];
                    string text31 = array[1];
                    int num26 = int.Parse(array[2]);
                    //string roleName19 = CommonSettings.getRoleName(text30);
                    bool flag14 = false;
                    foreach (Role role15 in RuntimeData.Instance.Team)
                    {
                        if (!(role15.Key != text30))
                        {
                            flag14 = true;
                            //SkillInstance skillInstance = null;
                            //foreach (SkillInstance skillInstance2 in role15.Skills)
                            //{
                            //    if (skillInstance2.Skill.Name == text31)
                            //    {
                            //        skillInstance = skillInstance2;
                            //        break;
                            //    }
                            //}
                        //    if (skillInstance == null)
                        //    {
                        //        SkillInstance skillInstance3 = new SkillInstance
                        //        {
                        //            name = text31,
                        //            level = num26,
                        //            Owner = role15
                        //        };
                        //        skillInstance3.RefreshUniquSkills();
                        //        skillInstance3.Exp = 0;
                        //        role15.Skills.Add(skillInstance3);
                        //        this.ShowDialog(text30, string.Concat(new object[]
                        //        {
                        //    roleName19,
                        //    "掌握了武功【",
                        //    text31,
                        //    "】(",
                        //    num26,
                        //    "级)！"
                        //        }), callback);
                        //        break;
                        //    }
                        //    if (skillInstance.Level >= skillInstance.MaxLevel)
                        //    {
                        //        this.ShowDialog(text30, string.Concat(new object[]
                        //        {
                        //    roleName19,
                        //    "的武功【",
                        //    text31,
                        //    "】已经到达等级上限（",
                        //    skillInstance.MaxLevel,
                        //    "级)，无法再提升了！"
                        //        }), callback);
                        //        break;
                        //    }
                        //    skillInstance.level += num26;
                        //    if (skillInstance.Level > skillInstance.MaxLevel)
                        //    {
                        //        skillInstance.level = skillInstance.MaxLevel;
                        //    }
                        //    this.ShowDialog(text30, string.Concat(new object[]
                        //    {
                        //roleName19,
                        //"的武功【",
                        //text31,
                        //"】提升了",
                        //num26,
                        //"级！"
                        //    }), callback);
                            break;
                        }
                    }
                    if (!flag14)
                    {
                        this.ExecuteNextStoryAction(callback);
                    }
                    return;
                }
            case "LEARN.SKILL":
                {
                    string text32 = array[0];
                    string text33 = array[1];
                    int num27 = int.Parse(array[2]);
                    //string roleName20 = CommonSettings.getRoleName(text32);
                    bool flag15 = false;
                    foreach (Role role16 in RuntimeData.Instance.Team)
                    {
                        if (!(role16.Key != text32))
                        {
                            flag15 = true;
                           // SkillInstance skillInstance4 = null;
                            //foreach (SkillInstance skillInstance5 in role16.Skills)
                            //{
                            //    if (skillInstance5.Skill.Name == text33)
                            //    {
                            //        skillInstance4 = skillInstance5;
                            //        break;
                            //    }
                            //}
                            //if (skillInstance4 == null)
                            //{
                            //    SkillInstance skillInstance6 = new SkillInstance
                            //    {
                            //        name = text33,
                            //        level = num27,
                            //        Owner = role16
                            //    };
                            //    skillInstance6.RefreshUniquSkills();
                            //    skillInstance6.Exp = 0;
                            //    role16.Skills.Add(skillInstance6);
                            //}
                            //else
                            //{
                            //    skillInstance4.level = Math.Max(skillInstance4.Level, num27);
                            //}
                        }
                    }
                    if (flag15)
                    {
                    //    this.ShowDialog(text32, string.Concat(new object[]
                    //    {
                    //roleName20,
                    //"掌握了武功【",
                    //text33,
                    //"】",
                    //num27,
                    //"级！"
                    //    }), callback);
                    //}
                    //else
                    //{
                    //    this.ExecuteNextStoryAction(callback);
                    }
                    return;
                }
            case "UPGRADE.INTERNALSKILL":
                {
                    string text34 = array[0];
                    string text35 = array[1];
                    int num28 = int.Parse(array[2]);
                    //string roleName21 = CommonSettings.getRoleName(text34);
                    bool flag16 = false;
                    foreach (Role role17 in RuntimeData.Instance.Team)
                    {
                        if (!(role17.Key != text34))
                        {
                            flag16 = true;
                            //InternalSkillInstance internalSkillInstance = null;
                            //foreach (InternalSkillInstance internalSkillInstance2 in role17.InternalSkills)
                            //{
                            //    if (internalSkillInstance2.Name == text35)
                            //    {
                            //        internalSkillInstance = internalSkillInstance2;
                            //        break;
                            //    }
                            //}
                            //if (internalSkillInstance == null)
                            //{
                            //    InternalSkillInstance internalSkillInstance3 = new InternalSkillInstance
                            //    {
                            //        name = text35,
                            //        level = num28,
                            //        Owner = role17
                            //    };
                            //    internalSkillInstance3.RefreshUniquSkills();
                            //    internalSkillInstance3.Exp = 0;
                            //    role17.InternalSkills.Add(internalSkillInstance3);
                            //    this.ShowDialog(text34, string.Concat(new object[]
                            //    {
                            //roleName21,
                            //"掌握了内功【",
                            //text35,
                            //"】(",
                            //num28,
                            //"级)！"
                            //    }), callback);
                            //    break;
                            //}
                            //        if (internalSkillInstance.Level >= internalSkillInstance.MaxLevel)
                            //        {
                            //            this.ShowDialog(text34, string.Concat(new object[]
                            //            {
                            //        roleName21,
                            //        "的内功【",
                            //        text35,
                            //        "】已经到达等级上限(",
                            //        internalSkillInstance.MaxLevel,
                            //        "级)！无法再提升了！"
                            //            }), callback);
                            //            break;
                            //        }
                            //        internalSkillInstance.level += num28;
                            //        if (internalSkillInstance.Level > internalSkillInstance.MaxLevel)
                            //        {
                            //            internalSkillInstance.level = internalSkillInstance.MaxLevel;
                            //        }
                            //        this.ShowDialog(text34, string.Concat(new object[]
                            //        {
                            //    roleName21,
                            //    "的内功【",
                            //    text35,
                            //    "】提升了",
                            //    num28,
                            //    "级！"
                            //        }), callback);
                            break;
                        }
                    }
                    if (!flag16)
                    {
                        this.ExecuteNextStoryAction(callback);
                    }
                    return;
                }
            case "LEARN.INTERNALSKILL":
                {
                    string text36 = array[0];
                    string text37 = array[1];
                    int num29 = int.Parse(array[2]);
                    //string roleName22 = CommonSettings.getRoleName(text36);
                    bool flag17 = false;
                    foreach (Role role18 in RuntimeData.Instance.Team)
                    {
                        if (!(role18.Key != text36))
                        {
                            flag17 = true;
                            //InternalSkillInstance internalSkillInstance4 = null;
                            //foreach (InternalSkillInstance internalSkillInstance5 in role18.InternalSkills)
                            //{
                            //    if (internalSkillInstance5.Name == text37)
                            //    {
                            //        internalSkillInstance4 = internalSkillInstance5;
                            //        break;
                            //    }
                            //}
                            //if (internalSkillInstance4 == null)
                            //{
                            //    //InternalSkillInstance internalSkillInstance6 = new InternalSkillInstance
                            //    //{
                            //    //    name = text37,
                            //    //    level = num29,
                            //    //    Owner = role18
                            //    //};
                            //    internalSkillInstance6.RefreshUniquSkills();
                            //    internalSkillInstance6.Exp = 0;
                            //    //role18.InternalSkills.Add(internalSkillInstance6);
                            //    role18.InitBind();
                            //}
                            //else
                            //{
                            //    internalSkillInstance4.level = Math.Max(internalSkillInstance4.Level, num29);
                            //}
                        }
                    }
                    if (flag17)
                    {
                    //    this.ShowDialog(text36, string.Concat(new object[]
                    //    {
                    //roleName22,
                    //"掌握了内功【",
                    //text37,
                    //"】",
                    //num29,
                    //"级！"
                    //    }), callback);
                    }
                    else
                    {
                        this.ExecuteNextStoryAction(callback);
                    }
                    return;
                }
            case "LEARN.SPECIALSKILL":
                {
                    string text38 = array[0];
                    string text39 = array[1];
                    //string roleName23 = CommonSettings.getRoleName(text38);
                    bool flag18 = false;
                    foreach (Role role19 in RuntimeData.Instance.Team)
                    {
                        if (!(role19.Key != text38))
                        {
                            flag18 = true;
                            //SpecialSkillInstance specialSkillInstance = null;
                            //foreach (SpecialSkillInstance specialSkillInstance2 in role19.SpecialSkills)
                            //{
                            //    if (specialSkillInstance2.Name == text39)
                            //    {
                            //        specialSkillInstance = specialSkillInstance2;
                            //        break;
                            //    }
                            //}
                            //if (specialSkillInstance == null)
                            //{
                            //    SpecialSkillInstance item = new SpecialSkillInstance
                            //    {
                            //        name = text39,
                            //        Owner = role19
                            //    };
                            //    role19.SpecialSkills.Add(item);
                            //    role19.InitBind();
                            //}
                        }
                    }
                    if (flag18)
                    {
                        //this.ShowDialog(text38, roleName23 + "掌握了特殊攻击【" + text39 + "】", callback);
                    }
                    else
                    {
                        this.ExecuteNextStoryAction(callback);
                    }
                    return;
                }
            case "LEARN.TALENT":
                {
                    string text40 = array[0];
                    string text41 = array[1];
                    //string roleName24 = CommonSettings.getRoleName(text40);
                    bool flag19 = false;
                    foreach (Role role20 in RuntimeData.Instance.Team)
                    {
                        if (role20.Key == text40)
                        {
                            if (!role20.Talents.Contains(text41))
                            {
                                role20.Talents.Add(text41);
                            }
                            flag19 = true;
                        }
                    }
                    if (!flag19)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //this.ShowDialog(text40, roleName24 + "领悟了天赋【" + text41 + "】", callback);
                    return;
                }
            case "REMOVE.TALENT":
                {
                    string text42 = array[0];
                    string text43 = array[1];
                    //string roleName25 = CommonSettings.getRoleName(text42);
                    bool flag20 = false;
                    foreach (Role role21 in RuntimeData.Instance.Team)
                    {
                        if (role21.Key == text42)
                        {
                            flag20 = true;
                            if (role21.Talents.Contains(text43))
                            {
                                role21.Talents.Remove(text43);
                            }
                        }
                    }
                    if (!flag20)
                    {
                        this.ExecuteNextStoryAction(callback);
                        return;
                    }
                    //this.ShowDialog(text42, roleName25 + "移除了天赋【" + text43 + "】", callback);
                    return;
                }
            case "CHANGE_FEMALE_NAME":
                //this.nameInputPanel.Show("铃兰", delegate (string name)
                //{
                //    RuntimeData.Instance.femaleName = name;
                //    this.ExecuteNextStoryAction(callback);
                //});
                return;
            case "EFFECT":
                {
                    string key3 = array[0];
                    //AudioManager.Instance.PlayEffect(key3);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "SET_TIME_KEY":
                {
                    string key4 = array[0];
                    int days = int.Parse(array[1]);
                    string story = string.Empty;
                    if (array.Length > 2)
                    {
                        story = array[2];
                    }
                   // RuntimeData.Instance.AddTimeKeyStory(key4, days, story);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "CLEAR_TIME_KEY":
                {
                    string key5 = array[0];
                    //RuntimeData.Instance.RemoveTimeKey(key5);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "SET_FLAG":
                {
                    string key6 = array[0];
                    //RuntimeData.Instance.AddFlag(key6);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "CLEAR_FLAG":
                {
                    string key7 = array[0];
                    //RuntimeData.Instance.RemoveFlag(key7);
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "ANIMATION":
                {
                    string roleKey = array[0];
                    string animation = array[1];
                    //string roleName26 = CommonSettings.getRoleName(roleKey);
                    foreach (Role role22 in RuntimeData.Instance.Team)
                    {
                        //if (role22.Name == roleName26)
                        //{
                        //    role22.Animation = animation;
                        //}
                    }
                    this.ExecuteNextStoryAction(callback);
                    return;
                }
            case "HEAD":
                RuntimeData.Instance.Team[0].Head = array[0];
                //this.RoleStatePanelObj.GetComponent<RoleStatePanelUI>().Refresh();
                this.ExecuteNextStoryAction(callback);
                return;
            case "GROWTEMPLATE":
                if (array.Length == 2)
                {
                    foreach (Role role23 in RuntimeData.Instance.Team)
                    {
                        if (role23.Key == array[0])
                        {
                            role23.GrowTemplateValue = array[1];
                        }
                    }
                }
                this.ExecuteNextStoryAction(callback);
                return;
            case "MAXLEVEL":
                {
                    string text44 = array[0];
                    int level = int.Parse(array[1]);
                    string name2 = this._story.Name;
                    //int num30 = GlobalData.AddSkillMaxLevel(text44, level, name2 + "_" + text44);
                    //if (num30 == -1)
                    //{
                    //    this.ExecuteNextStoryAction(callback);
                    //}
                    //else
                    //{
                    //    //this.ShowDialog("主角", string.Format("解锁技能精通！{0}的等级上限提升至{1}", text44, num30), callback);
                    //}
                    //AudioManager.Instance.PlayEffect("音效.升级");
                    return;
                }
        }
        Debug.LogError("invalid story action type:" + action.type);
        this.ExecuteNextStoryAction(callback);
    }

    public void ShowDialog(string role, string msg, CommonSettings.VoidCallBack callback)
    {
        //this.DialogPanel.GetComponent<DialogUI>().Show(role, msg, callback);
    }

    public void ShowDialogs(List<StoryAction> actions, CommonSettings.VoidCallBack callback)
    {
        this.LoadStory(new Story
        {
            Actions = actions
        }, callback);
    }

    public void ShowDialog(StoryAction action, CommonSettings.VoidCallBack callback)
    {
        this.DialogPanel.GetComponent<DialogUI>().Show(action, callback);
    }

    /// <summary>
    /// 故事完成
    /// </summary>
    private void StoryFinished()
    {
        RuntimeData.Instance.StoryFinish(this._story.Name, this._storyResult);
        foreach (StoryResult storyResult in this._story.Results)
        {
            if (storyResult.ret == null)
            {
                storyResult.ret = "0";
            }
            if (storyResult.ret.Equals(this._storyResult))
            {
                bool flag = true;
                foreach (Condition condition in storyResult.Conditions)
                {
                    Debug.Log("执行");
                    if (!condition.IsTrue)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    RuntimeData.Instance.gameEngine.SwitchGameScene(storyResult.type, storyResult.value);
                    return;
                }
            }
        }
        if (this._storyResult == "lose")
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        RuntimeData.Instance.gameEngine.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap.ToInt());
    }

    //private void SetBackground(Sprite sp, float alpha = 1f)
    //{
    //	if (sp == null)
    //	{
    //		this.BackgroundImage.GetComponent<Image>().color = Color.black;
    //		this.BackgroundImage.GetComponent<Image>().sprite = null;
    //	}
    //	else
    //	{
    //		this.BackgroundImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
    //		this.BackgroundImage.GetComponent<Image>().sprite = sp;
    //		MapUI.prevSprite = sp;
    //	}
    //}

    //// Token: 0x1700015E RID: 350
    //// (get) Token: 0x060004DB RID: 1243 RVA: 0x0002BAEC File Offset: 0x00029CEC
    //public Map CurrentMap
    //{
    //	get
    //	{
    //		return this._map;
    //	}
    //}

    private IEnumerator DrawMap(int index)
    {
        Map map = new Map();
        //this._map = map;
        //this.Clear(); 
        //this.SetMapUIElementVisiable(true);
        //float alpha = (float)CommonSettings.timeOpacity[RuntimeData.Instance.Date.Hour / 2];
        //Music bg = map.GetRandomMusic();
        //if (bg != null)
        //{
        //    AudioManager.Instance.Play(bg.Name);
        //}
        //if (map.Name == "大地图")
        //{
        //    this.BigMapPanel.SetActive(true);
        //    this.MapPanel.SetActive(false);
        //    MapUI.prevSprite = null;
        //    this.SetBackground(null, 1f);
        //    this.BigMap.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
        //    this.BigMap.GetComponent<Image>().sprite = Resource.GetImage(map.Pic, false);
        //}
        //else
        //{
        //    this.BigMapPanel.SetActive(false);
        //    this.MapPanel.SetActive(true);
        //    this.SetBackground(Resource.GetImage(map.Pic, false), alpha);
        //    Text descText = this.MapDescriptionPanelObj.transform.FindChild("DescText").GetComponent<Text>();
        //    descText.text = map.Desc;
        //    this.MapDescriptionPanelObj.SetActive(true);
        //}
        //if (map.Locations.Count > 0)
        //{
        //    this.LocationInfoText.GetComponent<Text>().text = string.Format("{0}:{1}", RuntimeData.Instance.CurrentBigMap, RuntimeData.Instance.GetLocation(RuntimeData.Instance.CurrentBigMap));
        //}
        //else
        //{
        //    this.LocationInfoText.GetComponent<Text>().text = map.Name.TrimEnd(new char[]
        //    {
        //        '1',
        //        '2',
        //        '3',
        //        '4',
        //        '5',
        //        '6',
        //        '7',
        //        '8',
        //        '9',
        //        '0'
        //    });
        //}
        //this.TimeInfoText.GetComponent<Text>().text = CommonSettings.DateToGameTime(RuntimeData.Instance.Date);
        //this.MoneyTextObj.GetComponent<Text>().text = RuntimeData.Instance.Money.ToString();
        //this.YuanbaoTextObj.GetComponent<Text>().text = RuntimeData.Instance.Yuanbao.ToString();
        //if (!Configer.IsBigmapFullScreen)
        //{
        //    foreach (MapLocation location in map.Locations)
        //    {
        //        if (location.getName().Equals(RuntimeData.Instance.GetLocation(RuntimeData.Instance.CurrentBigMap)))
        //        {
        //            float x = (float)(-(float)location.X + 640);
        //            float y = (float)(-(float)location.Y - 320);
        //            if (x < -1140f)
        //            {
        //                x = -1140f;
        //            }
        //            if (y > 640f)
        //            {
        //                y = 640f;
        //            }
        //            if (x > 0f)
        //            {
        //                x = 0f;
        //            }
        //            if (y < 0f)
        //            {
        //                y = 0f;
        //            }
        //            this.BigMap.transform.localPosition = new Vector3(-570f + x, 320f + y, 0f);
        //            break;
        //        }
        //    }
        //    yield return 0;
        //}
        //int locationCount = 0;
        //foreach (MapLocation location2 in map.Locations)
        //{
        //    this.AddLocation(location2);
        //    locationCount++;
        //    if (locationCount % 10 == 0)
        //    {
        //        yield return 0;
        //    }
        //}
        //yield return 0;
        //int i = 0;
        //foreach (MapRole maprole in map.MapRoles)
        //{
        //    if (this.AddMapRole(maprole, i))
        //    {
        //        i++;
        //    }
        //}
        yield return 0;
        yield break;
    }

    //// Token: 0x1700015F RID: 351
    //// (get) Token: 0x060004DD RID: 1245 RVA: 0x0002BB20 File Offset: 0x00029D20
    //private MapLocation CurrentLocation
    //{
    //	get
    //	{
    //		foreach (MapLocation mapLocation in this._map.Locations)
    //		{
    //			if (mapLocation.getName() == RuntimeData.Instance.GetLocation(this._map.Name))
    //			{
    //				return mapLocation;
    //			}
    //		}
    //		return null;
    //	}
    //}

    //// Token: 0x060004DE RID: 1246 RVA: 0x0002BBB4 File Offset: 0x00029DB4
    //private void AddLocation(MapLocation location)
    //{
    //	GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LocationObjPrefab);
    //	MapLocation currentLocation = this.CurrentLocation;
    //	int num = 2;
    //	if (currentLocation != null)
    //	{
    //		double num2 = Math.Sqrt((double)((currentLocation.x - location.x) * (currentLocation.x - location.x) + (currentLocation.y - location.y) * (currentLocation.y - location.y)));
    //		num += (int)(num2 / 50.0 * 10.0);
    //	}
    //	gameObject.transform.SetParent(this.BigMap.transform.FindChild("MapLocationContainer"));
    //	gameObject.GetComponent<MapLocationUI>().Bind(this, location, num);
    //}

    //// Token: 0x060004DF RID: 1247 RVA: 0x0002BC64 File Offset: 0x00029E64
    //private bool AddMapRole(MapRole mapRole, int index)
    //{
    //	MapEvent activeEvent = mapRole.GetActiveEvent();
    //	if (activeEvent == null)
    //	{
    //		return false;
    //	}
    //	GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MapRoleObjPrefab);
    //	gameObject.transform.SetParent(this.MapRolePanel.transform);
    //	gameObject.GetComponent<MapRoleUI>().Bind(this, mapRole, index, activeEvent);
    //	return true;
    //}

    //// Token: 0x060004E0 RID: 1248 RVA: 0x0002BCB4 File Offset: 0x00029EB4
    //private void Clear()
    //{
    //	foreach (object obj in this.BigMap.transform.FindChild("MapLocationContainer"))
    //	{
    //		Transform transform = (Transform)obj;
    //		UnityEngine.Object.Destroy(transform.gameObject);
    //	}
    //	this.BigMap.transform.FindChild("MapLocationContainer").DetachChildren();
    //	foreach (object obj2 in this.MapRolePanel.transform)
    //	{
    //		Transform transform2 = (Transform)obj2;
    //		UnityEngine.Object.Destroy(transform2.gameObject);
    //	}
    //	this.MapRolePanel.transform.DetachChildren();
    //	this.SuggestPanelObj.SetActive(false);
    //}

    //// Token: 0x060004E1 RID: 1249 RVA: 0x0002BDDC File Offset: 0x00029FDC
    //public void ShowEventConfirmPanel(Sprite image, MapEvent evt, string name, string desc, int timeCost)
    //{
    //	this.EventConfirmPanel.GetComponent<EventConfirmPanel>().Show(image, evt, name, desc, timeCost);
    //}

    //// Token: 0x060004E2 RID: 1250 RVA: 0x0002BE00 File Offset: 0x0002A000
    //public void HideEventConfirmPanel()
    //{
    //	this.EventConfirmPanel.gameObject.SetActive(false);
    //}

    private void Start()
    {
        if (!RuntimeData.Instance.IsInited)//运行数据没有初始化
        {
            RuntimeData.Instance.Init();
            for (int i = 0; i < 10; i++)
            {
                string text = "save" + i.ToString();
                if (PlayerPrefs.HasKey(text))
                {
                    string save = SaveManager.GetSave(text);
                    //RuntimeData.Instance.Load(save);
                    break;
                }
            }
        }

        this.Init();
        RuntimeData.Instance.mapUI = this;
        GameEngine gameEngine = RuntimeData.Instance.gameEngine;
        if (gameEngine.CurrentSceneType == "map")
        {
            //this.LoadMap(gameEngine.CurrentSceneValue);
        }
        else if (gameEngine.CurrentSceneType == "story")
        {
            this.LoadStory(gameEngine.CurrentSceneValue);
        }
        else if (gameEngine.CurrentSceneType == "runtimestory")
        {
            //this.LoadStory(gameEngine.RuntimeStory, gameEngine.RuntimeCallback);
        }
    }

    private void Init()
    {
        this.DialogPanel.SetActive(false);//关闭所有窗口
        //this.SelectPanel.SetActive(false);
        //this.RolePanel.SetActive(false);
        //this.SystemPanelObj.SetActive(false);
        //this.ItemDetailPanelObj.SetActive(false);
        //this.SuggestPanelObj.SetActive(false);
        //this.roleSelectMenu.Hide();
        //this.nameInputPanel.Hide();
        //this.AchievementPanelObj.SetActive(false);
        //this.SkillSelectPanelObj.SetActive(false);
        //this.SuggestPanelObj.SetActive(false);
        this.MessageBoxUIObj.SetActive(false);
        //this.LogPanel.SetActive(false);
        //this.itemMenu.Hide();
        //this.EventConfirmPanel.SetActive(false);
        //this.TeamPanelObj.SetActive(false);
        //this.RoleSelectPanelObj.SetActive(false);
        //this.ItemPanel.SetActive(false);
        //this.InitScale();
    }

    //private void InitDailyAward()
    //{
    //	if (!GlobalData.KeyValues.ContainsKey("_dailyAward"))
    //	{
    //		GlobalData.KeyValues.Add("_dailyAward", string.Empty);
    //		this.DailyAwardObj.SetActive(true);
    //	}
    //	else
    //	{
    //		string text = GlobalData.KeyValues["_dailyAward"];
    //		string strB = DateTime.Today.ToString();
    //		if (text.CompareTo(strB) < 0)
    //		{
    //			this.DailyAwardObj.SetActive(true);
    //		}
    //	}
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !this.DialogPanel.activeSelf && !this.SelectPanel.activeSelf)//快速存档
        {
            //string content = RuntimeData.Instance.Save();
            //SaveManager.SetSave("fastsave", content);
            //AudioManager.Instance.PlayEffect("音效.装备");
        }
        else if (Input.GetKeyDown(KeyCode.F2) && !this.DialogPanel.activeSelf && !this.SelectPanel.activeSelf)//快速读档
        {
            //string save = SaveManager.GetSave("fastsave");
            ////RuntimeData.Instance.Load(save);
            //RuntimeData.Instance.gameEngine.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            this.TeamPanelObj.SetActive(false);
            this.RolePanel.SetActive(false);
            this.SystemPanelObj.SetActive(false);
            this.ItemDetailPanelObj.SetActive(false);
            this.AchievementPanelObj.SetActive(false);
            this.LogPanel.SetActive(false);
            this.ItemPanel.SetActive(false);
        }
    }

    //public void OnTeamButton()
    //{
    //	if (this.TeamPanelObj.activeSelf)
    //	{
    //		this.TeamPanelObj.SetActive(false);
    //	}
    //	else
    //	{
    //		this.ShowTeam();
    //	}
    //}

    //// Token: 0x060004E8 RID: 1256 RVA: 0x0002C1E4 File Offset: 0x0002A3E4
    //public void OnItemButton()
    //{
    //	if (this.ItemPanel.activeSelf)
    //	{
    //		this.ItemPanel.SetActive(false);
    //	}
    //	else
    //	{
    //		this.ShowItemPanel();
    //	}
    //}

    //// Token: 0x060004E9 RID: 1257 RVA: 0x0002C210 File Offset: 0x0002A410
    //public void OnLogButton()
    //{
    //	if (this.LogPanel.activeSelf)
    //	{
    //		this.LogPanel.SetActive(false);
    //	}
    //	else
    //	{
    //		this.ShowLogPanel();
    //	}
    //}

    //// Token: 0x060004EA RID: 1258 RVA: 0x0002C23C File Offset: 0x0002A43C
    //public void OnSystemButton()
    //{
    //	this.SystemPanelObj.GetComponent<SystemPanelUI>().Show();
    //}

    //// Token: 0x060004EB RID: 1259 RVA: 0x0002C250 File Offset: 0x0002A450
    //public void ShowItemPanel()
    //{
    //	this.itemMenu.Show("物品列表", RuntimeData.Instance.Items, delegate(object ret)
    //	{
    //		ItemInstance item = ret as ItemInstance;
    //		this.SelectItem(item);
    //	}, delegate()
    //	{
    //	}, null);
    //}

    //// Token: 0x060004EC RID: 1260 RVA: 0x0002C2A4 File Offset: 0x0002A4A4
    //public void ShowTeam()
    //{
    //	this.TeamPanelObj.SetActive(true);
    //	this.TeamPanelObj.GetComponent<TeamPanelUI>().Show(delegate(string roleKey)
    //	{
    //		this.RoleSelectPanelObj.SetActive(false);
    //		this.TeamPanelObj.SetActive(false);
    //		this.RolePanel.GetComponent<RolePanelUI>().Show(RuntimeData.Instance.GetTeamRole(roleKey), delegate
    //		{
    //			this.ShowTeam();
    //		}, true);
    //	});
    //}

    //// Token: 0x060004ED RID: 1261 RVA: 0x0002C2DC File Offset: 0x0002A4DC
    //public void SelectItem(ItemInstance item)
    //{
    //	ItemDetailMode itemMode = ItemDetailMode.Disable;
    //	switch (item.Type)
    //	{
    //	case ItemType.Costa:
    //	case ItemType.Mission:
    //		itemMode = ItemDetailMode.Disable;
    //		goto IL_A0;
    //	case ItemType.Weapon:
    //	case ItemType.Armor:
    //	case ItemType.Accessories:
    //		itemMode = ItemDetailMode.Equipable;
    //		goto IL_A0;
    //	case ItemType.Book:
    //		itemMode = ItemDetailMode.Studiable;
    //		goto IL_A0;
    //	case ItemType.Canzhang:
    //		RuntimeData.Instance.addItem(item, -1);
    //		return;
    //	}
    //	itemMode = ItemDetailMode.Usable;
    //	IL_A0:
    //	this.ItemDetailPanelObj.GetComponent<ItemSkillDetailPanelUI>().Show(item, itemMode, delegate()
    //	{
    //		this.itemMenu.Hide();
    //		this.RoleSelectPanelObj.SetActive(true);
    //		this.roleSelectMenu.Show(RuntimeData.Instance.Team, delegate(string ret)
    //		{
    //			this.RoleSelectPanelObj.SetActive(false);
    //			Role teamRole = RuntimeData.Instance.GetTeamRole(ret);
    //			this.OnUseItem(item, teamRole, itemMode);
    //		}, delegate(object obj)
    //		{
    //			Role r = obj as Role;
    //			return item.CanEquip(r);
    //		});
    //	}, delegate()
    //	{
    //		this.itemMenu.gameObject.SetActive(true);
    //	}, null);
    //}

    //// Token: 0x060004EE RID: 1262 RVA: 0x0002C3C0 File Offset: 0x0002A5C0
    //public void OnUseItem(ItemInstance item, Role role, ItemDetailMode itemMode)
    //{
    //	if (!item.CanEquip(role))
    //	{
    //		this.messageBox.Show("装备选取错误", "你的人物不满足物品使用条件，需要：\n<color='red'>" + item.EquipCase + "</color>", Color.white, delegate
    //		{
    //			this.itemMenu.gameObject.SetActive(true);
    //		}, "确认");
    //		return;
    //	}
    //	if (itemMode == ItemDetailMode.Equipable || itemMode == ItemDetailMode.Studiable)
    //	{
    //		ItemInstance equipment = role.GetEquipment(item.Type);
    //		if (equipment != null)
    //		{
    //			role.Equipment.Remove(equipment);
    //			AudioManager.Instance.PlayEffect("音效.装备");
    //			RuntimeData.Instance.addItem(equipment, 1);
    //		}
    //		role.Equipment.Add(item);
    //		AudioManager.Instance.PlayEffect("音效.装备");
    //		RuntimeData.Instance.addItem(item, -1);
    //		this.RolePanel.GetComponent<RolePanelUI>().Show(role, null, true);
    //		this.RolePanel.GetComponent<RolePanelUI>().SetFocusZhuangbei();
    //	}
    //	else if (itemMode == ItemDetailMode.Usable)
    //	{
    //		List<StoryAction> dialogs = new List<StoryAction>();
    //		if (item.Type == ItemType.Upgrade)
    //		{
    //			ItemResult itemResult = item.TryUse(role, role);
    //			if (itemResult.MaxHp != 0)
    //			{
    //				role.maxhp = role.Attributes["maxhp"] + itemResult.MaxHp;
    //				if (role.maxhp >= CommonSettings.MAX_HPMP)
    //				{
    //					role.maxhp = CommonSettings.MAX_HPMP;
    //				}
    //				role.hp = role.Attributes["maxhp"];
    //				dialogs.Add(StoryAction.CreateDialog(role, "气血上限增加了【" + itemResult.MaxHp.ToString() + "】！"));
    //			}
    //			if (itemResult.MaxMp != 0)
    //			{
    //				role.maxmp = role.Attributes["maxmp"] + itemResult.MaxMp;
    //				if (role.maxmp >= CommonSettings.MAX_HPMP)
    //				{
    //					role.maxmp = CommonSettings.MAX_HPMP;
    //				}
    //				role.mp = role.Attributes["maxmp"];
    //				dialogs.Add(StoryAction.CreateDialog(role, "内力上限增加了【" + itemResult.MaxMp.ToString() + "】！"));
    //			}
    //			RuntimeData.Instance.addItem(item, -1);
    //			AudioManager.Instance.PlayEffect("音效.升级");
    //		}
    //		else if (item.Type == ItemType.SpeicalSkillBook)
    //		{
    //			foreach (SpecialSkillInstance specialSkillInstance in role.SpecialSkills)
    //			{
    //				if (specialSkillInstance.name == item.GetItemSkill().SkillName)
    //				{
    //					this.messageBox.Show("错误", "不能使用,该角色已经学会该项技能", Color.white, delegate
    //					{
    //						this.itemMenu.gameObject.SetActive(true);
    //					}, "确认");
    //					return;
    //				}
    //			}
    //			SpecialSkillInstance specialSkillInstance2 = new SpecialSkillInstance
    //			{
    //				name = item.GetItemSkill().SkillName
    //			};
    //			specialSkillInstance2.Owner = role;
    //			role.SpecialSkills.Add(specialSkillInstance2);
    //			dialogs.Add(StoryAction.CreateDialog(role, "领悟了特殊技能：【" + item.GetItemSkill().SkillName + "】！"));
    //			RuntimeData.Instance.addItem(item, -1);
    //		}
    //		else if (item.Type == ItemType.TalentBook)
    //		{
    //			string skillName = item.GetItemSkill().SkillName;
    //			foreach (string text in role.Talents)
    //			{
    //				if (text.Equals(skillName))
    //				{
    //					this.messageBox.Show("错误", "不能使用,该角色已经有该项天赋", Color.white, delegate
    //					{
    //						this.itemMenu.gameObject.SetActive(true);
    //					}, "确认");
    //					return;
    //				}
    //			}
    //			int num = 0;
    //			if (!role.CanLearnTalent(skillName, ref num))
    //			{
    //				this.messageBox.Show("错误", "不能使用,该角色剩余武学常识不够，需要" + num.ToString(), Color.white, delegate
    //				{
    //					this.itemMenu.gameObject.SetActive(true);
    //				}, "确认");
    //				return;
    //			}
    //			role.Talents.Add(skillName);
    //			dialogs.Add(StoryAction.CreateDialog(role, "领悟了天赋：【" + skillName + "】！"));
    //			RuntimeData.Instance.addItem(item, -1);
    //		}
    //		else if (item.Type == ItemType.Special)
    //		{
    //			if (item.Name == "刀")
    //			{
    //				if (role.Female || role.Animal)
    //				{
    //					this.messageBox.Show("无法阉割！", "只有男性可以自宫", Color.white, delegate
    //					{
    //						this.itemMenu.gameObject.SetActive(true);
    //					}, "确认");
    //					return;
    //				}
    //				if (role.HasTalent("阉人"))
    //				{
    //					this.messageBox.Show("无法阉割！", "已经阉割过了！想割也没得割喽~", Color.white, delegate
    //					{
    //						this.itemMenu.gameObject.SetActive(true);
    //					}, "确认");
    //					return;
    //				}
    //				role.AddTalent("阉人");
    //				int num2 = (int)((double)role.Attributes["maxhp"] / 3.0);
    //				int num3 = (int)((double)role.Attributes["maxmp"] / 2.0);
    //				role.maxhp -= num2;
    //				role.hp -= num2;
    //				role.maxmp -= num3;
    //				role.mp -= num3;
    //				dialogs.Add(StoryAction.CreateDialog(role, role.Name + "已经变成了太监！从今以后可以重新做人，开启第二人生了。"));
    //				dialogs.Add(StoryAction.CreateDialog(role, string.Concat(new object[]
    //				{
    //					role.Name,
    //					"减少最大气血",
    //					num2,
    //					"点！ T_T"
    //				})));
    //				dialogs.Add(StoryAction.CreateDialog(role, string.Concat(new object[]
    //				{
    //					role.Name,
    //					"减少最大内力",
    //					num3,
    //					"点！"
    //				})));
    //			}
    //			if (item.Name == "洗练书")
    //			{
    //				List<SkillBox> list = new List<SkillBox>();
    //				foreach (SpecialSkillInstance item2 in role.SpecialSkills)
    //				{
    //					list.Add(item2);
    //				}
    //				foreach (SkillInstance item3 in role.Skills)
    //				{
    //					list.Add(item3);
    //				}
    //				foreach (InternalSkillInstance internalSkillInstance in role.InternalSkills)
    //				{
    //					if (internalSkillInstance != role.GetEquippedInternalSkill())
    //					{
    //						list.Add(internalSkillInstance);
    //					}
    //				}
    //				this.SkillSelectPanelObj.GetComponent<SkillSelectPanelUI>().Show(list, delegate(object skill)
    //				{
    //					SkillBox skillBox = skill as SkillBox;
    //					if (skillBox != null)
    //					{
    //						if (skillBox is SkillInstance)
    //						{
    //							role.Skills.Remove(skillBox as SkillInstance);
    //						}
    //						else if (skillBox is InternalSkillInstance)
    //						{
    //							role.InternalSkills.Remove(skillBox as InternalSkillInstance);
    //						}
    //						else if (skillBox is SpecialSkillInstance)
    //						{
    //							role.SpecialSkills.Remove(skillBox as SpecialSkillInstance);
    //						}
    //						dialogs.Add(StoryAction.CreateDialog(role, string.Format("{0}的技能【{1}】移除了！", role.Name, skillBox.Name)));
    //						RuntimeData.Instance.addItem(item, -1);
    //						AudioManager.Instance.PlayEffect("音效.恢复2");
    //						this.ShowDialogs(dialogs, null);
    //					}
    //				});
    //			}
    //		}
    //		else if (item.Type == ItemType.Canzhang)
    //		{
    //			string canzhangSkill = item.CanzhangSkill;
    //			bool flag = false;
    //			foreach (SkillInstance skillInstance in role.Skills)
    //			{
    //				if (skillInstance.Name == canzhangSkill && skillInstance.MaxLevel < 20)
    //				{
    //					dialogs.Add(StoryAction.CreateDialog(role, string.Format("{0}等级上限提高！", skillInstance.Name)));
    //					flag = true;
    //					break;
    //				}
    //				if (skillInstance.Name == canzhangSkill && skillInstance.MaxLevel >= 20)
    //				{
    //					dialogs.Add(StoryAction.CreateDialog(role, string.Format("{0}等级已经达到上限，不能再提高了", skillInstance.Name)));
    //					break;
    //				}
    //			}
    //			//foreach (InternalSkillInstance internalSkillInstance2 in role.InternalSkills)
    //			//{
    //			//	if (internalSkillInstance2.Name == canzhangSkill && internalSkillInstance2.MaxLevel < 20)
    //			//	{
    //			//		dialogs.Add(StoryAction.CreateDialog(role, string.Format("{0}等级上限提高！", internalSkillInstance2.Name)));
    //			//		flag = true;
    //			//		break;
    //			//	}
    //			//	if (internalSkillInstance2.Name == canzhangSkill && internalSkillInstance2.MaxLevel >= 20)
    //			//	{
    //			//		dialogs.Add(StoryAction.CreateDialog(role, string.Format("{0}等级已经达到上限，不能再提高了", internalSkillInstance2.Name)));
    //			//		break;
    //			//	}
    //			//}
    //			if (flag)
    //			{
    //				RuntimeData.Instance.addItem(item, -1);
    //			}
    //			else
    //			{
    //				//this.messageBox.Show("错误！", string.Format("错误,【{0}】没有技能【{1}】", role.Name, canzhangSkill), Color.white, delegate
    //				//{
    //				//	this.itemMenu.gameObject.SetActive(true);
    //				//}, "确认");
    //			}
    //		}
    //		if (dialogs.Count > 0)
    //		{
    //			this.ShowDialogs(dialogs, null);
    //		}
    //	}
    //}

    // Token: 0x060004EF RID: 1263 RVA: 0x0002CFD4 File Offset: 0x0002B1D4
    public void ShowLogPanel()
	{
		this.LogPanel.SetActive(true);
		//this.logMenu.Show(null);
	}

	public void OnMapScaleChanged()
	{
		float num;
		//if (Configer.IsBigmapFullScreen)
		//{
		//	num = 0.5f;
		//}
		//else
		//{
		//	num = 1f;
		//}
		//this.BigMap.GetComponent<RectTransform>().localScale = new Vector3(num, num, 1f);
		this.ResetBigMapLocalPosition();
	}

	private void InitScale()
	{
		this.OnMapScaleChanged();
	}

	private void ResetBigMapLocalPosition()
	{
		this.BigMap.transform.localPosition = new Vector3(-570f, 320f, 0f);
	}

	public void DailyAward(GameObject sender)
	{
		try
		{
			string value = string.Concat(new string[]
			{
				SystemInfo.operatingSystem,
				"_",
				SystemInfo.deviceUniqueIdentifier,
				"_",
				SystemInfo.deviceName
			});
			//base.StartCoroutine(Tools.ServerRequest("http://120.24.166.63:8080/JY-X/award", new Hashtable
			//{
			//	{
			//		"uid",
			//		value
			//	},
			//	{
			//		"time",
			//		DateTime.Now
			//	}
			//}, delegate(object resp)
			//{
			//	Hashtable hashtable = resp as Hashtable;
			//	if (hashtable == null)
			//	{
			//		this.ShowDialog("主角", "获取奖励出错", null);
			//		return;
			//	}
			//	if (hashtable["status"].ToString() != "0")
			//	{
			//		this.ShowDialog("主角", "奖品虽好，不要作弊哦！", null);
			//	}
			//	else
			//	{
			//		GlobalData.KeyValues["_dailyAward"] = DateTime.Today.ToString();
			//		this.LoadStory(hashtable["story"].ToString());
			//	}
			//	sender.SetActive(false);
			//}));
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			//this.ShowDialog("主角", "无法连接服务器，请检查网络设置", null);
		}
	}
}
