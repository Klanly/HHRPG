﻿using System;
using JyGame;
using UnityEngine;
using UnityEngine.UI;

public class RoleStatePanelUI : MonoBehaviour
{
    public GameObject RoleHeadObj;

    /// <summary>
    /// 更新
    /// </summary>
    public void Refresh()
	{
		if (RuntimeData.Instance.Team.Count > 0)
		{
			//this.RoleHeadObj.GetComponent<Image>().sprite = Resource.GetZhujueHead();
		}
		//base.transform.FindChild("HardIcon").GetComponent<HardIconScript>().HideSuggestInfo();
		//base.transform.FindChild("HardIcon").FindChild("NickText").GetComponent<Text>().text = RuntimeData.Instance.CurrentNick;
		Text component = base.transform.FindChild("HardIcon").FindChild("ZhoumuText").GetComponent<Text>();
		if (RuntimeData.Instance.GameMode == "normal")
		{
			component.text = "简单:周目" + RuntimeData.Instance.Round;
			component.color = Color.white;
		}
		else if (RuntimeData.Instance.GameMode == "hard")
		{
			component.text = "进阶:周目" + RuntimeData.Instance.Round;
			component.color = Color.yellow;
		}
		else if (RuntimeData.Instance.GameMode == "crazy")
		{
			component.text = "炼狱:周目" + RuntimeData.Instance.Round;
			component.color = Color.red;
		}
	}

	private void Start()
	{
		this.Refresh();
	}

	private void Update()
	{
	}
}
