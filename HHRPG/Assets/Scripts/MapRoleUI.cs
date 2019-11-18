using System;
using JyGame;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000097 RID: 151
public class MapRoleUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	// Token: 0x060004BB RID: 1211 RVA: 0x00027BD0 File Offset: 0x00025DD0
	public void OnMapRoleClicked()
	{
		//if (CommonSettings.TOUCH_MODE)
		//{
		//	if (this._evt != null && MapRoleUI.currentRoleUI != this)
		//	{
		//		this._mapUI.ShowEventConfirmPanel(this._sprite, this._evt, this.mapRoleName, this.desc, 2);
		//		MapRoleUI.currentRoleUI = this;
		//	}
		//	else if (this._evt != null)
		//	{
		//		this.Execute();
		//	}
		//}
		//else
		//{
		//	this.Execute();
		//}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x00027C50 File Offset: 0x00025E50
	private void Execute()
	{
		//this._mapUI.HideEventConfirmPanel();
		//if (this._evt.value != RuntimeData.Instance.CurrentBigMap)
		//{
		//	RuntimeData.Instance.SetLocation(RuntimeData.Instance.CurrentBigMap, this.mapRoleName);
		//}
		//RuntimeData.Instance.Date = RuntimeData.Instance.Date.AddHours(2.0);
		//RuntimeData.Instance.gameEngine.SwitchGameScene(this._evt.type, this._evt.value);
		//MapLocationUI.currentLocationUI = null;
		MapRoleUI.currentRoleUI = null;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x00027CF8 File Offset: 0x00025EF8
	//public void Bind(MapUI mapUI, MapRole role, int index, MapEvent evt)
	//{
	//	this.HideToolTip();
	//	this._evt = evt;
	//	this._role = role;
	//	this._mapUI = mapUI;
	//	this.mapRoleName = role.Name;
	//	this.desc = role.description;
	//	string text = (!(role.pic == "无") && !string.IsNullOrEmpty(role.pic)) ? role.pic : string.Empty;
	//	if (string.IsNullOrEmpty(text))
	//	{
	//		Role role2 = ResourceManager.Get<Role>(role.roleKey);
	//		if (role2 != null && !string.IsNullOrEmpty(role2.Head))
	//		{
	//			text = role2.Head;
	//		}
	//	}
	//	bool active = false;
	//	if (this._evt != null)
	//	{
	//		if (!string.IsNullOrEmpty(this._evt.description))
	//		{
	//			this.desc = this._evt.description;
	//		}
	//		if (!string.IsNullOrEmpty(this._evt.image))
	//		{
	//			text = this._evt.image;
	//		}
	//		if (this._evt.IsRepeatOnce)
	//		{
	//			active = true;
	//		}
	//	}
	//	this._sprite = Resource.GetImage(text, false);
	//	base.transform.FindChild("_mask").FindChild("HeadImage").GetComponent<Image>().sprite = this._sprite;
	//	if (text.StartsWith("地图"))
	//	{
	//		base.transform.FindChild("_mask").FindChild("HeadImage").transform.localScale = new Vector3(1.7777778f, 1f);
	//	}
	//	base.transform.localPosition = new Vector3((float)(-398 + index * 200), 90f, 0f);
	//	base.transform.FindChild("StoryTag").gameObject.SetActive(active);
	//	base.transform.FindChild("NameText").GetComponent<Text>().text = this.mapRoleName;
	//	if (RuntimeData.Instance.hasTask())
	//	{
	//		base.transform.FindChild("StoryTag").gameObject.SetActive(false);
	//	}
	//	if (RuntimeData.Instance.isLocationInTask(role.Name))
	//	{
	//		base.transform.FindChild("StoryTag").gameObject.SetActive(true);
	//	}
	//}

	// Token: 0x060004BE RID: 1214 RVA: 0x00027F40 File Offset: 0x00026140
	public void OnPointerEnter(PointerEventData data)
	{
		//if (!CommonSettings.TOUCH_MODE)
		//{
		//	this.ShowToolTip();
		//}
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x00027F54 File Offset: 0x00026154
	public void OnPointerExit(PointerEventData data)
	{
		//if (!CommonSettings.TOUCH_MODE)
		//{
		//	this.HideToolTip();
		//}
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00027F68 File Offset: 0x00026168
	private GameObject ToolTipPanel
	{
		get
		{
			return base.transform.FindChild("ToolTipPanel").gameObject;
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x00027F80 File Offset: 0x00026180
	private void ShowToolTip()
	{
		this.ToolTipPanel.SetActive(true);
		this.ToolTipPanel.transform.FindChild("Text").GetComponent<Text>().text = this.desc;
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00027FC0 File Offset: 0x000261C0
	private void HideToolTip()
	{
		this.ToolTipPanel.SetActive(false);
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00027FD0 File Offset: 0x000261D0
	private void Start()
	{
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x00027FD4 File Offset: 0x000261D4
	private void Update()
	{
	}

	// Token: 0x04000378 RID: 888
	public const int MAP_ROLE_TIMECOST = 2;

	// Token: 0x04000379 RID: 889
	public static MapRoleUI currentRoleUI;

	// Token: 0x0400037A RID: 890
	private Sprite _sprite;

	// Token: 0x0400037B RID: 891
	private MapUI _mapUI;

	// Token: 0x0400037C RID: 892
	//private MapEvent _evt;

	// Token: 0x0400037D RID: 893
	private MapRole _role;

	// Token: 0x0400037E RID: 894
	private string desc;

	// Token: 0x0400037F RID: 895
	private string mapRoleName;
}
