using JyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGamePlayFormation : MonoBehaviour
{
    public Transform[] containers;
    public Transform helperContainer;
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

    public virtual void SetCharacters(PlayerItem[] items)
    {
        ClearCharacters();
        for (var i = 0; i < containers.Length; ++i)
        {
            if (items.Length <= i)
                break;
            var item = items[i];
            //SetCharacter(i, item);
        }
    }

    public virtual BaseCharacterEntity SetCharacter(int position, Role item)//PlayerItem
    {
        var container = containers[position];
        container.RemoveAllChildren();
        Debug.Log("创建角色"+ item.Name);
        //var character = Instantiate(item.CharacterData.model);
        //character.SetFormation(this, position, container);
        //character.Item = item;
        //Characters[position] = character;

        //return character;
        return null;
    }

    public virtual BaseCharacterEntity SetHelperCharacter(PlayerItem item)
    {
        if (helperContainer == null)
            return null;

        var position = containers.Length;

        if (item.CharacterData.model == null)
        {
            Debug.LogWarning("Character's model is empty, this MUST be set");
            return null;
        }

        var container = helperContainer;
        container.RemoveAllChildren();

        var character = Instantiate(item.CharacterData.model);
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
        if (helperContainer != null)
            helperContainer.RemoveAllChildren();
        Characters.Clear();
    }
}
