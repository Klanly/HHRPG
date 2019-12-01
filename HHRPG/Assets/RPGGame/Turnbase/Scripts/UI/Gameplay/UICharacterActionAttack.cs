using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterActionAttack : UICharacterAction
{
    protected override void OnActionSelected()
    {
        Debug.Log("攻击");
        ActionManager.ActiveCharacter.SetAction(CharacterEntity.ACTION_ATTACK);
    }
}
