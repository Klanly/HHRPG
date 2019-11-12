using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace JyGame
{

	public class SaveManager
	{

		public static string GetSave(string saveName)
		{
			if (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WindowsEditor)
			{
				if (!CommonSettings.MOD_EDITOR_MODE)
				{
					return SaveManager.crcm(PlayerPrefs.GetString(saveName));
				}
			}
			StreamReader streamReader;
			try
			{
				streamReader = new StreamReader(File.OpenRead("Save/" + saveName + ".xml"));
			}
			catch
			{
				return string.Empty;
			}
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			if (CommonSettings.MOD_EDITOR_MODE)
			{
				return text;
			}
			return SaveManager.crcm(text);
		}

		public static void SetSave(string saveName, string content)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || CommonSettings.MOD_EDITOR_MODE)
			{
				File.Delete("Save/" + saveName + ".xml");
				StreamWriter streamWriter = new StreamWriter(File.Open("Save/" + saveName + ".xml", FileMode.CreateNew));
				if (CommonSettings.MOD_EDITOR_MODE)
				{
					streamWriter.Write(content);
				}
				else
				{
					streamWriter.Write(SaveManager.crcjm(content));
				}
				streamWriter.Close();
			}
			else
			{
				PlayerPrefs.SetString(saveName, SaveManager.crcjm(content));
			}
		}

		public static void DeleteSave(string saveName)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || CommonSettings.MOD_EDITOR_MODE)
			{
				File.Delete("Save/" + saveName + ".xml");
			}
			else
			{
				PlayerPrefs.SetString(saveName, string.Empty);
			}
		}

		public static bool ExistSave(string saveName)
		{
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || CommonSettings.MOD_EDITOR_MODE)
			{
				return File.Exists("Save/" + saveName + ".xml");
			}
			return PlayerPrefs.HasKey(saveName);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000085A8 File Offset: 0x000067A8
		public static string crcjm(string input)
		{
			string str = SaveManager.jm(input);
			string str2 = SaveManager.CRC16_C(input);
			return str2 + "@" + str;
		}

		public static string crcm(string input)
		{
			string[] array = input.Split(new char[]
			{
				'@'
			});
			if (array.Length != 2)
			{
				return string.Empty;
			}
			string a = array[0];
			string text = SaveManager.m(array[1]);
			string b = SaveManager.CRC16_C(text);
			if (a != b)
			{
				return string.Empty;
			}
			return text;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00008628 File Offset: 0x00006828
		private static string jm(string Message)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] key = md5CryptoServiceProvider.ComputeHash(utf8Encoding.GetBytes("$t611@"));
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider
			{
				Key = key,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};
			byte[] bytes = utf8Encoding.GetBytes(Message);
			byte[] inArray;
			try
			{
				inArray = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
			}
			finally
			{
				tripleDESCryptoServiceProvider.Clear();
				md5CryptoServiceProvider.Clear();
			}
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000086C8 File Offset: 0x000068C8
		private static string m(string Message)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] key = md5CryptoServiceProvider.ComputeHash(utf8Encoding.GetBytes("$t611@"));
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider
			{
				Key = key,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};
			byte[] array = Convert.FromBase64String(Message);
			byte[] bytes;
			try
			{
				bytes = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			}
			finally
			{
				tripleDESCryptoServiceProvider.Clear();
				md5CryptoServiceProvider.Clear();
			}
			return utf8Encoding.GetString(bytes);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00008768 File Offset: 0x00006968
		private static string CRC16_C(string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			byte b = byte.MaxValue;
			byte b2 = byte.MaxValue;
			byte b3 = 1;
			byte b4 = 160;
			byte[] array = bytes;
			for (int i = 0; i < array.Length; i++)
			{
				b ^= array[i];
				for (int j = 0; j <= 7; j++)
				{
					byte b5 = b2;
					byte b6 = b;
					b2 = (byte)(b2 >> 1);
					b = (byte)(b >> 1);
					if ((b5 & 1) == 1)
					{
						b |= 128;
					}
					if ((b6 & 1) == 1)
					{
						b2 ^= b4;
						b ^= b3;
					}
				}
			}
			return string.Format("{0}{1}", b2, b);
		}

		// Token: 0x0400009D RID: 157
		private static string saltValue = "fuck1zbl06";

		// Token: 0x0400009E RID: 158
		private static string pwdValue = "zbl06fuck1";
	}
}
