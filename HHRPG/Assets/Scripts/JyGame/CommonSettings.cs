using System;
using System.Collections.Generic;
using UnityEngine;

namespace JyGame
{
    /// <summary>
    /// 通用设置
    /// </summary>
	public class CommonSettings
	{
        public const string HOME_PAGE = "http://www.jy-x.com";

        public const string FORUM_URL = "http://tieba.baidu.com/f?ie=utf-8&kw=%E6%B1%89%E5%AE%B6%E6%9D%BE%E9%BC%A0";

        public const string APPSTORE_PINGLUN_URL = "itms-apps://ax.itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id=1021093037";

        public const string GAME_VERSION = "1.0.0.5";

        public const string XML_UPDATE_URL = "http://www.jy-x.com/jygame/assetbundle/xml";

        public const string XML_UPDATE_URL_ANDROID = "http://www.jy-x.com/jygame/assetbundle/xml-android";

        public const string XML_UPDATE_URL_IOS = "http://www.jy-x.com/jygame/assetbundle/xml-ios";

        public const bool USE_ASSETBUNDLE_IN_EDITOR_MODE = false;

        public const bool FORCE_UPDATE_XML = true;

        public const string DAILY_AWARD = "http://120.24.166.63:8080/JY-X/award";

        public const int VERSION = 1;

        public const string UPDATE_ROOT = "http://120.24.166.63:8080/";

        public const int MAX_SAVE_COUNT = 6;

        public const string TEST_BATTLE = "测试战斗";

        public const int DEFAULT_MAX_GAME_SPTIME = 3000;

        public const int PER_MAXLEVEL_ADD_BY_ZHOUMU = 2;

        public const int SKILLTYPE_QUAN = 0;

        public const int SKILLTYPE_JIAN = 1;

        public const int SKILLTYPE_DAO = 2;

        public const int SKILLTYPE_QIMEN = 3;

        public const int SKILLTYPE_NEIGONG = 4;

        public const int BUFF_RUN_CYCLE = 50;

        public const double ZHOUMU_ATTACK_ADD = 0.1;

        public const double ZHOUMU_DEFENCE_ADD = 0.08;

        public const double ZHOUMU_HP_ADD = 0.15;

        public const double ZHOUMU_MP_ADD = 0.15;

        public const double WEAPON_ATTACK_FIX = 0.9;

        public const double ZHENGLONGQIJU_HP_ADD = 0.1;

        public const double ZHENGLONGQIJU_MP_ADD = 0.1;

        public const int MAX_INTERNALSKILL_COUNT = 5;

        public const int MAX_SKILL_COUNT = 10;

        public const int MAX_ATTRIBUTE = 200;

        public const int CHEAT_CHECK_ATTRIBUTE = 300;

        public const int MAX_SKILL_LEVEL = 20;

        public const int MAX_INTERNALSKILL_LEVEL = 20;

        public const double YUANBAO_DROP_RATE = 0.005;

        public const int AI_MAX_COMPUTE_SKILL = 5;

        public const int AI_MAX_COMPUTE_MOVERANGE = 20;

        public const int MAX_LEVEL = 30;

        public const string Key = "zbl06";

        public const string AutoSaveKey = "autosave";

        public const string FastSaveKey = "fastsave";

        public const float DIALOG_SPACE_KEY_SWITCH_DELTATIME = 0.3f;

        public static bool MOD_EDITOR_MODE = false;

        public static bool SECURE_XML = true;

        public static bool DEBUG_FORCE_MOBILE_MODE = false;

        public static double[] timeOpacity = new double[]
        {
            0.4,
            0.4,
            0.5,
            0.5,
            0.6,
            0.7,
            1.0,
            1.0,
            1.0,
            0.8,
            0.6,
            0.4
        };

        public static string[] RoleAttributeList = new string[]
        {
            "hp",
            "maxhp",
            "mp",
            "maxmp",
            "gengu",
            "bili",
            "fuyuan",
            "shenfa",
            "dingli",
            "wuxing",
            "quanzhang",
            "jianfa",
            "daofa",
            "qimen",
            "female",
            "wuxue"
        };

        public static string[] RoleAttributeChineseList = new string[]
        {
            "生命",
            "生命上限",
            "内力",
            "内力上限",
            "根骨",
            "臂力",
            "福缘",
            "身法",
            "定力",
            "悟性",
            "搏击格斗",
            "使剑技巧",
            "耍刀技巧",
            "奇门兵器",
            "是否女性",
            "武学常识"
        };

        private static string[] randomBattleMusics = new string[]
        {
            "战斗音乐.云狐之战",
            "战斗音乐.暮云出击",
            "战斗音乐.山谷行进",
            "战斗音乐.山谷行进2",
            "战斗音乐.2",
            "战斗音乐.3",
            "战斗音乐.4",
            "战斗音乐.5",
            "音乐.天龙八部.紧张感3",
            "音乐.天龙八部.紧张感4"
        };

        public static string[] EnemyRandomTalentsList = new string[]
        {
            "飘然",
            "斗魂",
            "哀歌",
            "奋战",
            "百足之虫",
            "真气护体",
            "暴躁",
            "金钟罩",
            "诸般封印",
            "刀封印",
            "剑封印",
            "奇门封印",
            "拳掌封印",
            "自我主义",
            "大小姐",
            "破甲",
            "好色",
            "瘸子",
            "白内障",
            "左手剑",
            "右臂有伤",
            "拳掌增益",
            "剑法增益",
            "刀法增益",
            "奇门增益",
            "锐眼"
        };

        public static string[] EnemyRandomTalentListCrazyDefence = new string[]
        {
            "百足之虫",
            "真气护体",
            "金钟罩",
            "苦命儿",
            "老江湖",
            "暴躁",
            "灵心慧质",
            "精打细算",
            "白内障",
            "右臂有伤",
            "神经病",
            "鲁莽"
        };

        public static string[] EnemyRandomTalentListCrazyAttack = new string[]
        {
            "斗魂",
            "奋战",
            "暴躁",
            "自我主义",
            "破甲",
            "铁拳无双",
            "素心神剑",
            "左右互搏",
            "博览群书",
            "阴谋家",
            "琴胆剑心",
            "追魂",
            "铁口直断",
            "左手剑",
            "拳掌增益",
            "剑法增益",
            "刀法增益",
            "奇门增益",
            "锐眼"
        };

        public static string[] EnemyRandomTalentListCrazyOther = new string[]
        {
            "刀封印",
            "剑封印",
            "奇门封印",
            "拳掌封印",
            "清心",
            "哀歌",
            "幽居",
            "金刚",
            "嗜血狂魔",
            "清风",
            "御风",
            "轻功高超",
            "瘸子"
        };

        public static int SMALLGAME_MAX_ATTRIBUTE = 70;

        public static string flagNoGlobalEvent = "NO_GLOBAL_EVENT";

        /// <summary>
        /// 空回调
        /// </summary>
        public delegate void VoidCallBack();

        public delegate void IntCallBack(int rst);

        public delegate void Int2CallBack(int x, int y);

        public delegate void ItemCallBack(Dictionary<string, int> items, int point);

        public delegate void StringCallBack(string rst);

        public delegate void ObjectCallBack(object obj);

        public delegate bool JudgeCallback(object obj);

        public static bool DEBUG_CONSOLE
		{
			get
			{
				return CommonSettings.MOD_EDITOR_MODE || (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor);
			}
		}

		//public static bool TOUCH_MODE
		//{
		//	get
		//	{
		//		return RuntimeData.Instance.gameEngine.IsMobilePlatform;
		//	}
		//}

		//public static SkillCoverType GetDefaultCoverType(int skillTypeCode)
		//{
		//	switch (skillTypeCode)
		//	{
		//	case 0:
		//		return SkillCoverType.NORMAL;
		//	case 1:
		//		return SkillCoverType.LINE;
		//	case 2:
		//		return SkillCoverType.FRONT;
		//	case 3:
		//		return SkillCoverType.CROSS;
		//	default:
		//		return SkillCoverType.NORMAL;
		//	}
		//}

		//public static int MAX_HPMP
		//{
		//	get
		//	{
		//		return 10000 + (RuntimeData.Instance.Round - 1) * 1000;
		//	}
		//}

		//public static string AttributeToChinese(string attr)
		//{
		//	for (int i = 0; i < CommonSettings.RoleAttributeList.Length; i++)
		//	{
		//		if (CommonSettings.RoleAttributeList[i].Equals(attr))
		//		{
		//			return CommonSettings.RoleAttributeChineseList[i];
		//		}
		//	}
		//	throw new Exception("invalid attribute " + attr);
		//}

		//public static string DateToGameTime(DateTime date)
		//{
		//	return string.Format("江湖{0}年{1}月{2}日{3}时", new object[]
		//	{
		//		Tools.chineseNumber[date.Year],
		//		Tools.chineseNumber[date.Month],
		//		Tools.chineseNumber[date.Day],
		//		Tools.chineseTime[date.Hour / 2]
		//	});
		//}

		//public static string HourToChineseTime(int hour)
		//{
		//	int num = hour / 24;
		//	int num2 = hour % 24;
		//	string text = string.Empty;
		//	if (num > 0)
		//	{
		//		text += string.Format("{0}天", num);
		//	}
		//	if (num2 != 0)
		//	{
		//		text += string.Format("{0}个时辰", num2 / 2);
		//	}
		//	return text;
		//}

		//public static string getRoleName(string roleKey)
		//{
		//	string result = string.Empty;
		//	if (roleKey == "女主")
		//	{
		//		result = RuntimeData.Instance.femaleName;
		//	}
		//	else if (roleKey == "主角")
		//	{
		//		result = RuntimeData.Instance.maleName;
		//	}
		//	else
		//	{
		//		Role role = ResourceManager.Get<Role>(roleKey);
		//		if (role != null)
		//		{
		//			result = role.Name;
		//		}
		//		else
		//		{
		//			result = roleKey;
		//		}
		//	}
		//	return result;
		//}

		//// Token: 0x06000039 RID: 57 RVA: 0x00002F84 File Offset: 0x00001184
		//public static string getRoleHead(string roleKey)
		//{
		//	if (roleKey == "主角")
		//	{
		//		foreach (Role role in RuntimeData.Instance.Team)
		//		{
		//			if (role.Key == "主角")
		//			{
		//				return role.Head;
		//			}
		//		}
		//		return string.Empty;
		//	}
		//	return ResourceManager.Get<Role>(roleKey).Head;
		//}

		//// Token: 0x0600003A RID: 58 RVA: 0x0000302C File Offset: 0x0000122C
		//public static void adjustAttr(Role role, string type, int value)
		//{
		//	switch (type)
		//	{
		//	case "hp":
		//		role.hp += value;
		//		break;
		//	case "maxhp":
		//		role.maxhp += value;
		//		break;
		//	case "mp":
		//		role.mp += value;
		//		break;
		//	case "maxmp":
		//		role.maxmp += value;
		//		break;
		//	case "gengu":
		//		role.gengu += value;
		//		break;
		//	case "bili":
		//		role.bili += value;
		//		break;
		//	case "fuyuan":
		//		role.fuyuan += value;
		//		break;
		//	case "shenfa":
		//		role.shenfa += value;
		//		break;
		//	case "dingli":
		//		role.dingli += value;
		//		break;
		//	case "wuxing":
		//		role.wuxing += value;
		//		break;
		//	case "quanzhang":
		//		role.quanzhang += value;
		//		break;
		//	case "jianfa":
		//		role.jianfa += value;
		//		break;
		//	case "daofa":
		//		role.daofa += value;
		//		break;
		//	case "qimen":
		//		role.qimen += value;
		//		break;
		//	}
		//}

		//// Token: 0x0600003B RID: 59 RVA: 0x0000326C File Offset: 0x0000146C
		//public static int LevelupExp(int level)
		//{
		//	if (level <= 0)
		//	{
		//		return 0;
		//	}
		//	return (int)((double)(level * 20) + 1.1 * (double)CommonSettings.LevelupExp(level - 1));
		//}

		//// Token: 0x0600003C RID: 60 RVA: 0x00003294 File Offset: 0x00001494
		//public static string GetRandomBattleMusic()
		//{
		//	return CommonSettings.randomBattleMusics[Tools.GetRandomInt(0, CommonSettings.randomBattleMusics.Length - 1)];
		//}

		//// Token: 0x0600003D RID: 61 RVA: 0x000032AC File Offset: 0x000014AC
		//public static string GetEnemyRandomTalentListCrazyDefence()
		//{
		//	int randomInt = Tools.GetRandomInt(0, CommonSettings.EnemyRandomTalentListCrazyDefence.Length);
		//	return CommonSettings.EnemyRandomTalentListCrazyDefence[randomInt % CommonSettings.EnemyRandomTalentListCrazyDefence.Length];
		//}

		//// Token: 0x0600003E RID: 62 RVA: 0x000032D8 File Offset: 0x000014D8
		//public static string GetEnemyRandomTalentListCrazyAttack()
		//{
		//	int randomInt = Tools.GetRandomInt(0, CommonSettings.EnemyRandomTalentListCrazyAttack.Length);
		//	return CommonSettings.EnemyRandomTalentListCrazyAttack[randomInt % CommonSettings.EnemyRandomTalentListCrazyAttack.Length];
		//}

		//// Token: 0x0600003F RID: 63 RVA: 0x00003304 File Offset: 0x00001504
		//public static string GetEnemyRandomTalentListCrazyOther()
		//{
		//	int randomInt = Tools.GetRandomInt(0, CommonSettings.EnemyRandomTalentListCrazyOther.Length);
		//	return CommonSettings.EnemyRandomTalentListCrazyOther[randomInt % CommonSettings.EnemyRandomTalentListCrazyOther.Length];
		//}

		//// Token: 0x06000040 RID: 64 RVA: 0x00003330 File Offset: 0x00001530
		//public static string GetEnemyRandomTalent(bool female)
		//{
		//	string text = string.Empty;
		//	string[] enemyRandomTalentsList = CommonSettings.EnemyRandomTalentsList;
		//	for (;;)
		//	{
		//		int randomInt = Tools.GetRandomInt(0, enemyRandomTalentsList.Length);
		//		text = enemyRandomTalentsList[randomInt % enemyRandomTalentsList.Length];
		//		if (!female || !(text == "好色"))
		//		{
		//			if (female || !(text == "大小姐"))
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	return text;
		//}
	}
}
