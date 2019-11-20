using JyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGamePlayFormation : MonoBehaviour
{
    public Transform[] containers;
    public readonly Dictionary<int, BaseCharacterEntity> Characters = new Dictionary<int, BaseCharacterEntity>();

    /// <summary>
    /// 设置阵型角色
    /// </summary>
    public virtual void SetFormationCharacters()
    {
        List<Role> Teamlist = RuntimeData.Instance.Team;
        ClearCharacters();
        for (var i = 0; i < Teamlist.Count; ++i)
        {
            SetCharacter(i,Teamlist[i]);
        }        
    }

    public virtual void SetCharacters(Role[] items)
    {
        ClearCharacters();
        //for (var i = 0; i < containers.Length; ++i)
        //{
        //    if (items.Length <= i)
        //        break;
        //    var item = items[i];
        //    SetCharacter(i, item);
        //}
    }

    public virtual BaseCharacterEntity SetCharacter(int position, Role item)
    {
        var container = containers[position];
        container.RemoveAllChildren();
        GameObject go= Resources.Load("Characters/zhujiao_cike_animation")as GameObject;
        var character = Instantiate(go).GetComponent<BaseCharacterEntity>();
        character.SetFormation(this, position, container);
        character.Item = item;
        Characters[position] = character;

        return character;
    }

    /// <summary>
    /// 清除角色
    /// </summary>
    public virtual void ClearCharacters()
    {
        foreach (var container in containers)
        {
            container.RemoveAllChildren();
        }
        Characters.Clear();
    }
}
