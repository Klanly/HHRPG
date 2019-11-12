using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace JyGame
{
    public class GameEngine
    {
        //		private string _type = "map";

        //		public int ArenaHardLevel = -1;

        //		private string _value = "大地图";

        //		private Story _story;

        //		private CommonSettings.VoidCallBack _rtcallback;

        //		public BattleType battleType;

        //		public Tower currentTower;

        //		public int CurrentTowerIndex;

        //		public List<string> BattleSelectRole_CurrentForbbidenKeys = new List<string>();

        //		public CommonSettings.VoidCallBack BattleSelectRole_CurrentCancelCallback;

        //		public Battle BattleSelectRole_GeneratedBattle;

        //		public CommonSettings.StringCallBack BattleSelectRole_BattleCallback;

        //		public Map CurrentLoadMap;

        //		public string CurrentInTrail = string.Empty;

        //		public string touchKey = "测试";

        //		public CommonSettings.StringCallBack touchCallBack;

        public GameEngine()
        {
            this.Init();
            DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        }

        //		public bool IsMobilePlatform
        //		{
        //			get
        //			{
        //				return CommonSettings.DEBUG_FORCE_MOBILE_MODE || Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        //			}
        //		}

        public void Init()
        {
            ResourceManager.Init();
            Application.targetFrameRate = 100;
        }

        //		public void NewGame()
        //		{
        //			RuntimeData.Instance.KeyValues["original_主角之家.开场"] = "0";
        //			RuntimeData.Instance.SetLocation("大地图", "南贤居");
        //			RuntimeData.Instance.TrialRoles = string.Empty;
        //			RuntimeData.Instance.Rank = -1;
        //			this.SwitchGameScene("story", "新生村_出生");
        //		}

        //		// Token: 0x06000056 RID: 86 RVA: 0x00003688 File Offset: 0x00001888
        //		public void NewGameJump()
        //		{
        //			RuntimeData.Instance.KeyValues["original_主角之家.开场"] = "0";
        //			RuntimeData.Instance.SetLocation("大地图", "南贤居");
        //			RuntimeData.Instance.TrialRoles = string.Empty;
        //			this.SwitchGameScene("story", "新手村_出生");
        //		}

        //		// Token: 0x06000057 RID: 87 RVA: 0x000036E4 File Offset: 0x000018E4
        //		public void SwitchGameScene(string type, string value)
        //		{
        //			if (RuntimeData.Instance.judgeFinishTask())
        //			{
        //				return;
        //			}
        //			if (this.CurrentSceneType.Equals("story"))
        //			{
        //				RuntimeData.Instance.PrevStory = this.CurrentSceneValue;
        //			}
        //			this.CurrentSceneType = type;
        //			this.CurrentSceneValue = value;
        //			switch (type)
        //			{
        //			case "story":
        //				if (Application.loadedLevelName == "Map")
        //				{
        //					RuntimeData.Instance.mapUI.LoadStory(value);
        //				}
        //				else
        //				{
        //					LoadingUI.Load("Map");
        //				}
        //				return;
        //			case "map":
        //			{
        //				RuntimeData.Instance.ResetTeam();
        //				string text = RuntimeData.Instance.CheckTimeFlags();
        //				if (!text.Equals(string.Empty))
        //				{
        //					RuntimeData.Instance.mapUI.LoadStory(text);
        //					return;
        //				}
        //				if (Application.loadedLevelName == "Map")
        //				{
        //					RuntimeData.Instance.mapUI.LoadMap(value);
        //				}
        //				else
        //				{
        //					LoadingUI.Load("Map");
        //				}
        //				if (Configer.IsAutoSave)
        //				{
        //					string content = RuntimeData.Instance.Save();
        //					SaveManager.SetSave("autosave", content);
        //				}
        //				return;
        //			}
        //			case "runtimestory":
        //				if (Application.loadedLevelName == "Map")
        //				{
        //					RuntimeData.Instance.mapUI.LoadStory(this.RuntimeStory, this.RuntimeCallback);
        //				}
        //				else
        //				{
        //					LoadingUI.Load("Map");
        //				}
        //				return;
        //			case "url":
        //				Tools.openURL(value);
        //				this.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //				return;
        //			case "rollroll":
        //				this.RollRole();
        //				return;
        //			case "tutorial":
        //				RuntimeData.Instance.mapUI.LoadMap("大地图");
        //				RuntimeData.Instance.mapUI.LoadStory("original_教学开始");
        //				return;
        //			case "battle":
        //				this.battleType = BattleType.Common;
        //				this.BattleSelectRole_CurrentForbbidenKeys.Clear();
        //				this.BattleSelectRole_CurrentCancelCallback = null;
        //				this.BattleSelectRole_BattleCallback = delegate(string rst)
        //				{
        //					if (rst == "win")
        //					{
        //						this.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //					}
        //					else
        //					{
        //						this.SwitchGameScene("gameOver", string.Empty);
        //					}
        //				};
        //				Application.LoadLevel("BattleSelectRole");
        //				return;
        //			case "arena":
        //				this.battleType = BattleType.Arena;
        //				this.BattleSelectRole_CurrentForbbidenKeys.Clear();
        //				this.BattleSelectRole_CurrentCancelCallback = delegate()
        //				{
        //					Application.LoadLevel("Map");
        //				};
        //				this.BattleSelectRole_BattleCallback = delegate(string rst)
        //				{
        //					this.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //				};
        //				Application.LoadLevel("BattleSelectScene");
        //				return;
        //			case "trial":
        //				this.battleType = BattleType.Trial;
        //				this.BattleSelectRole_CurrentForbbidenKeys.Clear();
        //				foreach (string text2 in RuntimeData.Instance.TrialRoles.Split(new char[]
        //				{
        //					'#'
        //				}))
        //				{
        //					string item = text2;
        //					this.BattleSelectRole_CurrentForbbidenKeys.Add(item);
        //				}
        //				this.CurrentSceneType = "battle";
        //				this.CurrentSceneValue = "试炼之地_战斗";
        //				this.BattleSelectRole_BattleCallback = delegate(string rst)
        //				{
        //					if (rst.Equals("win"))
        //					{
        //						string currentInTrail = RuntimeData.Instance.gameEngine.CurrentInTrail;
        //						Role role = null;
        //						foreach (Role role2 in RuntimeData.Instance.Team)
        //						{
        //							Role role3 = role2;
        //							if (role3.Key.Equals(currentInTrail))
        //							{
        //								role = role3;
        //								break;
        //							}
        //						}
        //						if (role != null)
        //						{
        //							RuntimeData instance = RuntimeData.Instance;
        //							instance.TrialRoles = instance.TrialRoles + "#" + role.Key;
        //							RuntimeData.Instance.TrialRoles.Trim(new char[]
        //							{
        //								'#'
        //							});
        //							RuntimeData.Instance.AddLog(role.Name + "通过试炼之地");
        //							string text3 = "霹雳堂_" + role.Key;
        //							if (ResourceManager.Get<Story>(text3) == null)
        //							{
        //								this.SwitchGameScene("story", "霹雳堂_胜利");
        //							}
        //							else
        //							{
        //								this.SwitchGameScene("story", text3);
        //							}
        //						}
        //					}
        //					else
        //					{
        //						this.SwitchGameScene("story", "original_试炼之地.失败");
        //					}
        //				};
        //				Application.LoadLevel("BattleSelectRole");
        //				return;
        //			case "tower":
        //				this.battleType = BattleType.Tower;
        //				this.BattleSelectRole_CurrentForbbidenKeys.Clear();
        //				this.BattleSelectRole_CurrentCancelCallback = delegate()
        //				{
        //					LoadingUI.Load("Map");
        //				};
        //				Application.LoadLevel("BattleSelectScene");
        //				return;
        //			case "nextTower":
        //			{
        //				this.battleType = BattleType.Tower;
        //				this.CurrentTowerIndex++;
        //				TowerMap towerMap = this.currentTower.Maps[this.CurrentTowerIndex];
        //				Battle battle = ResourceManager.Get<Battle>(towerMap.Key);
        //				this.CurrentSceneValue = battle.Key;
        //				Application.LoadLevel("BattleSelectRole");
        //				return;
        //			}
        //			case "huashan":
        //			{
        //				this.battleType = BattleType.Huashan;
        //				this.BattleSelectRole_CurrentForbbidenKeys.Clear();
        //				this.currentTower = ResourceManager.Get<Tower>("华山论剑");
        //				this.CurrentTowerIndex = 0;
        //				TowerMap towerMap2 = this.currentTower.Maps[this.CurrentTowerIndex];
        //				Battle battle2 = ResourceManager.Get<Battle>(towerMap2.Key);
        //				this.CurrentSceneValue = battle2.Key;
        //				this.BattleSelectRole_BattleCallback = delegate(string rst)
        //				{
        //					if (rst.Equals("win"))
        //					{
        //						this.SwitchGameScene("nextHuashan", string.Empty);
        //					}
        //					else
        //					{
        //						this.SwitchGameScene("gameOver", string.Empty);
        //					}
        //				};
        //				Application.LoadLevel("BattleSelectRole");
        //				return;
        //			}
        //			case "nextHuashan":
        //				this.battleType = BattleType.Huashan;
        //				this.CurrentTowerIndex++;
        //				if (this.CurrentTowerIndex < this.currentTower.Maps.Count)
        //				{
        //					TowerMap towerMap3 = this.currentTower.Maps[this.CurrentTowerIndex];
        //					Battle battle3 = ResourceManager.Get<Battle>(towerMap3.Key);
        //					this.CurrentSceneValue = battle3.Key;
        //					Application.LoadLevel("BattleSelectRole");
        //				}
        //				else
        //				{
        //					this.SwitchGameScene("story", "original_华山论剑分枝判断");
        //				}
        //				return;
        //			case "restart":
        //				RuntimeData.Instance.Rank = -1;
        //				RuntimeData.Instance.NextZhoumuClear();
        //				GlobalData.ParamAdd("end_count", 1);
        //				this.RollRole();
        //				return;
        //			case "nextZhoumu":
        //			{
        //				RuntimeData.Instance.Round++;
        //				int param = GlobalData.GetParam("max_round");
        //				if (RuntimeData.Instance.Round > param)
        //				{
        //					GlobalData.SetParam("max_round", RuntimeData.Instance.Round);
        //				}
        //				RuntimeData.Instance.Rank = -1;
        //				RuntimeData.Instance.NextZhoumuClear();
        //				GlobalData.ParamAdd("end_count", 1);
        //				this.RollRole();
        //				return;
        //			}
        //			case "gameOver":
        //				Application.LoadLevel("GameOver");
        //				return;
        //			case "gameFin":
        //				Application.LoadLevel("GameFin");
        //				return;
        //			case "shop":
        //			{
        //				Shop shop = ResourceManager.Get<Shop>(value);
        //				if (shop != null)
        //				{
        //					ShopUI.CurrentShop = shop;
        //					ShopUI.Type = ShopType.SHOP;
        //					Application.LoadLevel("Shop");
        //				}
        //				return;
        //			}
        //			case "game":
        //				this.PlaySmallGame(value);
        //				return;
        //			case "mainmenu":
        //				Application.LoadLevel("MainMenu");
        //				return;
        //			case "menpai":
        //				LoadingUI.Load("Menpai");
        //				return;
        //			case "xiangzi":
        //				ShopUI.Type = ShopType.XIANGZI;
        //				Application.LoadLevel("Shop");
        //				return;
        //			case "item":
        //				if (value.Split(new char[]
        //				{
        //					'#'
        //				}).Length > 1)
        //				{
        //					RuntimeData.Instance.addItem(new ItemInstance
        //					{
        //						Name = value.Split(new char[]
        //						{
        //							'#'
        //						})[0]
        //					}, int.Parse(value.Split(new char[]
        //					{
        //						'#'
        //					})[1]));
        //				}
        //				else
        //				{
        //					RuntimeData.Instance.addItem(new ItemInstance
        //					{
        //						Name = value
        //					}, 1);
        //				}
        //				return;
        //			case "randomitem":
        //				for (int j = 0; j < int.Parse(value.Split(new char[]
        //				{
        //					'#'
        //				})[1]); j++)
        //				{
        //					RuntimeData.Instance.addItem(ItemInstance.Generate(value.Split(new char[]
        //					{
        //						'#'
        //					})[0], true), 1);
        //				}
        //				return;
        //			case "addround":
        //				RuntimeData.Instance.Round += int.Parse(value);
        //				return;
        //			case "clear":
        //				PlayerPrefs.DeleteKey(value);
        //				this.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //				return;
        //			case "clearall":
        //				PlayerPrefs.DeleteAll();
        //				Application.LoadLevel("MainMenu");
        //				return;
        //			case "join":
        //				RuntimeData.Instance.addTeamMember(value);
        //				return;
        //			case "zhenlongqiju":
        //			{
        //				this.battleType = BattleType.Zhenlongqiju;
        //				this.BattleSelectRole_CurrentForbbidenKeys.Clear();
        //				this.CurrentSceneType = "battle";
        //				this.CurrentSceneValue = "珍珑棋局_战斗";
        //				string currentMode = RuntimeData.Instance.GameMode;
        //				RuntimeData.Instance.GameMode = "crazy";
        //				this.BattleSelectRole_BattleCallback = delegate(string rst)
        //				{
        //					RuntimeData.Instance.GameMode = currentMode;
        //					if (rst.Equals("win"))
        //					{
        //						GlobalData.ZhenlongqijuLevel++;
        //						this.SwitchGameScene("story", "珍珑棋局_胜利");
        //					}
        //					else
        //					{
        //						this.SwitchGameScene("story", "珍珑棋局_失败");
        //					}
        //				};
        //				Application.LoadLevel("BattleSelectRole");
        //				return;
        //			}
        //			case "zhenlonglevel":
        //				GlobalData.ZhenlongqijuLevel = int.Parse(value);
        //				return;
        //			case "xilian":
        //			{
        //				MapUI mapUI = RuntimeData.Instance.mapUI;
        //				Dictionary<ItemInstance, int> items = RuntimeData.Instance.GetItems(new ItemType[]
        //				{
        //					ItemType.Armor,
        //					ItemType.Weapon,
        //					ItemType.Accessories
        //				});
        //				List<ItemInstance> list = new List<ItemInstance>();
        //				foreach (KeyValuePair<ItemInstance, int> keyValuePair in items)
        //				{
        //					if (keyValuePair.Key.AdditionTriggers.Count == 0)
        //					{
        //						list.Add(keyValuePair.Key);
        //					}
        //				}
        //				foreach (ItemInstance key in list)
        //				{
        //					items.Remove(key);
        //				}
        //				if (items.Count == 0)
        //				{
        //					this.SwitchGameScene("story", "洗练_没有装备");
        //					return;
        //				}
        //				string item;
        //				mapUI.itemMenu.Show("选择要洗练的装备", items, delegate(object obj)
        //				{
        //					ItemInstance item = obj as ItemInstance;
        //					string itemKey = item.PK;
        //					mapUI.ItemDetailPanelObj.GetComponent<ItemSkillDetailPanelUI>().Show(item, ItemDetailMode.Selectable, delegate()
        //					{
        //						ItemInstance selectItem = RuntimeData.Instance.GetItem(itemKey);
        //						List<string> opts = new List<string>();
        //						foreach (Trigger trigger in selectItem.AdditionTriggers)
        //						{
        //							opts.Add(trigger.ToString());
        //						}
        //						mapUI.LoadSelection("选择你要洗练的属性", opts, delegate(int selectIndex)
        //						{
        //							mapUI.itemMenu.Hide();
        //							List<string> opts2 = new List<string>();
        //							List<Trigger> newTriggers = new List<Trigger>();
        //							for (int k = 0; k < 8; k++)
        //							{
        //								Trigger trigger2 = selectItem.GenerateRandomTrigger();
        //								newTriggers.Add(trigger2);
        //								opts2.Add(trigger2.ToString());
        //							}
        //							opts2.Add("不替换了(" + opts[selectIndex] + ")");
        //							RuntimeData.Instance.Yuanbao--;
        //							mapUI.LoadSelection("选择你要替换的属性", opts2, delegate(int opt2SelectIndex)
        //							{
        //								if (opt2SelectIndex >= opts2.Count - 1)
        //								{
        //									this.SwitchGameScene("story", "洗练选择");
        //									return;
        //								}
        //								Trigger value2 = newTriggers[opt2SelectIndex];
        //								int index = -1;
        //								for (int l = 0; l < selectItem.AdditionTriggers.Count; l++)
        //								{
        //									if (item.AdditionTriggers[l].ToString() == opts[selectIndex])
        //									{
        //										index = l;
        //										break;
        //									}
        //								}
        //								RuntimeData.Instance.addItem(selectItem, -1);
        //								selectItem.AdditionTriggers[index] = value2;
        //								RuntimeData.Instance.addItem(selectItem, 1);
        //								AudioManager.Instance.PlayEffect("音效.装备");
        //								this.SwitchGameScene("story", "洗练_洗练成功");
        //							}, "汉家松鼠");
        //						}, "汉家松鼠");
        //					}, delegate()
        //					{
        //						this.SwitchGameScene("xilian", string.Empty);
        //					}, null);
        //				}, delegate()
        //				{
        //					this.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //				}, (object obj) => (obj as ItemInstance).AdditionTriggers.Count > 0);
        //				return;
        //			}
        //			}
        //			string currentBigMap = RuntimeData.Instance.CurrentBigMap;
        //			this.CurrentSceneType = "map";
        //			this.CurrentSceneValue = currentBigMap;
        //			RuntimeData.Instance.ResetTeam();
        //			if (Application.loadedLevelName == "Map")
        //			{
        //				RuntimeData.Instance.mapUI.LoadMap(currentBigMap);
        //			}
        //			else
        //			{
        //				LoadingUI.Load("Map");
        //			}
        //		}

        //		// Token: 0x06000058 RID: 88 RVA: 0x0000428C File Offset: 0x0000248C
        //		public void RollRole()
        //		{
        //			LoadingUI.Load("RollRole");
        //		}

        //		// Token: 0x06000059 RID: 89 RVA: 0x00004298 File Offset: 0x00002498
        //		public void PlaySmallGame(string gameName)
        //		{
        //			if (gameName == "levelup")
        //			{
        //				int num = 12;
        //				if (TriggerLogic.judge(new Condition
        //				{
        //					type = "should_finish",
        //					value = "mainStory_黑暗的阴影1"
        //				}))
        //				{
        //					num = 18;
        //				}
        //				if (TriggerLogic.judge(new Condition
        //				{
        //					type = "should_finish",
        //					value = "mainStory_神秘剑客1"
        //				}))
        //				{
        //					num = 22;
        //				}
        //				if (TriggerLogic.judge(new Condition
        //				{
        //					type = "should_finish",
        //					value = "mainStory_紧急1"
        //				}))
        //				{
        //					num = 25;
        //				}
        //				List<string> list = new List<string>();
        //				foreach (Role role in RuntimeData.Instance.Team)
        //				{
        //					if (role.Level < num)
        //					{
        //						int add = role.LevelupExp - role.Exp + 1;
        //						role.AddExp(add);
        //						list.Add(role.Name);
        //					}
        //				}
        //				AudioManager.Instance.PlayEffect("音效.升级");
        //				RuntimeData.Instance.gameEngine.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //			}
        //			else if (gameName == "qinggong")
        //			{
        //				LoadingUI.Load("Dodge");
        //			}
        //			else if (gameName == "dianxue")
        //			{
        //				LoadingUI.Load("WhacAMole");
        //			}
        //			else
        //			{
        //				RuntimeData.Instance.gameEngine.SwitchGameScene("map", RuntimeData.Instance.CurrentBigMap);
        //			}
        //		}

        //		public string CurrentSceneType
        //		{
        //			get
        //			{
        //				return this._type;
        //			}
        //			set
        //			{
        //				this._type = value;
        //			}
        //		}

        //		public string CurrentSceneValue
        //		{
        //			get
        //			{
        //				return this._value;
        //			}
        //			set
        //			{
        //				this._value = value;
        //			}
        //		}

        //		public Story RuntimeStory
        //		{
        //			get
        //			{
        //				return this._story;
        //			}
        //			set
        //			{
        //				this._story = value;
        //			}
        //		}

        //		// Token: 0x17000011 RID: 17
        //		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000449C File Offset: 0x0000269C
        //		// (set) Token: 0x06000061 RID: 97 RVA: 0x000044A4 File Offset: 0x000026A4
        //		public CommonSettings.VoidCallBack RuntimeCallback
        //		{
        //			get
        //			{
        //				return this._rtcallback;
        //			}
        //			set
        //			{
        //				this._rtcallback = value;
        //			}
        //		}
    }
}
