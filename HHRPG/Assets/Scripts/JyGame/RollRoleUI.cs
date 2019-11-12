using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JyGame
{
    public class RollRoleUI : MonoBehaviour
    {
        private List<int> results = new List<int>();

        private Role makeRole;

        private int makeMoney;

        private List<Item> makeItems;

        private string selectHeadKey;

  
        //		// Token: 0x17000172 RID: 370
        //		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0002FF74 File Offset: 0x0002E174
        //		public SelectMenu selectMenu
        //		{
        //			get
        //			{
        //				return this.selectPanelObj.transform.FindChild("SelectMenu").GetComponent<SelectMenu>();
        //			}
        //		}

        //		// Token: 0x06000562 RID: 1378 RVA: 0x0002FF90 File Offset: 0x0002E190
        //		public void LoadSelection(string title, List<string> opts, CommonSettings.IntCallBack callback)
        //		{
        //			StoryAction storyAction = new StoryAction();
        //			storyAction.type = "SELECT";
        //			storyAction.value = "汉家松鼠#" + title;
        //			foreach (string text in opts)
        //			{
        //				string str = text;
        //				StoryAction storyAction2 = storyAction;
        //				storyAction2.value = storyAction2.value + "#" + str;
        //			}
        //			this.LoadSelection(storyAction, callback);
        //		}

        //		// Token: 0x06000563 RID: 1379 RVA: 0x00030030 File Offset: 0x0002E230
        //		public void LoadSelection(StoryAction selection, CommonSettings.IntCallBack callback)
        //		{
        //			this.selectMenu.Clear();
        //			string[] array = selection.value.Split(new char[]
        //			{
        //				'#'
        //			});
        //			string text = array[0];
        //			string text2 = array[1];
        //			this.SelectTitle.text = text2;
        //			for (int i = 2; i < array.Length; i++)
        //			{
        //				int index = i - 2;
        //				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MultiSelectItemObj);
        //				gameObject.transform.FindChild("Text").GetComponent<Text>().text = array[i];
        //				gameObject.GetComponent<Button>().onClick.AddListener(delegate()
        //				{
        //					this.selectPanelObj.SetActive(false);
        //					this.selectMenu.Hide();
        //					callback(index);
        //				});
        //				this.selectMenu.AddItem(gameObject);
        //			}
        //			this.selectPanelObj.SetActive(true);
        //			this.selectMenu.Show(null);
        //		}

        //		// Token: 0x06000564 RID: 1380 RVA: 0x00030130 File Offset: 0x0002E330
        //		public void Show()
        //		{
        //			if (!RuntimeData.Instance.IsInited)
        //			{
        //				RuntimeData.Instance.Init();
        //			}
        //			base.gameObject.SetActive(true);
        //			this.LoadSelection(new StoryAction
        //			{
        //				type = "SELECT",
        //				value = "汉家松鼠#在来到这个世界之前，请允许询问您几个问题#继续..."
        //			}, new CommonSettings.IntCallBack(this.SelectCallback1));
        //			this.results.Clear();
        //		}

        //		// Token: 0x06000565 RID: 1381 RVA: 0x0003019C File Offset: 0x0002E39C
        //		private void SelectCallback1(int rst)
        //		{
        //			this.LoadSelection("你希望你在武侠小说中的出身是", new List<string>
        //			{
        //				"商人的儿子",
        //				"大草原上长大的孩子",
        //				"名门世家",
        //				"市井流浪的汉子",
        //				"疯子",
        //				"书香门第"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback2));
        //		}

        //		// Token: 0x06000566 RID: 1382 RVA: 0x0003020C File Offset: 0x0002E40C
        //		private void SelectCallback2(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("以下你觉得最宝贵的是", new List<string>
        //			{
        //				"无尽的财宝",
        //				"永恒的爱情",
        //				"坚强的意志",
        //				"自由",
        //				"至高无上的权力"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback3));
        //		}

        //		// Token: 0x06000567 RID: 1383 RVA: 0x0003027C File Offset: 0x0002E47C
        //		private void SelectCallback3(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("以下你觉得最可恶的行为是", new List<string>
        //			{
        //				"调戏妇女",
        //				"欺软怕硬",
        //				"偷奸耍滑",
        //				"切JJ练神功",
        //				"有美女不泡"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback31));
        //		}

        //		// Token: 0x06000568 RID: 1384 RVA: 0x000302EC File Offset: 0x0002E4EC
        //		private void SelectCallback31(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("你最喜欢的兵刃是", new List<string>
        //			{
        //				"拳",
        //				"剑",
        //				"刀",
        //				"暗器"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback32));
        //		}

        //		// Token: 0x06000569 RID: 1385 RVA: 0x00030350 File Offset: 0x0002E550
        //		private void SelectCallback32(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("以下女性角色你最喜欢的是", new List<string>
        //			{
        //				"黄蓉",
        //				"小龙女",
        //				"郭襄",
        //				"梅超风",
        //				"周芷若"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback33));
        //		}

        //		// Token: 0x0600056A RID: 1386 RVA: 0x000303C0 File Offset: 0x0002E5C0
        //		private void SelectCallback33(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("以下男性角色你最喜欢的是", new List<string>
        //			{
        //				"张无忌",
        //				"郭靖",
        //				"杨过",
        //				"令狐冲",
        //				"林平之"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback4));
        //		}

        //		// Token: 0x0600056B RID: 1387 RVA: 0x00030430 File Offset: 0x0002E630
        //		private void SelectCallback4(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("以下你觉得最牛逼的人是", new List<string>
        //			{
        //				"乔峰",
        //				"韦小宝",
        //				"金庸先生",
        //				"东方不败",
        //				"汉家松鼠",
        //				"半瓶神仙醋"
        //			}, new CommonSettings.IntCallBack(this.SelectCallback5));
        //		}

        //		// Token: 0x0600056C RID: 1388 RVA: 0x000304AC File Offset: 0x0002E6AC
        //		private void SelectCallback5(int rst)
        //		{
        //			this.results.Add(rst);
        //			List<string> list = new List<string>();
        //			if (RuntimeData.Instance.Round == 1)
        //			{
        //				list.Add("简单（新手推荐）");
        //			}
        //			list.Add("<color='yellow'>进阶（难度较高）</color>");
        //			list.Add("<color='red'>炼狱（极度变态狂选这个..请慎重)</color>");
        //			this.LoadSelection("选择你的游戏难度", list, new CommonSettings.IntCallBack(this.SelectCallback6));
        //		}

        //		// Token: 0x0600056D RID: 1389 RVA: 0x00030514 File Offset: 0x0002E714
        //		private void SelectCallback6(int rst)
        //		{
        //			this.results.Add(rst);
        //			this.LoadSelection("请输入你的名字", new List<string>
        //			{
        //				"继续.."
        //			}, new CommonSettings.IntCallBack(this.SelectCallback7));
        //		}

        //		// Token: 0x0600056E RID: 1390 RVA: 0x00030558 File Offset: 0x0002E758
        //		private void SelectCallback7(int rst)
        //		{
        //			this.nameInputPanel.Show("小虾米", delegate(string name)
        //			{
        //				RuntimeData.Instance.maleName = name;
        //				this.SelectCallback8();
        //			});
        //		}

        //		// Token: 0x0600056F RID: 1391 RVA: 0x00030578 File Offset: 0x0002E778
        //		private void SelectCallback8()
        //		{
        //			this.headSelectPanelObj.SetActive(true);
        //			this.headSelectMenu.Show(this.heads, delegate(string selectKey)
        //			{
        //				this.headSelectPanelObj.SetActive(false);
        //				this.selectHeadKey = selectKey;
        //				this.LoadSelection("欢迎来到金庸群侠传的世界", new List<string>
        //				{
        //					"继续.."
        //				}, delegate(int rr)
        //				{
        //					this.Reset();
        //				});
        //			});
        //		}

        //		// Token: 0x06000570 RID: 1392 RVA: 0x000305B0 File Offset: 0x0002E7B0
        //		private void Reset()
        //		{
        //			this.RoleConfirmButtonObj.SetActive(true);
        //			this.RoleResetButtonObj.SetActive(true);
        //			this.rolePanelObj.transform.FindChild("CancelButton").gameObject.SetActive(false);
        //			this.MakeBeginningCondition();
        //			this.MakeRandomCondition();
        //			this.ShowBeginningCondition();
        //		}

        //		// Token: 0x06000571 RID: 1393 RVA: 0x00030608 File Offset: 0x0002E808
        //		private void ShowBeginningCondition()
        //		{
        //			this.rolePanel.Show(this.makeRole, null, true);
        //		}

        //		// Token: 0x06000572 RID: 1394 RVA: 0x00030620 File Offset: 0x0002E820
        //		private void MakeRandomCondition()
        //		{
        //			string[] array = new string[]
        //			{
        //				"gengu",
        //				"bili",
        //				"fuyuan",
        //				"shenfa",
        //				"dingli",
        //				"wuxing",
        //				"quanzhang",
        //				"jianfa",
        //				"daofa",
        //				"qimen"
        //			};
        //			for (int i = 0; i < 3; i++)
        //			{
        //				int randomInt = Tools.GetRandomInt(0, array.Length - 1);
        //				string type = array[randomInt];
        //				CommonSettings.adjustAttr(this.makeRole, type, 10);
        //			}
        //			for (int j = 0; j < 10; j++)
        //			{
        //				int randomInt2 = Tools.GetRandomInt(0, array.Length - 1);
        //				string type2 = array[randomInt2];
        //				CommonSettings.adjustAttr(this.makeRole, type2, 1);
        //			}
        //		}

        //		// Token: 0x06000573 RID: 1395 RVA: 0x000306F0 File Offset: 0x0002E8F0
        //		private void MakeBeginningCondition()
        //		{
        //			this.makeRole = ResourceManager.Get<Role>("主角").Clone();
        //			this.makeRole.Head = this.selectHeadKey;
        //			this.makeRole.Name = RuntimeData.Instance.maleName;
        //			this.makeMoney = 100;
        //			this.makeItems = new List<Item>();
        //			this.makeItems.Add(Item.GetItem("小还丹"));
        //			this.makeItems.Add(Item.GetItem("小还丹"));
        //			this.makeItems.Add(Item.GetItem("小还丹"));
        //			switch (this.results[0])
        //			{
        //			case 0:
        //				this.makeMoney += 5000;
        //				CommonSettings.adjustAttr(this.makeRole, "bili", -5);
        //				this.makeItems.Add(Item.GetItem("黑玉断续膏"));
        //				this.makeItems.Add(Item.GetItem("九转熊蛇丸"));
        //				this.makeItems.Add(Item.GetItem("金丝道袍"));
        //				this.makeItems.Add(Item.GetItem("金头箍"));
        //				this.makeRole.Animation = "zydx";
        //				break;
        //			case 1:
        //			{
        //				CommonSettings.adjustAttr(this.makeRole, "shenfa", 15);
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", -2);
        //				CommonSettings.adjustAttr(this.makeRole, "quanzhang", 15);
        //				Role role = this.makeRole;
        //				role.TalentValue += "#猎人";
        //				this.makeRole.Animation = "caoyuan";
        //				break;
        //			}
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "fuyuan", 3);
        //				CommonSettings.adjustAttr(this.makeRole, "bili", -3);
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 2);
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 20);
        //				CommonSettings.adjustAttr(this.makeRole, "jianfa", 2);
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 2);
        //				this.makeItems.Add(Item.GetItem("银手镯"));
        //				this.makeMoney += 100;
        //				this.makeRole.Animation = "huodu";
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "fuyuan", -5);
        //				CommonSettings.adjustAttr(this.makeRole, "bili", 12);
        //				CommonSettings.adjustAttr(this.makeRole, "daofa", 15);
        //				CommonSettings.adjustAttr(this.makeRole, "qimen", 12);
        //				this.makeItems.Add(Item.GetItem("草帽"));
        //				this.makeRole.Animation = "shijing";
        //				this.makeMoney = 0;
        //				break;
        //			case 4:
        //			{
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 35);
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 10);
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //				Role role2 = this.makeRole;
        //				role2.TalentValue += "#神经病";
        //				this.makeRole.Animation = "fengzi";
        //				break;
        //			}
        //			case 5:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 20);
        //				CommonSettings.adjustAttr(this.makeRole, "bili", 1);
        //				CommonSettings.adjustAttr(this.makeRole, "shenfa", -10);
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", -5);
        //				this.makeRole.Animation = "xiake";
        //				break;
        //			}
        //			switch (this.results[1])
        //			{
        //			case 0:
        //				this.makeMoney += 1000;
        //				break;
        //			case 1:
        //				CommonSettings.adjustAttr(this.makeRole, "fuyuan", 15);
        //				break;
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 15);
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "shenfa", 15);
        //				break;
        //			case 4:
        //			{
        //				Role role3 = this.makeRole;
        //				role3.TalentValue += "#自我主义";
        //				break;
        //			}
        //			}
        //			switch (this.results[2])
        //			{
        //			case 0:
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 9);
        //				break;
        //			case 1:
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 6);
        //				CommonSettings.adjustAttr(this.makeRole, "bili", 6);
        //				break;
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 10);
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //				break;
        //			case 4:
        //			{
        //				Role role4 = this.makeRole;
        //				role4.TalentValue += "#好色";
        //				break;
        //			}
        //			}
        //			switch (this.results[3])
        //			{
        //			case 0:
        //				CommonSettings.adjustAttr(this.makeRole, "quanzhang", 10);
        //				break;
        //			case 1:
        //				CommonSettings.adjustAttr(this.makeRole, "jianfa", 10);
        //				break;
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "daofa", 20);
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "qimen", 20);
        //				break;
        //			}
        //			switch (this.results[4])
        //			{
        //			case 0:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 5);
        //				break;
        //			case 1:
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 5);
        //				break;
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "fuyuan", 5);
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 5);
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "quanzhang", 6);
        //				CommonSettings.adjustAttr(this.makeRole, "bili", 6);
        //				break;
        //			case 4:
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 10);
        //				break;
        //			}
        //			switch (this.results[5])
        //			{
        //			case 0:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 5);
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //				break;
        //			case 1:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", -10);
        //				CommonSettings.adjustAttr(this.makeRole, "fuyuan", 15);
        //				CommonSettings.adjustAttr(this.makeRole, "bili", 5);
        //				break;
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 5);
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 5);
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 10);
        //				break;
        //			case 4:
        //				CommonSettings.adjustAttr(this.makeRole, "jianfa", 10);
        //				CommonSettings.adjustAttr(this.makeRole, "dingli", 10);
        //				break;
        //			}
        //			switch (this.results[6])
        //			{
        //			case 0:
        //				CommonSettings.adjustAttr(this.makeRole, "bili", 10);
        //				CommonSettings.adjustAttr(this.makeRole, "quanzhang", 9);
        //				break;
        //			case 1:
        //				CommonSettings.adjustAttr(this.makeRole, "fuyuan", 30);
        //				break;
        //			case 2:
        //				CommonSettings.adjustAttr(this.makeRole, "wuxing", 13);
        //				CommonSettings.adjustAttr(this.makeRole, "jianfa", 5);
        //				CommonSettings.adjustAttr(this.makeRole, "daofa", 5);
        //				CommonSettings.adjustAttr(this.makeRole, "quanzhang", 5);
        //				CommonSettings.adjustAttr(this.makeRole, "qimen", 5);
        //				break;
        //			case 3:
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 20);
        //				break;
        //			case 4:
        //				this.makeRole.InternalSkills[0].level = 20;
        //				CommonSettings.adjustAttr(this.makeRole, "gengu", 10);
        //				this.makeItems.Add(Item.GetItem("松果"));
        //				this.makeItems.Add(Item.GetItem("松果"));
        //				this.makeItems.Add(Item.GetItem("松果"));
        //				break;
        //			case 5:
        //				this.makeItems.Add(Item.GetItem("天王保命丹"));
        //				this.makeItems.Add(Item.GetItem("天王保命丹"));
        //				this.makeItems.Add(Item.GetItem("天王保命丹"));
        //				this.makeItems.Add(Item.GetItem("天王保命丹"));
        //				this.makeItems.Add(Item.GetItem("天王保命丹"));
        //				this.makeItems.Add(Item.GetItem("天王保命丹"));
        //				break;
        //			}
        //			if (RuntimeData.Instance.Round == 1)
        //			{
        //				switch (this.results[7])
        //				{
        //				case 0:
        //					RuntimeData.Instance.GameMode = "normal";
        //					RuntimeData.Instance.FriendlyFire = false;
        //					break;
        //				case 1:
        //					RuntimeData.Instance.GameMode = "hard";
        //					RuntimeData.Instance.FriendlyFire = true;
        //					break;
        //				case 2:
        //					RuntimeData.Instance.GameMode = "crazy";
        //					RuntimeData.Instance.FriendlyFire = true;
        //					break;
        //				}
        //			}
        //			else
        //			{
        //				int num = this.results[7];
        //				if (num != 0)
        //				{
        //					if (num == 1)
        //					{
        //						RuntimeData.Instance.GameMode = "crazy";
        //						RuntimeData.Instance.FriendlyFire = true;
        //					}
        //				}
        //				else
        //				{
        //					RuntimeData.Instance.GameMode = "hard";
        //					RuntimeData.Instance.FriendlyFire = true;
        //				}
        //			}
        //			List<string> list = new List<string>();
        //			List<string> list2 = new List<string>();
        //			list.Clear();
        //			list2.Clear();
        //			switch (RuntimeData.Instance.Round)
        //			{
        //			case 1:
        //				if (RuntimeData.Instance.GameMode == "normal")
        //				{
        //					this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //					this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //					this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //					this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //					this.makeItems.Add(Item.GetItem("新手礼包-大蟠桃"));
        //				}
        //				break;
        //			case 2:
        //				list.Add("佛光普照");
        //				list.Add("百变千幻云雾十三式秘籍");
        //				list.Add("反两仪刀法");
        //				list.Add("伏魔杖法");
        //				list2.Add("灭仙爪");
        //				list2.Add("倚天剑");
        //				list2.Add("屠龙刀");
        //				list2.Add("打狗棒");
        //				this.makeItems.Add(Item.GetItem(list[Tools.GetRandomInt(0, list.Count) % list.Count]));
        //				this.makeItems.Add(Item.GetItem(list2[Tools.GetRandomInt(0, list2.Count) % list2.Count]));
        //				break;
        //			case 3:
        //				list.Add("隔空取物");
        //				list.Add("妙手仁心");
        //				list.Add("飞向天际");
        //				list.Add("血刀");
        //				list2.Add("仙丽雅的项链");
        //				list2.Add("李延宗的项链");
        //				list2.Add("王语嫣的武学概要");
        //				list2.Add("神木王鼎");
        //				this.makeItems.Add(Item.GetItem(list[Tools.GetRandomInt(0, list.Count) % list.Count]));
        //				this.makeItems.Add(Item.GetItem(list2[Tools.GetRandomInt(0, list2.Count) % list2.Count]));
        //				break;
        //			default:
        //				list.Add("碎裂的怒吼");
        //				list.Add("沾衣十八跌");
        //				list.Add("灵心慧质");
        //				list.Add("不老长春功法");
        //				list2.Add("仙丽雅的项链");
        //				list2.Add("李延宗的项链");
        //				list2.Add("王语嫣的武学概要");
        //				list2.Add("神木王鼎");
        //				this.makeItems.Add(Item.GetItem(list[Tools.GetRandomInt(0, list.Count) % list.Count]));
        //				this.makeItems.Add(Item.GetItem(list2[Tools.GetRandomInt(0, list2.Count) % list2.Count]));
        //				break;
        //			}
        //			string[] array = RuntimeData.Instance.TrialRoles.Split(new char[]
        //			{
        //				'#'
        //			});
        //			int num2 = array.Length;
        //			List<string> list3 = new List<string>();
        //			if (num2 >= 3)
        //			{
        //				if (num2 >= 3 && num2 < 6)
        //				{
        //					this.makeItems.Add(Item.GetItem("王母蟠桃"));
        //					this.makeItems.Add(Item.GetItem("道家仙丹"));
        //				}
        //				else if (num2 >= 6 && num2 < 9)
        //				{
        //					this.makeItems.Add(Item.GetItem("灵心慧质"));
        //					this.makeItems.Add(Item.GetItem("妙手仁心"));
        //				}
        //				else if (num2 >= 9 && num2 < 12)
        //				{
        //					this.makeItems.Add(Item.GetItem("素心神剑心得"));
        //					this.makeItems.Add(Item.GetItem("太极心得手抄本"));
        //					this.makeItems.Add(Item.GetItem("乾坤大挪移心法"));
        //				}
        //				else if (num2 >= 12 && num2 < 15)
        //				{
        //					this.makeItems.Add(Item.GetItem("沾衣十八跌"));
        //					this.makeItems.Add(Item.GetItem("易筋经"));
        //					this.makeItems.Add(Item.GetItem("厚黑学"));
        //				}
        //				else if (num2 >= 15 && num2 < 20)
        //				{
        //					this.makeItems.Add(Item.GetItem("武穆遗书"));
        //					this.makeItems.Add(Item.GetItem("笑傲江湖曲"));
        //				}
        //				else if (num2 >= 20)
        //				{
        //					this.makeItems.Add(Item.GetItem("真葵花宝典"));
        //				}
        //			}
        //		}

        //		// Token: 0x06000574 RID: 1396 RVA: 0x000315A8 File Offset: 0x0002F7A8
        //		private void JumpSelectCallback(int rst)
        //		{
        //			RuntimeData.Instance.Money = this.makeMoney;
        //			RuntimeData.Instance.Team.Clear();
        //			RuntimeData.Instance.Follow.Clear();
        //			RuntimeData.Instance.Team.Add(this.makeRole);
        //			RuntimeData.Instance.Items.Clear();
        //			foreach (Item item in this.makeItems)
        //			{
        //				Item item2 = item;
        //				RuntimeData.Instance.addItem(item2, 1);
        //			}
        //			List<string> list = new List<string>();
        //			list.Clear();
        //			switch (RuntimeData.Instance.Round)
        //			{
        //			case 1:
        //				break;
        //			case 2:
        //				list.Add("鲁连荣");
        //				list.Add("冲虚道长");
        //				list.Add("方证大师");
        //				list.Add("灭绝师太");
        //				list.Add("张翠山");
        //				list.Add("宋远桥");
        //				list.Add("韦一笑");
        //				list.Add("仪清");
        //				list.Add("何太冲");
        //				list.Add("哑仆");
        //				list.Add("温方达");
        //				list.Add("温方义");
        //				list.Add("温方山");
        //				list.Add("温方施");
        //				list.Add("温方悟");
        //				list.Add("安小慧");
        //				list.Add("阿九");
        //				break;
        //			case 3:
        //				list.Add("紫衫龙王");
        //				list.Add("白眉鹰王");
        //				list.Add("商剑鸣");
        //				list.Add("杨逍");
        //				list.Add("范遥");
        //				list.Add("霍都");
        //				list.Add("孙不二");
        //				list.Add("龙岛主");
        //				list.Add("木岛主");
        //				list.Add("善勇");
        //				break;
        //			case 4:
        //				list.Add("白自在");
        //				list.Add("向问天");
        //				list.Add("丁春秋");
        //				list.Add("成昆");
        //				list.Add("段延庆");
        //				list.Add("丘处机");
        //				list.Add("欧阳锋");
        //				break;
        //			default:
        //				list.Add("任我行");
        //				list.Add("王重阳");
        //				list.Add("林朝英");
        //				list.Add("归辛树");
        //				list.Add("玉真子");
        //				list.Add("慕容博");
        //				list.Add("卓一航");
        //				list.Add("谢逊");
        //				list.Add("虚竹");
        //				break;
        //			}
        //			if (list.Count > 0)
        //			{
        //				RuntimeData.Instance.Team.Add(ResourceManager.Get<Role>(list[Tools.GetRandomInt(0, list.Count) % list.Count]).Clone());
        //			}
        //			if (rst == 0)
        //			{
        //				RuntimeData.Instance.gameEngine.NewGame();
        //			}
        //			else
        //			{
        //				RuntimeData.Instance.gameEngine.NewGameJump();
        //			}
        //			base.gameObject.SetActive(false);
        //		}

        //		// Token: 0x06000575 RID: 1397 RVA: 0x00031904 File Offset: 0x0002FB04
        //		public void okButton_Click()
        //		{
        //			this.JumpSelectCallback(1);
        //		}

        //		// Token: 0x06000576 RID: 1398 RVA: 0x00031910 File Offset: 0x0002FB10
        //		public void resetButton_Click()
        //		{
        //			AudioManager.Instance.PlayEffect("音效.装备");
        //			this.Reset();
        //		}

        //		// Token: 0x06000577 RID: 1399 RVA: 0x00031928 File Offset: 0x0002FB28
        //		private void Start()
        //		{
        //			AudioManager.Instance.Play("音乐.七秀");
        //			this.Show();
        //		}

        //		// Token: 0x06000578 RID: 1400 RVA: 0x00031940 File Offset: 0x0002FB40
        //		private void Update()
        //		{
        //		}

        //		// Token: 0x040003EA RID: 1002
        //		public GameObject rolePanelObj;

        //		// Token: 0x040003EB RID: 1003
        //		public GameObject headSelectPanelObj;

        //		// Token: 0x040003EC RID: 1004
        //		public GameObject NameInputPanel;

        //		// Token: 0x040003ED RID: 1005
        //		public GameObject selectPanelObj;

        //		// Token: 0x040003EE RID: 1006
        //		public GameObject MultiSelectItemObj;

        //		// Token: 0x040003EF RID: 1007
        //		public GameObject RoleConfirmButtonObj;

        //		// Token: 0x040003F0 RID: 1008
        //		public GameObject RoleResetButtonObj;

        //		// Token: 0x040003F1 RID: 1009
        //		private List<string> heads = new List<string>
        //		{
        //			"头像.主角",
        //			"头像.主角3",
        //			"头像.主角4",
        //			"头像.魔君",
        //			"头像.全冠清",
        //			"头像.李白",
        //			"头像.林平之瞎",
        //			"头像.侠客2",
        //			"头像.归辛树",
        //			"头像.狄云",
        //			"头像.独孤求败",
        //			"头像.陈近南",
        //			"头像.石中玉",
        //			"头像.商宝震",
        //			"头像.尹志平",
        //			"头像.流浪汉",
        //			"头像.梁发",
        //			"头像.卓一航",
        //			"头像.烟霞神龙",
        //			"头像.双手开碑",
        //			"头像.流星赶月",
        //			"头像.盖七省",
        //			"头像.公子1",
        //			"头像.主角2"
        //		};
    }
}
