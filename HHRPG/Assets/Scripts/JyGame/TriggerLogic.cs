//using System;
//using System.Collections.Generic;
//using System.Globalization;

namespace JyGame
{
    public class TriggerLogic
    {
        public static bool judge(Condition condition)
        {
            //			if (condition.type == "in_team" && !RuntimeData.Instance.NameInTeam(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "not_in_team" && RuntimeData.Instance.NameInTeam(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "key_in_team" && !RuntimeData.Instance.InTeam(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "key_not_in_team" && RuntimeData.Instance.InTeam(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "should_finish" && !RuntimeData.Instance.KeyValues.ContainsKey(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "should_not_finish" && RuntimeData.Instance.KeyValues.ContainsKey(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "follow_story" && !RuntimeData.Instance.PrevStory.Equals(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "has_time_key" && !RuntimeData.Instance.KeyValues.ContainsKey("TIMEKEY_" + condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "not_has_time_key" && RuntimeData.Instance.KeyValues.ContainsKey("TIMEKEY_" + condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "not_in_time")
            //			{
            //				string[] array = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				foreach (string text in array)
            //				{
            //					if (Tools.IsChineseTime(RuntimeData.Instance.Date, text[0]))
            //					{
            //						return false;
            //					}
            //				}
            //			}
            //			if (condition.type == "in_time")
            //			{
            //				string[] array3 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				foreach (string text2 in array3)
            //				{
            //					if (Tools.IsChineseTime(RuntimeData.Instance.Date, text2[0]))
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "in_month")
            //			{
            //				string[] array5 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				foreach (string s in array5)
            //				{
            //					if (RuntimeData.Instance.Date.Month == int.Parse(s))
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "not_in_month")
            //			{
            //				string[] array7 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				foreach (string s2 in array7)
            //				{
            //					if (RuntimeData.Instance.Date.Month == int.Parse(s2))
            //					{
            //						return false;
            //					}
            //				}
            //			}
            //			if (condition.type == "have_money" && RuntimeData.Instance.Money < int.Parse(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "have_yuanbao")
            //			{
            //				return RuntimeData.Instance.Yuanbao >= int.Parse(condition.value);
            //			}
            //			if (condition.type == "have_item")
            //			{
            //				int num = 0;
            //				foreach (KeyValuePair<ItemInstance, int> keyValuePair in RuntimeData.Instance.Items)
            //				{
            //					if (keyValuePair.Key.Name == condition.value)
            //					{
            //						num += keyValuePair.Value;
            //					}
            //				}
            //				if (num < condition.number || num == 0)
            //				{
            //					return false;
            //				}
            //			}
            //			if (condition.type == "not_have_item")
            //			{
            //				foreach (KeyValuePair<ItemInstance, int> keyValuePair2 in RuntimeData.Instance.Items)
            //				{
            //					if (keyValuePair2.Key.Name == condition.value)
            //					{
            //						return false;
            //					}
            //				}
            //			}
            //			if (condition.type == "game_mode" && RuntimeData.Instance.GameMode != condition.value)
            //			{
            //				return false;
            //			}
            //			if (condition.type == "exceed_day" && (RuntimeData.Instance.Date - DateTime.ParseExact("0001-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture)).Days <= int.Parse(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "not_exceed_day" && (RuntimeData.Instance.Date - DateTime.ParseExact("0001-01-01 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture)).Days > int.Parse(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "in_menpai" && RuntimeData.Instance.Menpai != condition.value)
            //			{
            //				return false;
            //			}
            //			if (condition.type == "not_in_menpai" && RuntimeData.Instance.Menpai == condition.value)
            //			{
            //				return false;
            //			}
            //			if (condition.type == "has_menpai")
            //			{
            //				return RuntimeData.Instance.Menpai != string.Empty;
            //			}
            //			if (condition.type == "in_round" && RuntimeData.Instance.Round != int.Parse(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "not_in_round" && RuntimeData.Instance.Round == int.Parse(condition.value))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "probability" && !Tools.ProbabilityTest((double)int.Parse(condition.value) / 100.0))
            //			{
            //				return false;
            //			}
            //			if (condition.type == "daode_more_than")
            //			{
            //				return RuntimeData.Instance.Daode >= int.Parse(condition.value);
            //			}
            //			if (condition.type == "daode_less_than")
            //			{
            //				return RuntimeData.Instance.Daode < int.Parse(condition.value);
            //			}
            //			if (condition.type == "haogan_more_than")
            //			{
            //				string[] array9 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string roleKey = "女主";
            //				int num2;
            //				if (array9.Length == 1)
            //				{
            //					num2 = int.Parse(array9[0]);
            //				}
            //				else
            //				{
            //					roleKey = array9[0];
            //					num2 = int.Parse(array9[1]);
            //				}
            //				return RuntimeData.Instance.getHaogan(roleKey) >= num2;
            //			}
            //			if (condition.type == "haogan_less_than")
            //			{
            //				string[] array10 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string roleKey2 = "女主";
            //				int num3;
            //				if (array10.Length == 1)
            //				{
            //					num3 = int.Parse(array10[0]);
            //				}
            //				else
            //				{
            //					roleKey2 = array10[0];
            //					num3 = int.Parse(array10[1]);
            //				}
            //				return RuntimeData.Instance.getHaogan(roleKey2) < num3;
            //			}
            //			if (condition.type == "skill_more_than")
            //			{
            //				string[] array11 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b = array11[0];
            //				string b2 = array11[1];
            //				int num4 = int.Parse(array11[2]);
            //				foreach (Role role in RuntimeData.Instance.Team)
            //				{
            //					if (role.Key == b)
            //					{
            //						foreach (SkillInstance skillInstance in role.Skills)
            //						{
            //							if (skillInstance.Skill.Name == b2 && skillInstance.Level >= num4)
            //							{
            //								return true;
            //							}
            //						}
            //						foreach (InternalSkillInstance internalSkillInstance in role.InternalSkills)
            //						{
            //							if (internalSkillInstance.Name == b2 && internalSkillInstance.Level >= num4)
            //							{
            //								return true;
            //							}
            //						}
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "skill_less_than")
            //			{
            //				string[] array12 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b3 = array12[0];
            //				string b4 = array12[1];
            //				int num5 = int.Parse(array12[2]);
            //				foreach (Role role2 in RuntimeData.Instance.Team)
            //				{
            //					if (role2.Key == b3)
            //					{
            //						bool flag = false;
            //						foreach (SkillInstance skillInstance2 in role2.Skills)
            //						{
            //							if (skillInstance2.Skill.Name == b4)
            //							{
            //								flag = true;
            //							}
            //							if (skillInstance2.Skill.Name == b4 && skillInstance2.Level < num5)
            //							{
            //								return true;
            //							}
            //						}
            //						foreach (InternalSkillInstance internalSkillInstance2 in role2.InternalSkills)
            //						{
            //							if (internalSkillInstance2.Name == b4)
            //							{
            //								flag = true;
            //							}
            //							if (internalSkillInstance2.Name == b4 && internalSkillInstance2.Level < num5)
            //							{
            //								return true;
            //							}
            //						}
            //						if (!flag)
            //						{
            //							return true;
            //						}
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "level_greater_than")
            //			{
            //				string[] array13 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b5 = array13[0];
            //				int num6 = int.Parse(array13[1]);
            //				foreach (Role role3 in RuntimeData.Instance.Team)
            //				{
            //					if (role3.Key == b5 && role3.Level >= num6)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "level_less_than")
            //			{
            //				string[] array14 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b6 = array14[0];
            //				int num7 = int.Parse(array14[1]);
            //				foreach (Role role4 in RuntimeData.Instance.Team)
            //				{
            //					if (role4.Key == b6 && role4.Level < num7)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "dingli_greater_than")
            //			{
            //				string[] array15 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b7 = array15[0];
            //				int num8 = int.Parse(array15[1]);
            //				foreach (Role role5 in RuntimeData.Instance.Team)
            //				{
            //					if (role5.Key == b7 && role5.Attributes["dingli"] >= num8)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "wuxing_greater_than")
            //			{
            //				string[] array16 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b8 = array16[0];
            //				int num9 = int.Parse(array16[1]);
            //				foreach (Role role6 in RuntimeData.Instance.Team)
            //				{
            //					if (role6.Key == b8 && role6.Attributes["wuxing"] >= num9)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "dingli_less_than")
            //			{
            //				string[] array17 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b9 = array17[0];
            //				int num10 = int.Parse(array17[1]);
            //				foreach (Role role7 in RuntimeData.Instance.Team)
            //				{
            //					if (role7.Key == b9 && role7.Attributes["dingli"] < num10)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "wuxing_less_than")
            //			{
            //				string[] array18 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b10 = array18[0];
            //				int num11 = int.Parse(array18[1]);
            //				foreach (Role role8 in RuntimeData.Instance.Team)
            //				{
            //					if (role8.Key == b10 && role8.Attributes["wuxing"] < num11)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "shenfa_greater_than")
            //			{
            //				string[] array19 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b11 = array19[0];
            //				int num12 = int.Parse(array19[1]);
            //				foreach (Role role9 in RuntimeData.Instance.Team)
            //				{
            //					if (role9.Key == b11 && role9.Attributes["shenfa"] >= num12)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "quanzhang_less_than")
            //			{
            //				string[] array20 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b12 = array20[0];
            //				int num13 = int.Parse(array20[1]);
            //				foreach (Role role10 in RuntimeData.Instance.Team)
            //				{
            //					if (role10.Key == b12 && role10.quanzhang < num13)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "jianfa_less_than")
            //			{
            //				string[] array21 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b13 = array21[0];
            //				int num14 = int.Parse(array21[1]);
            //				foreach (Role role11 in RuntimeData.Instance.Team)
            //				{
            //					if (role11.Key == b13 && role11.jianfa < num14)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "daofa_less_than")
            //			{
            //				string[] array22 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b14 = array22[0];
            //				int num15 = int.Parse(array22[1]);
            //				foreach (Role role12 in RuntimeData.Instance.Team)
            //				{
            //					if (role12.Key == b14 && role12.daofa < num15)
            //					{
            //						return true;
            //					}
            //				}
            //				return false;
            //			}
            //			if (condition.type == "qimen_less_than")
            //			{
            //				string[] array23 = condition.value.Split(new char[]
            //				{
            //					'#'
            //				});
            //				string b15 = array23[0];
            //				int num16 = int.Parse(array23[1]);
            //				foreach (Role role13 in RuntimeData.Instance.Team)
            //				{
            //					if (role13.Key == b15 && role13.qimen < num16)
            //					{
            //						return true;
            //					}
            //				}
          				return false;
            //			}
            //			if (condition.type == "friendCount")
            //			{
            //				return RuntimeData.Instance.Team.Count >= int.Parse(condition.value);
            //			}
            //			if (condition.type == "zhoumu_greater_than")
            //			{
            //				return RuntimeData.Instance.Round >= int.Parse(condition.value);
            //			}
            //			if (condition.type == "in_newbie_task")
            //			{
            //				return RuntimeData.Instance.NewbieTask.Equals(condition.value);
            //			}
            //			return !(condition.type == "rank") || (RuntimeData.Instance.Rank != -1 && RuntimeData.Instance.Rank <= int.Parse(condition.value));
             }
        }
}
