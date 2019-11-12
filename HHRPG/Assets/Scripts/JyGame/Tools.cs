using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace JyGame
{
	public class Tools
	{
		public static double GetRandom(double a, double b)
		{
			double num = Tools.rnd.NextDouble();
			if (b > a)
			{
				double num2 = a;
				a = b;
				b = num2;
			}
			return b + (a - b) * num;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000089B4 File Offset: 0x00006BB4
		public static int GetRandomInt(int a, int b)
		{
			return (int)Tools.GetRandom((double)a, (double)(b + 1));
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000089C4 File Offset: 0x00006BC4
		public static bool ProbabilityTest(double p)
		{
			return p >= 0.0 && (p >= 1.0 || Tools.rnd.NextDouble() < p);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000089F8 File Offset: 0x00006BF8
		public static string StringToMultiLine(string content, int lineLength, string enterFlag = "\n")
		{
			string text = string.Empty;
			string text2 = content;
			while (text2.Length > 0)
			{
				if (text2.Length > lineLength)
				{
					string str = text2.Substring(0, lineLength);
					text2 = text2.Substring(lineLength, text2.Length - lineLength);
					text = text + str + "\n";
				}
				else
				{
					text += text2;
					text2 = string.Empty;
				}
			}
			return text;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00008A64 File Offset: 0x00006C64
		public static int StringHashtoInt(string str)
		{
			int num = 0;
			foreach (char value in str)
			{
				num += Convert.ToInt32(value);
			}
			return num;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00008AA0 File Offset: 0x00006CA0
		public static string DateToString(DateTime date)
		{
			return string.Concat(new string[]
			{
				Tools.chineseNumber[date.Year],
				"年",
				Tools.chineseNumber[date.Month],
				"月",
				Tools.chineseNumber[date.Day],
				"日"
			});
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00008B04 File Offset: 0x00006D04
		public static bool IsChineseTime(DateTime t, char time)
		{
			return Tools.chineseTime[t.Hour / 2] == time;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00008B18 File Offset: 0x00006D18
		public static T LoadObjectFromUrl<T>(string url) where T : BasePojo
		{
			string xml = Resources.Load(url.Split(new char[]
			{
				'.'
			})[0]).ToString();
			return Tools.LoadObjectFromXML<T>(xml);
		}

		public static T LoadObjectFromXML<T>(string xml) where T : BasePojo
		{
			return Tools.DeserializeXML<T>(xml);
		}

		public static T DeserializeXML<T>(string xmlObj)
		{
			T result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				using (StringReader stringReader = new StringReader(xmlObj))
				{
					result = (T)((object)xmlSerializer.Deserialize(stringReader));
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				Debug.Log("xml 解析错误:" + xmlObj);
				result = default(T);
			}
			return result;
		}

		public static string SerializeXML<T>(T obj)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string result;
			using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings
			{
				OmitXmlDeclaration = true
			}))
			{
				XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
				xmlSerializerNamespaces.Add(string.Empty, string.Empty);
				new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj, xmlSerializerNamespaces);
				result = stringBuilder.ToString();
			}
			return result;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00008CA4 File Offset: 0x00006EA4
		//public static IEnumerator ServerRequest(string path, Hashtable paramTable, CommonSettings.ObjectCallBack callback)
		//{
		//	int i = 0;
		//	StringBuilder buffer = new StringBuilder();
		//	if (paramTable != null)
		//	{
		//		foreach (object obj in paramTable.Keys)
		//		{
		//			string key = (string)obj;
		//			if (i > 0)
		//			{
		//				buffer.AppendFormat("&{0}={1}", key, WWW.EscapeURL(paramTable[key] as string));
		//			}
		//			else
		//			{
		//				buffer.AppendFormat("?{0}={1}", key, WWW.EscapeURL(paramTable[key] as string));
		//			}
		//			i++;
		//		}
		//	}
		//	WWW www = new WWW(path + buffer.ToString());
		//	yield return www;
		//	int timeout = 100;
		//	while (!www.isDone)
		//	{
		//		int num;
		//		timeout = (num = timeout) - 1;
		//		if (num <= 0)
		//		{
		//			break;
		//		}
		//		Thread.Sleep(100);
		//	}
		//	if (string.IsNullOrEmpty(www.error))
		//	{
		//		string response = www.text;
		//		callback(MiniJSON.jsonDecode(response));
		//		yield return response;
		//	}
		//	www.Dispose();
		//	yield return null;
		//	yield break;
		//}

		// Token: 0x06000117 RID: 279 RVA: 0x00008CE4 File Offset: 0x00006EE4
		//public static void openURL(string url)
		//{
		//	if (Application.isWebPlayer)
		//	{
		//		Application.ExternalEval("window.open('" + url + "');");
		//	}
		//	else
		//	{
		//		Application.OpenURL(url);
		//	}
		//}

		private static System.Random rnd = new System.Random();

		public static string[] chineseNumber = new string[]
		{
			"零",
			"一",
			"二",
			"三",
			"四",
			"五",
			"六",
			"七",
			"八",
			"九",
			"十",
			"十一",
			"十二",
			"十三",
			"十四",
			"十五",
			"十六",
			"十七",
			"十八",
			"十九",
			"二十",
			"二十一",
			"二十二",
			"二十三",
			"二十四",
			"二十五",
			"二十六",
			"二十七",
			"二十八",
			"二十九",
			"三十",
			"三十一"
		};

		// Token: 0x040000A1 RID: 161
		public static char[] chineseTime = new char[]
		{
			'子',
			'丑',
			'寅',
			'卯',
			'辰',
			'巳',
			'午',
			'未',
			'申',
			'酉',
			'戌',
			'亥'
		};
	}
}
