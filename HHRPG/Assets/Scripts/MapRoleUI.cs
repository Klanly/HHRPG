using System;
using JyGame;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MapRoleUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
    public const int MAP_ROLE_TIMECOST = 2;

    public static MapRoleUI currentRoleUI;

    private Sprite _sprite;

    private MapUI _mapUI;

    private MapEvent _evt;

    private MapRole _role;

    private string desc;

    private string mapRoleName;

    public void OnMapRoleClicked()
	{
        Debug.Log("点击");
        BaseGamePlayManager.StartStage(null);//进入战斗之前要设置关卡信息
        SceneManager.LoadScene("BattleScene");
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

    public void Bind(MapUI mapUI, MapRole role, int index, MapEvent evt)
    {
        Debug.Log("执行");       
        //this.HideToolTip();
        //this._evt = evt;
        //this._role = role;
        //this._mapUI = mapUI;
        //this.mapRoleName = role.Name;
        //this.desc = role.description;
        //string text = (!(role.pic == "无") && !string.IsNullOrEmpty(role.pic)) ? role.pic : string.Empty;
        //if (string.IsNullOrEmpty(text))
        //{
        //    Role role2 = ResourceManager.Get<Role>(role.roleKey);
        //    if (role2 != null && !string.IsNullOrEmpty(role2.Head))
        //    {
        //        text = role2.Head;
        //    }
        //}
        //bool active = false;
        //if (this._evt != null)
        //{
        //    if (!string.IsNullOrEmpty(this._evt.description))
        //    {
        //        this.desc = this._evt.description;
        //    }
        //    if (!string.IsNullOrEmpty(this._evt.image))
        //    {
        //        text = this._evt.image;
        //    }
        //    if (this._evt.IsRepeatOnce)
        //    {
        //        active = true;
        //    }
        //}
        //this._sprite = Resource.GetImage(text, false);
        //base.transform.FindChild("_mask").FindChild("HeadImage").GetComponent<Image>().sprite = this._sprite;
        //if (text.StartsWith("地图"))
        //{
        //    base.transform.FindChild("_mask").FindChild("HeadImage").transform.localScale = new Vector3(1.7777778f, 1f);
        //}
        //base.transform.localPosition = new Vector3((float)(-398 + index * 200), 90f, 0f);
        //base.transform.FindChild("StoryTag").gameObject.SetActive(active);
        //base.transform.FindChild("NameText").GetComponent<Text>().text = this.mapRoleName;
        //if (RuntimeData.Instance.hasTask())
        //{
        //    base.transform.FindChild("StoryTag").gameObject.SetActive(false);
        //}
        //if (RuntimeData.Instance.isLocationInTask(role.Name))
        //{
        //    base.transform.FindChild("StoryTag").gameObject.SetActive(true);
        //}
    }

    public void OnPointerEnter(PointerEventData data)
	{
		//if (!CommonSettings.TOUCH_MODE)
		//{
		//	this.ShowToolTip();
		//}
	}

	public void OnPointerExit(PointerEventData data)
	{
		//if (!CommonSettings.TOUCH_MODE)
		//{
		//	this.HideToolTip();
		//}
	}

	private GameObject ToolTipPanel
	{
		get
		{
			return base.transform.FindChild("ToolTipPanel").gameObject;
		}
	}

	private void ShowToolTip()
	{
		this.ToolTipPanel.SetActive(true);
		this.ToolTipPanel.transform.FindChild("Text").GetComponent<Text>().text = this.desc;
	}

	private void HideToolTip()
	{
		this.ToolTipPanel.SetActive(false);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
